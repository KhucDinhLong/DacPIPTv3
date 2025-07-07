using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PIPTWeb.Shared.Data;
using PIPTWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIPTWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PIPTBaseController : ControllerBase
    {
        private readonly PIPTDbContext _dbContext;
        private readonly UserManager<SecUsers> _userManager;
        public PIPTBaseController(PIPTDbContext dbContext, UserManager<SecUsers> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        protected async Task Log(DacLogBook logBook)
        {
            var user = _userManager.Users.FirstOrDefault();
            if (user != null)
            {
                logBook.UserName = user.UserName;
                if (user.AgencyId.HasValue)
                {
                    var Customer = _dbContext.Customers.FirstOrDefault(x => x.Id == user.AgencyId.Value);
                    if (Customer != null)
                    {
                        logBook.CustomerId = Customer.Id;
                    }
                }
            }
            _dbContext.DacLogBook.Add(logBook);
            await _dbContext.SaveChangesAsync();
        }
    }
}

