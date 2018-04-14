using BinanceCryptoCurrency.Domain;
using BinanceCryptoCurrency.Processor;
using System.Collections.Generic;

namespace BinanceCryptoCurrency {

    public sealed class ClientSdk {
        private readonly IBinanceProcessor _binanceProcessor;

        public ClientSdk(IBinanceProcessor binanceProcessor) {
            _binanceProcessor = binanceProcessor;
        }

        public IEnumerable<Ticker> GetTickerLast24Hs() {
            var tickers = _binanceProcessor.GetTickerLast24Hs();

            return tickers;
        }
    }
}