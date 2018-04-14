using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using BinanceCryptoCurrency.Domain;
using BinanceCryptoCurrency.Domain.Entity;
using Newtonsoft.Json;

namespace BinanceCryptoCurrency.Utility {

    public class HttpUtilityTool {

        private static readonly HttpClient HttpClient
            = new HttpClient(new HttpClientHandler() { MaxConnectionsPerServer = 2000 });

        private readonly ILogger _logger;

        public HttpUtilityTool(ILogger logger) {
            _logger = logger;
        }

        public HttpResponseMessage GetData(Uri uri) {
            try {
                HttpClient.BaseAddress = uri;

                var httpRequestTask = HttpClient.GetAsync(uri);

                var httpResponseMessage = httpRequestTask.Result;

                return httpResponseMessage;
            } catch (Exception ex) {
                _logger.Write(ex);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}