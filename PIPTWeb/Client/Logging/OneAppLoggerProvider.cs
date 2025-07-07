using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace PIPTWeb.Client.Logging
{
    public class OneAppLoggerProvider : ILoggerProvider
    {
        private readonly HttpClient _httpClient;

        public OneAppLoggerProvider()
        {

        }
        public OneAppLoggerProvider(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new OneAppLogger(_httpClient);
        }

        public void Dispose()
        {
            
        }
    }
}
