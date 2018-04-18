using System;
using System.Net.Http;

namespace BinanceCryptoCurrency.Utility {

    public class HttpUtilityTool {

        private static readonly HttpClient HttpClient
            = new HttpClient(new HttpClientHandler() { MaxConnectionsPerServer = 2000 });

        public HttpResponseMessage GetData(Uri uri) {
            HttpClient.BaseAddress = uri;

            var httpRequestTask = HttpClient.GetAsync(uri);

            var httpResponseMessage = httpRequestTask.Result;

            return httpResponseMessage;
        }
    }
}