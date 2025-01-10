# Fetch Receipt Processor (.NET)

A solution for Fetch's [Receipt Processor challenge][fetch-rpc].

### About

While Fetch's preferred language is Go, I am currently most comfortable in C#. As someone who has been 
doing this for a while, I understand that any senior developer is often going to be able to read and  
understand code even in a language they don't use, and doing this in the language I've most heavily 
used for the last 6 years gives the best representation of how I attack the problem and architect a 
complete project.

#### Architecture

Other than unit tests, the solution is split into the following projects:

1. `Libexec.FetchReceiptProcessor`, the ASP.NET Core Web API project providing the API.
2. `Libexec.FetchReceiptProcessor.Data`, a combination of shared models, abstractions, and my data access layer (DAL).
3. `Libexec.FetchReceiptProcessor.Extensions`, a project for just [extension methods][dotnet-ext].

The Extensions project only has a single extension. I have been meaning to take all the random helper 
extension classes that I've written and shoving them into a single NuGet package for easier reuse, but 
since I haven't gotten around to that yet the helper I wrote is in its own project.

There isn't a lot to say about the Data project. The one thing I feel I should point out is that I wrote 
`IDatabase` and `Database`, an interface and concrete class, to act as my in-memory database. In the startup 
file ([Program.cs][program-cs]), I add a singleton mapping `IDatabase` to `Database` in ASP.NET Core's 
dependency injection framework. In a more realistic example, I would have an object that actually hits a 
database through whatever means, and then be able to use that same DI container to mock a database for 
unit tests, so I'm not ruining real data or adding unnecessary stress to the DBMS.

With .NET 9, Microsoft released a new OpenAPI package. I've used Swashbuckle, a popular .NET Swagger package, 
for years and took this as an opportunity to play with the new package. You can see the generated result by 
requesting `/openapi/v1.json` from a running instance of the API.

For the person(s) reviewing this code, these are the important files:

+ [src/Libexec.FetchReceiptProcessor/Program.cs](https://github.com/rnelson/fetch-receipt_processor-dotnet/blob/main/src/Libexec.FetchReceiptProcessor/Program.cs): startup code that configures the API and causes it to run
+ [src/Libexec.FetchReceiptProcessor/Controllers/ReceiptsController.cs](https://github.com/rnelson/fetch-receipt_processor-dotnet/blob/main/src/Libexec.FetchReceiptProcessor/Controllers/ReceiptsController.cs): the controller handling the `/receipts` requests
+ [src/Libexec.FetchReceiptProcessor.Data/Receipt.cs](https://github.com/rnelson/fetch-receipt_processor-dotnet/blob/main/src/Libexec.FetchReceiptProcessor.Data/Receipt.cs): model that contains the point calculation rules

#### Tests

Since I had no time constraint for this project, I chose to go beyond the 2-3 hour mark to set *everything* 
up the way that I would for a personal project. That includes doing sufficient testing of the application.

First and foremost, there are three unit tests projects:

![Unit test results](https://github.com/rnelson/fetch-receipt_processor-dotnet/blob/main/docs/unit_tests.png?raw=true)

Between these three projects, the solution has 100% code coverage:

![Unit test code coverage](https://github.com/rnelson/fetch-receipt_processor-dotnet/blob/main/docs/code_coverage.png?raw=true)

Additionally, using [JetBrains' HTTP client][jb-http], I built simple integration tests that run all of the 
Fetch-provided JSON through the live application:

![HTTP test results](https://github.com/rnelson/fetch-receipt_processor-dotnet/blob/main/docs/http_tests.png?raw=true)

(To run these, open the sln file in [Rider][rider], start the "Libexec.FetchReceiptProcessor: http" project, open 
the Services explorer, and run the HTTP Requests.)

## Requirements
* .NET 9
* ASP.NET Core
* Docker (optional)

## Container Usage
The container is [available on Docker Hub][hub-link] and can be run without having to build anything 
yourself: `docker run -d -p 12345:8080 rossnelson84/fetchreceiptprocessor:1.0.0`

To build the container from source, run `docker build -t fetchreceiptprocessor:1.0.0 .`

You can `docker run -d -p 12345:8080 fetchreceiptprocessor:1.0.0`, substituting your local port of choice 
for `12345` (e.g., `-p 9090:8080` to run on port 9090 on the host).

## License
This program is licensed under the [MIT license][license].

[license]: https://rnelson.mit-license.org
[fetch-rpc]: https://github.com/fetch-rewards/receipt-processor-challenge
[hub-link]: https://hub.docker.com/repository/docker/rossnelson84/fetchreceiptprocessor/general
[jb-http]: https://www.jetbrains.com/help/idea/http-client-in-product-code-editor.html
[rider]: https://www.jetbrains.com/rider
[dotnet-ext]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[program-cs]: https://github.com/rnelson/fetch-receipt_processor-dotnet/blob/main/src/Libexec.FetchReceiptProcessor/Program.cs