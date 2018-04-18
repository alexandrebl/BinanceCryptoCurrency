using BinanceCryptoCurrency.Domain;

namespace BinanceCryptoCurrency.Processor {

    public interface IBinanceProcessor {

        Response GetTickerLast24Hs();
    }
}