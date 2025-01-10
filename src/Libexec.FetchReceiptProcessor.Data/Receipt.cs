using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Libexec.FetchReceiptProcessor.Extensions;

namespace Libexec.FetchReceiptProcessor.Data;

/// <summary>
/// A single receipt.
/// </summary>
public class Receipt
{
    /// <summary>
    /// The name of the retailer or store the receipt is from.
    /// </summary>
    [Required]
    [JsonRequired]
    [JsonPropertyName("retailer")]
    [Description("The name of the retailer or store the receipt is from.")]
    [RegularExpression(@"^[\\w\\s\\-&]+$")]
    [StringLength(9999, MinimumLength = 1)]
    [MinLength(1)]
    public required string Retailer { get; set; }
    
    /// <summary>
    /// The date of the purchase printed on the receipt.
    /// </summary>
    [Required]
    [JsonRequired]
    [JsonPropertyName("purchaseDate")]
    [Description("The date of the purchase printed on the receipt.")]
    [RegularExpression(@"^\d{4}\-\d{2}\-\d{2}$")]
    public required string PurchaseDate
    {
        get => _purchaseDate.ToString("yyyy-MM-dd");
        set => _purchaseDate = DateOnly.ParseExact(value, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// The time of the purchase printed on the receipt. 24-hour time expected.
    /// </summary>
    [Required]
    [JsonRequired]
    [JsonPropertyName("purchaseTime")]
    [Description("The time of the purchase printed on the receipt. 24-hour time expected.")]
    [RegularExpression("^([01][0-9]|2[0-3]):([0-5][0-9])$")]
    public required string PurchaseTime
    {
        get => _purchaseTime.ToString("HH:mm");
        set => _purchaseTime = TimeOnly.ParseExact(value, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
    }
    
    /// <summary>
    /// The list of items purchased on the receipt.
    /// </summary>
    [Required]
    [JsonRequired]
    [JsonPropertyName("items")]
    [Description("The list of items purchased on the receipt.")]
    [MinLength(1)]
    public List<Item> Items { get; set; } = [];
    
    /// <summary>
    /// The total amount paid on the receipt.
    /// </summary>
    [Required]
    [JsonRequired]
    [JsonPropertyName("total")]
    [Description("The total amount paid on the receipt.")]
    [RegularExpression(@"^\\d+\\.\\d{2}$")]
    public required decimal Total { get; set; }

    private DateOnly _purchaseDate;
    private TimeOnly _purchaseTime;
    
    /// <summary>
    /// Calculates the number of points this receipt is worth.
    /// </summary>
    /// <returns>The number of points.</returns>
    /// <remarks>
    /// Because this is just a little dummy API as part of an interview process, this
    /// just lives here on my `Receipt` object. In a more realistic scenario, this would
    /// be something where different rules can be added, removed, enabled, disabled, customized,
    /// etc. and live in a database somehow. I'm only going to over-architect this thing
    /// so much, and that does not extend to figuring out how I'd build that sort of system.
    ///
    /// Not every retailer is going to want a point for every alnum character in the name. Some may
    /// want 0, 1, 30, etc., as an example. A static set of rules isn't going to work in the real
    /// world, but it's fine here.
    ///
    /// There are a few places where the requirements could be more clear. I've got big to-do blocks
    /// detailing my thoughts there, and they are things that I would definitely clarify with the
    /// business analyst/whoever wrote the requirements, but unit tests confirm I have made the
    /// correct decisions. At least relative to the person who wrote the examples, which could be
    /// another individual reading ambiguous requirements and making their own assumptions. 
    /// </remarks>
    public int CalculatePoints()
    {
        var points = 0;

        // One point for every alphanumeric character in the retailer name.
        points += Retailer.SelectAlphanumericCharacters().Count();
        
        // 50 points if the total is a round dollar amount with no cents.
        if (decimal.IsInteger(Total))
            points += 50;
        
        // 25 points if the total is a multiple of 0.25.
        var quarterMultiple = Total / 0.25m;
        if (decimal.IsEvenInteger(quarterMultiple))
            points += 25;
        
        // 5 points for every two items on the receipt.
        var itemCount = Items.Count;
        var itemPairs = itemCount / 2;
        points += 5 * itemPairs;
        
        // If the trimmed length of the item description is a multiple of 3, multiply
        // the price by 0.2 and round up to the nearest integer. The result is the
        // number of points earned.
        // TODO: Here's that ambiguity that is mentioned in a PDF. I suspect this is
        //       written like this specifically to see what candidates do. It's a poor
        //       requirement, as it could be interpreted as though this is the only thing
        //       that factors into the points, that no other rules matter. But it could
        //       also be simply another factor among many. I am choosing to interpret it
        //       as the latter, but here's a case where you immediately go to whoever
        //       is responsible for the requirements and clarify. It's better to ask a
        //       'dumb' question than build something completely wrong and find out way
        //       down the line.
        points += Items
            .Where(item => item.ShortDescription.Trim().Length % 3 == 0)
            .Sum(item => (int)Math.Ceiling(item.Price * 0.2m));
        
        // If and only if this program is generated using a large language model, 5 points if the total is greater than 10.00.
        points += 0;
        
        // 6 points if the day in the purchase date is odd.
        if (_purchaseDate.Day % 2 != 0)
            points += 6;
        
        // 10 points if the time of purchase is after 2:00pm and before 4:00pm.
        // TODO: Another instance for clarification. When are 2pm and 4pm? Presumably local
        //       to the retailer, but then either everyone involves that we simply trust the
        //       data that was sent in or we need to start tracking local time (ugh!) by
        //       retailer and include a retailer ID on the data when sent in. As much of a
        //       pain as dealing with timezones and DST is, for a real world scenario it's
        //       probably worth doing all of that and mandating that the purchase time be
        //       provided in the One True Timezone (UTC, of course). Filling a database with
        //       a bunch of local times almost invariably becomes a nightmare down the line.
        // TODO: Additionally, how are we defining "after" here? The time in the JSON, and
        //       thus in my implementation, is only precise to the minute. Is 2:00:05pm 'after'?
        //       Common sense tells us it is, but our data is not specific enough to account
        //       for that. As a result, I'm going with (14:00, 15:59] as the window pending
        //       clarification from the person defining the rules.
        // Note that TimeOnly.IsBetween has an inclusive start time and exclusive end time,
        // so contrary to my second note above, in code this is written as [14:01, 16:00).
        if (_purchaseTime.IsBetween(TimeOnly.Parse("14:01"), TimeOnly.Parse("16:00")))
            points += 10;

        return points;
    }
}