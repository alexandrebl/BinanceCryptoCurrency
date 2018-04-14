using BinanceCryptoCurrency.Domain;
using System.Collections.Generic;

namespace BinanceCryptoCurrency.Processor {

    public interface IBinanceProcessor {

        Response GetTickerLast24Hs();
    }
}