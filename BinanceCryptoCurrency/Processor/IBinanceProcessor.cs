using BinanceCryptoCurrency.Domain;
using System.Collections.Generic;

namespace BinanceCryptoCurrency.Processor {

    public interface IBinanceProcessor {

        IEnumerable<Ticker> GetTickerLast24Hs();
    }
}