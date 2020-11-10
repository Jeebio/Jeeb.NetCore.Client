# Jeeb.NetCore.Client

[![NuGet version (Jeeb.NetCore.Client)](https://img.shields.io/nuget/v/Jeeb.Client.svg?style=flat-square)](https://www.nuget.org/packages/Jeeb.Client/)

## What is it

`Jeeb.NetCore.Client` is a dotnet imeplementation of [Jeeb Payment Gateway](https://jeeb.io)'s APIs. This library is built on netstandard so it could be used on various platforms.  
For furthur information you can visit our official [documentation](https://docs.jeeb.io) page.

## Demo

Full demonstration of Jeeb Payment Gateway's APIs implementation using this library is available under `Jeeb.Client.Demo` directory.

## Setup

1. Login into your Jeeb's account and create an API KEY (from version 3, using signature has obsoleted)

1. This package has been published on Nuget package. Just run this command:  
`dotnet add package Jeeb.Client --version 2.0.0`  
or  
`Install-Package Jeeb.Client -Version 2.0.0`  

1. There are two different services, `JeebPaymentClient` and `JeebMarketClient`. You should use `JeebPaymentClient` for integrating Jeeb Payment Gateway into your website/application. However, some extra tools such as rates and currency-related APIs can be found in `JeebMarketClient`. Both services have the corresponding interfaces so they could be registered into any IOC container. Just beware that `JeebPaymentClient` requires ApiKey in the constructor.  
Example:  

``` C#
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(IJeebMarketClient), typeof(JeebMarketClient));
            services.AddSingleton(typeof(IJeebPaymentClient), provider => new JeebPaymentClient(Configuration["Jeeb:ApiKey"]));
        }
```

## Callbacks and Webhooks

Jeeb has utilized webhook architecture to notify clients about any changes on any payments. So it is advised to implement the required webhook endpoint into your project.
Data Models for both webhooks and callbacks are available in this library. For webhooks use `Jeeb.Client.Dtos.WebhookDto` and for callbacks use `Jeeb.Client.Dtos.CallbackDto`.
