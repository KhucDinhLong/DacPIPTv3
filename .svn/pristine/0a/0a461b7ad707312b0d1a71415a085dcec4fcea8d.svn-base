using System.Web;

namespace PIPT.API.Core
{
    public class SessionHeper
    {
        public static void SetSession(UserSession session)
        {
            HttpContext.Current.Session["loginSession"] = session;
        }

        public static UserSession GetSession()
        {
            var session = HttpContext.Current.Session["loginSession"];
            if(session == null)
            {
                return null;
            }
            else
            {
                return session as UserSession;
            }
        }
    }
}