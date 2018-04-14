using BinanceCryptoCurrency.Domain;
using System;
using System.Collections.Generic;

namespace BinanceCryptoCurrency.Processor {

    public class BinanceProcessor : IBinanceProcessor {
        public readonly Uri Uri;

        public BinanceProcessor(Uri uri) {
            Uri = uri;
        }

        public IEnumerable<Ticker> GetTickerLast24Hs() {
            var tickers = new List<Ticker>
            {
                new Ticker {Symbol = "ETH", LastPrice = 1, LastQty = 0.1},
                new Ticker {Symbol = "BTC", LastPrice = 2, LastQty = 0.2}
            };

            return tickers;
        }
    }
}