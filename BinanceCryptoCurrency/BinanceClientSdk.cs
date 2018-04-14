using BinanceCryptoCurrency.Domain;
using BinanceCryptoCurrency.Processor;
using System.Collections.Generic;

namespace BinanceCryptoCurrency {

    public sealed class BinanceClientSdk {
        readonly IBinanceProcessor _binanceProcessor;

        public BinanceClientSdk(IBinanceProcessor binanceProcessor) {
            _binanceProcessor = binanceProcessor;
        }

        public Response GetTickerLast24Hs() {
            var response = _binanceProcessor.GetTickerLast24Hs();

            return response;
        }
    }
}