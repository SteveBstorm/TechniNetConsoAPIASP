using DemoASPMVC_DAL.Models;
using Newtonsoft.Json;

namespace DemoASPMVC.Tools
{
    public class SessionManager
    {
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor httpContext)
        {
            _session = httpContext.HttpContext.Session;
        }

       

        public User? ConnectedUser
        {
            get { return
                    (string.IsNullOrEmpty(_session.GetString("connectedUser"))) ?
                    null :
                    JsonConvert.DeserializeObject<User>(_session.GetString("connectedUser")); }
            set {
                _session.SetString("connectedUser",JsonConvert.SerializeObject(value));
                }
        }

        public string Token
        {
            get { return _session.GetString("token"); }
            set { _session.SetString("token", value); }
        }

        public void Logout()
        {
            _session.Clear();
        }

    }
   
}
