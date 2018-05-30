using Domain.Concrete;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace Diplom.HtmlHelpers
{
    public static class IdentityExtensions
    {
        public static int GetUserId(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            int ID = 0;
            if (ci != null)
            {
                var id = ci.FindFirst(ClaimTypes.NameIdentifier);
                if (id != null)
                {
                    ID = int.Parse(id.Value);
                }
            }
            return ID;
        }

        public static string GetUserRole(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            string role = "";
            if (ci != null)
            {
                var id = ci.FindFirst(ClaimsIdentity.DefaultRoleClaimType);
                if (id != null)
                    role = id.Value;
            }
            return role;
        }

        public static string GetUserImageName(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            string imageName = "";
            if (ci != null)
            {
                var id = ci.FindFirst(ClaimTypes.GivenName);
                if (id != null)
                    imageName = id.Value;
            }
            return imageName;
        }
    }
}