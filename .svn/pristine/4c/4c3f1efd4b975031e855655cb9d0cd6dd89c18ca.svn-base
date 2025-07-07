using DAC.Core;
using System.Web.Http;

namespace PIPT.API.Controllers
{
    [Authorize]
    public class AgencyController : ApiController
    {
        DacAgencyCS agencyCS = new DacAgencyCS();
        
        [AllowAnonymous]
        // GET: api/Agency?Code={Code}
        public DacAgencyCollection Get(string Code)
        {
            return agencyCS.GetListAgency(Code, string.Empty, string.Empty);
        }
        [HttpGet]
        [AllowAnonymous]
        // GET: api/Agency?DacCode={DacCode}
        public DAC.Core.Models.AgencyTrackViewModel AgencyTrack(string DacCode)
        {
            return agencyCS.GetAgencyTrack(DacCode);
        }
    }
}
