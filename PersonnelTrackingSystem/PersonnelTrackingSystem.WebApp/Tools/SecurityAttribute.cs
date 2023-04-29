using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PersonnelTrackingSystem.WebApp.Tools
{
    public class SecurityAttribute : AuthorizeAttribute
    {
        private string _notifyUrl = "/Error/Unauthorized";

        public string NotifyUrl
        {
            get { return _notifyUrl; }
            set { _notifyUrl = value; }
        }

    }
}
