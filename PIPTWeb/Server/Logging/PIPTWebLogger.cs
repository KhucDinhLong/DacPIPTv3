using Microsoft.Extensions.Logging;
using PIPTWeb.Shared.Data;
using System;

namespace PIPTWeb.Server.Logging
{
    public class PIPTWebLogger : ILogger
    {
        private readonly PIPTDbContext _dbContext;

        public PIPTWebLogger(PIPTDbContext dbContext)
        {
            _dbContext = dbContext;
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
            //log.Source = "Server";
            //log.ExceptionMessage = exception?.Message;
            //log.StackTrace = exception?.StackTrace;
            //log.CreatedDate = DateTime.Now;
            //if (state != null)
            //{
            //    log.Param = formatter(state, exception);
            //}
            //_dbContext.SysExceptionLogs.Add(log);
            //_dbContext.SaveChanges();
        }

        public string Formatter<TState>(TState state, Exception exception)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(state);
        }
    }
}
