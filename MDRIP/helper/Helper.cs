using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace MDRIP.helper
{
    public static class Helper
    {
        public static string GetFirstName(this System.Security.Principal.IPrincipal usr)
        {
            var firstNameClaim = ((ClaimsIdentity)usr.Identity).FindFirst("FirstName");
            if (firstNameClaim != null)
            {
                return firstNameClaim.Value;
            }
            return usr.Identity.Name;
        }
    }
}