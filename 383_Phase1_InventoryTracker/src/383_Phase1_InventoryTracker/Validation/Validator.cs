using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _383_Phase1_InventoryTracker.Validation
{
    public static class Validator
    {
       
        public static async Task ValidateAsync(CookieValidatePrincipalContext context)
        {
            var userPrincipal = context.Principal;

            await context.HttpContext.Authentication.SignOutAsync("MyCookieMiddlewareInstance");

        }

        //public static void OnAuthorization(Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext context)
        //{
        //    var nop = Task.CompletedTask;
        //    var userPrincipal = context.HttpContext.User;
        //    //return false;

        //}
    }

}
