using Microsoft.Extensions.Logging;
using PIPTWeb.Shared.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace PIPTWeb.Client.Logging
{
    public class OneAppLogger : ILogger
    {
        private readonly HttpClient _httpClient;

        public OneAppLogger(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            //SysExceptionLogs log = new SysExceptionLogs();
            //log.EventName = eventId.Name;
            //log.LogLevel = logLevel.ToString();
            //log.Source = "Client";
            //log.ExceptionMessage = exception?.Message;
            //log.StackTrace = exception?.StackTrace;
            //log.CreatedDate = DateTime.Now;

            //_httpClient.PostAsJsonAsync($"api/SysExceptionLogs", log);
        }
    }
}
