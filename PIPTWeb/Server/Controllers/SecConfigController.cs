using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIPTWeb.Shared.Data;
using PIPTWeb.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIPTWeb.Server.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SecConfigController : ControllerBase
    {
        private readonly PIPTDbContext _dbContext;
        public SecConfigController(PIPTDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("GetByCustomerId")]
        public async Task<List<SecConfig>> GetConfigByCustomerId([FromQuery] int CustomerId)
        {
            var config = await _dbContext.SecConfig.Where(x => x.CustomerId == CustomerId).ToListAsync();
            return config;
        }
    }
}
