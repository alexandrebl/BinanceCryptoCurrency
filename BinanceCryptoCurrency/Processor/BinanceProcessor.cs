using BinanceCryptoCurrency.Domain;
using BinanceCryptoCurrency.Domain.Entity;
using BinanceCryptoCurrency.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;

namespace BinanceCryptoCurrency.Processor {

    public class BinanceProcessor : IBinanceProcessor {
        private readonly Uri _uri;

        public BinanceProcessor(Uri uri) {
            _uri = uri;
        }

        public Response GetTickerLast24Hs() {
            var httpResponseMessage = Get(_uri);

            return ParseHttpContent(httpResponseMessage);
        }

        private static Response ParseHttpContent(HttpResponseMessage httpResponseMessage) {
            if (!httpResponseMessage.IsSuccessStatusCode)
                return new Response {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Erros = new Collection<Error>
                    {
                        new Error
                        {
                            Message = "Internal Server Error"
                        }
                    }
                };

            var content = httpResponseMessage.Content;
            var tickers = JsonConvert.DeserializeObject<IEnumerable<Ticker>>(content.ReadAsStringAsync().Result);

            var response = new Response { Tickers = tickers, StatusCode = HttpStatusCode.OK };

            return response;
        }

        private static HttpResponseMessage Get(Uri uri) {
            var httpUtilityTool = new HttpUtilityTool();

            var httpResponseMessage = httpUtilityTool.GetData(uri);

            return httpResponseMessage;
        }
    }
}