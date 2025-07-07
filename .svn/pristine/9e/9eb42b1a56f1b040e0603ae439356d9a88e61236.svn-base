using System.Web.Http;


namespace PIPT.API.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        DAC.Core.DacProductCS dacProductCS = new DAC.Core.DacProductCS();
        // GET: api/Product
        [AllowAnonymous]
        public DAC.Core.DacProductCollection Get()
        {
            return dacProductCS.GetListProduct();
        }

        // GET: api/Product/5
        [AllowAnonymous]
        public DAC.Core.DacProductCollection Get(int id)
        {
            return dacProductCS.GetListProduct(id);
        }

        // GET: api/Product?Code=XXX
        [AllowAnonymous]
        public DAC.Core.DacProductCollection Get(string Code)
        {
            if (Code == null)
                Code = string.Empty;
            return dacProductCS.GetListProduct(Code, string.Empty);
        }
    }
}
