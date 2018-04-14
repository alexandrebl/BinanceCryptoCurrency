using System;

namespace BinanceCryptoCurrency.Utility {

    public interface ILogger {

        void Write(Exception ex);

        void Write(string msg);
    }
}