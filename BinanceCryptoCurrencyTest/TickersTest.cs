using BinanceCryptoCurrency.Processor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Net;
using BinanceCryptoCurrency;

namespace BinanceCryptoCurrencyTest {

    [TestClass]
    public class TickersTest {

        [TestMethod]
        public void Last24HsSuccess() {
            var clientSdk = new BinanceClientSdk(new 
                BinanceProcessor(new Uri("http://www.binance.com/api/v1/ticker/24hr")));

            var response = clientSdk.GetTickerLast24Hs();

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
            Assert.IsTrue(response.Tickers.Any());
        }

        [TestMethod]
        public void Last24HsUriError() {
            var clientSdk = new BinanceClientSdk(new
                BinanceProcessor(new Uri("http://www.binance.com/api/v1/ticker/xxx")));

            var response = clientSdk.GetTickerLast24Hs();

            Assert.IsNotNull(response);
            Assert.IsFalse(response.Success);
            Assert.IsTrue(response.StatusCode != HttpStatusCode.OK);
            Assert.IsNull(response.Tickers);
        }
    }
}