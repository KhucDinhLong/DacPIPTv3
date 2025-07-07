using Microsoft.Extensions.Logging;
using PIPTWeb.Shared.Data;

namespace PIPTWeb.Server.Logging
{
    public class PIPTWebLoggerProvider : ILoggerProvider
    {
        private readonly PIPTDbContext _dbContext;

        public PIPTWebLoggerProvider()
        {

        }
        public PIPTWebLoggerProvider(PIPTDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new PIPTWebLogger(_dbContext);
        }

        public void Dispose()
        {
            
        }
    }
}
