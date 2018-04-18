using BinanceCryptoCurrency.Domain;
using BinanceCryptoCurrency.Processor;

namespace BinanceCryptoCurrency {

    public sealed class BinanceClientSdk {
        private readonly IBinanceProcessor _binanceProcessor;

        public BinanceClientSdk(IBinanceProcessor binanceProcessor) {
            _binanceProcessor = binanceProcessor;
        }

        public Response GetTickerLast24Hs() {
            var response = _binanceProcessor.GetTickerLast24Hs();

            return response;
        }
    }
}