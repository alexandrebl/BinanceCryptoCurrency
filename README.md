# BinanceCryptoCurrency
Binance Crypto Currency Client SDK

<strong>Develop branch</strong><br />
<img src="https://ci.appveyor.com/api/projects/status/github/alexandrebl/BinanceCryptoCurrency?branch=develop&svg=true" alt="Project Badge" with="300">

<strong>Master branch</strong><br />
<img src="https://ci.appveyor.com/api/projects/status/github/alexandrebl/BinanceCryptoCurrency?branch=master&svg=true" alt="Project Badge" with="300">

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
```cs
