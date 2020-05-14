# Working with Redis Cache with .Net Core and NodeJS [Session on 20-May-2020]

## Working with Redis Cache in our Laptop

URL: <https://redislabs.com/blog/redis-on-windows-10/>

### To Install on WSL on Windows 10

1. sudo apt-get update
2. sudo apt-get upgrade
3. sudo apt-get install redis-server

### To Start and Stop the Redis Service

1. sudo service redis-server restart
2. sudo service redis-server stop

### Verifying the Version

1. redis-server -v
2. redis-cli -v

### To connect to Redis Server

1. redis-cli

## Working with Redis Cache in Azure

To be done.

## Creating Simple ASP.Net Core 3.1 Web API (EF Core, and Redis)

1. We will verify the existing .Net Core Web API using Postman.
2. We will add the Redis Cache Nuget package and configure it in Start up class.
3. Verify the services Container using Shift + F9

4. Get All Professors. Verify the Redis Cache from Command line.
5. Verify the Time Stamps of retrieval with and without Redis Cache.
6. Retrieve a particular Professor. Verify the Redis Cache from Command line.
7. Verify the Time Stamps of retrieval with and without Redis Cache.
8. Delete OR Wait till the Cache Expiration and verify the time stamps.

## Consuming the ASP.net Core Web API in Client Application


## Creating Simple Node JS Web API (Mongo Db, and Redis)


## Consuming Node JS Web API in Client Application.

