using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentWebTemp.Controllers
{
    [AllowAnonymous, Route("account")]
    public class AccountController : Controller
    {
        /// <summary>
        /// User/Tenant can use a Google account to register an account on the website
        /// </summary>
        /// <returns></returns>
        [Route("google-login")]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [Route("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = result.Principal.Identities.FirstOrDefault()
                               .Claims.Select(claim => new
                               {
                                   claim.Issuer,
                                   claim.OriginalIssuer,
                                   claim.Type,
                                   claim.Value
                               });
            return Json(claims);
        }
    }
}
