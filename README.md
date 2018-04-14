# BinanceCryptoCurrency
Binance Crypto Currency Client SDK

<strong>Develop branch</strong><br />
<img src="https://ci.appveyor.com/api/projects/status/github/alexandrebl/BinanceCryptoCurrency?branch=develop&svg=true" alt="Project Badge" with="300">

<strong>Master branch</strong><br />
<img src="https://ci.appveyor.com/api/projects/status/github/alexandrebl/BinanceCryptoCurrency?branch=master&svg=true" alt="Project Badge" with="300">

### How to use
- Package Manager: Install-Package BinanceCryptoCurrency -Version 0.0.2
- .Net CLI: dotnet add package BinanceCryptoCurrency --version 0.0.2
- Paket CLI: paket add BinanceCryptoCurrency --version 0.0.2

### Nuget Package
https://www.nuget.org/packages/BinanceCryptoCurrency/

### Project example
https://github.com/alexandrebl/CryptoCurrencyInfo

### Example in .Net Core Web.API
#### TickerController.cs
```cs
using BinanceCryptoCurrency.Domain;
using BinanceCryptoCurrency.Processor;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CryptoCurrencyInfo.Controllers {

    [Produces("application/json")]
    [Route("api/Ticker")]
    public class TickerController : Controller {
        private readonly IBinanceProcessor _binanceProcessor;

        public TickerController(IBinanceProcessor binanceProcessor) {
            _binanceProcessor = binanceProcessor;
        }

        public IEnumerable<Ticker> Get() {
            var result = _binanceProcessor.GetTickerLast24Hs();

            return result.Tickers;
        }
    }
}
```
#### StartUp.cs
```cs
using BinanceCryptoCurrency.Processor;
using BinanceCryptoCurrency.Utility;
using CryptoCurrencyInfo.Library;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CryptoCurrencyInfo {

    public class Startup {

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static void ConfigureServices(IServiceCollection services) {
            var configurationFileApp = new ConfigurationFileApp();
            services.AddMvc();
            services.AddSingleton<IBinanceProcessor>(
                new BinanceProcessor(new Uri(configurationFileApp.BinanceUrl), new Logger()));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
```

#### ConfigurationFileApp.cs
```cs
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CryptoCurrencyInfo.Library {

    public sealed class ConfigurationFileApp : IConfigurationFileApp {
        public ConfigurationFileApp() {
            var builder = new ConfigurationBuilder().SetBasePath(
                Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            BinanceUrl = configuration[$"BinanceUrl"];
        }

        public string BinanceUrl { get; }
    }
}
```

#### appsettings.json
```json
{
  "BinanceUrl": "http://www.binance.com/api/v1/ticker/24hr"
}
```
