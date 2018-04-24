using System;
using System.Net.Http;

namespace BinanceCryptoCurrency.Utility
{
    public interface IHttpUtilityTool
    {
        HttpResponseMessage GetData(Uri uri);
    }
}
