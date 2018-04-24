using System;
using System.Linq;
using BinanceCryptoCurrency.Processor;
using BinanceCryptoCurrency.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BinanceCryptoCurrency.TestProj.UnitTests {
    [TestClass]
    public class ProcessorIntegrationTest {
        private static readonly Uri RightUri = new Uri(@"http://binance.com/api/v1/ticker/24hr");
        private static readonly Uri WrongUri = new Uri(@"http://binance.com/api/v1/ticker/24hrs");

        [TestMethod]
        public void GetResquestSuccess() {
            var binanceProcessor = new BinanceProcessor(RightUri, new HttpUtilityTool());
            var response = binanceProcessor.GetTickerLast24Hs();

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Tickers);
            Assert.IsTrue(response.Tickers.Any());
        }

        [TestMethod]
        public void GetResquestError() {
            var binanceProcessor = new BinanceProcessor(WrongUri, new HttpUtilityTool());
            var response = binanceProcessor.GetTickerLast24Hs();

            Assert.IsNotNull(response);
            Assert.IsNull(response.Tickers);
        }
    }
}
