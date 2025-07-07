using System.Web.Http;

namespace PIPT.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // Remove Xml Formater
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            DAC.DAL.GetDacDbConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DacDBConn"].ConnectionString;

            //var authConfig = new AuthenticationConfiguration();

            //// setup authentication against membership
            //authConfig.AddBasicAuthentication((userName, password) => Membership.ValidateUser(userName, password));

            //config.MessageHandlers.Add(new AuthenticationHandler(authConfig));
        }
    }
}
