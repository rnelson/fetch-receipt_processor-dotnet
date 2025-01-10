Fetch Receipt Processor (.NET)
==============================

About
-----
A solution for Fetch's [Receipt Processor challenge][fetch-rpc].

Requirements
------------
* .NET 9
* Docker (optional)

Container Usage
---------------
To build the container from source, run `docker build -t fetchreceiptprocessor:1.0.0 .`

You can `docker run -p 12345:8080 fetchreceiptprocessor:1.0.0`

License
-------
This program is licensed under the [MIT license][license].

[license]: https://rnelson.mit-license.org
[fetch-rpc]: https://github.com/fetch-rewards/receipt-processor-challenge