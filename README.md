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
The container is [available on Docker Hub][hub-link] and can be run without having to build anything 
yourself: `docker run -d -p 12345:8080 rossnelson84/fetchreceiptprocessor:1.0.0`

To build the container from source, run `docker build -t fetchreceiptprocessor:1.0.0 .`

You can `docker run -d -p 12345:8080 fetchreceiptprocessor:1.0.0`, substituting your local port of choice 
for `12345` (e.g., `-p 9090:8080` to run on port 9090 on the host).

License
-------
This program is licensed under the [MIT license][license].

[license]: https://rnelson.mit-license.org
[fetch-rpc]: https://github.com/fetch-rewards/receipt-processor-challenge
[hub-link]: https://hub.docker.com/repository/docker/rossnelson84/fetchreceiptprocessor/general