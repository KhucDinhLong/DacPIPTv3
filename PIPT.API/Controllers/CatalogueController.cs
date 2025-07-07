using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PIPT.API.Controllers
{
    [Authorize]
    public class CatalogueController : ApiController
    {
        DAC.Core.DacProductCategoryCS CategoryCS = new DAC.Core.DacProductCategoryCS();
        // GET: api/Product
        [AllowAnonymous]
        public DAC.Core.DacProductCatalogueCollection Get()
        {
            return CategoryCS.GetListCategory();
        }
        // GET: api/Product/5
        [AllowAnonymous]
        public DAC.Core.DacProductCatalogueCollection Get(int Id)
        {
            return CategoryCS.GetListCategory(Id);
        }
    }
}
