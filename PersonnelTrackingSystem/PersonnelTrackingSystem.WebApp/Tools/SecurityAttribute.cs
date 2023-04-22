using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PersonnelTrackingSystem.WebApp.Tools
{
    public class SecurityAttribute : AuthorizeAttribute
    {
        // Set default Unauthorized Page Url here
        private string _notifyUrl = "/Error/Unauthorized";

        public string NotifyUrl
        {
            get { return _notifyUrl; }
            set { _notifyUrl = value; }
        }

        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    if (filterContext == null)
        //    {
        //        throw new ArgumentNullException("filterContext");
        //    }

        //    if (AuthorizeCore(filterContext.HttpContext))
        //    {
        //        HttpCachePolicyBase cachePolicy =
        //            filterContext.HttpContext.Response.Cache;
        //        cachePolicy.SetProxyMaxAge(new TimeSpan(0));
        //        cachePolicy.AddValidationCallback(CacheValidateHandler, null);
        //    }

        //    /// This code added to support custom Unauthorized pages.
        //    else if (filterContext.HttpContext.User.Identity.IsAuthenticated)
        //    {
        //        if (NotifyUrl != null)
        //            filterContext.Result = new RedirectResult(NotifyUrl);
        //        else
        //            // Redirect to Login page.
        //            HandleUnauthorizedRequest(filterContext);
        //    }
        //    /// End of additional code
        //    else
        //    {
        //        // Redirect to Login page.
        //        HandleUnauthorizedRequest(filterContext);
        //    }
        //}
    }
}
