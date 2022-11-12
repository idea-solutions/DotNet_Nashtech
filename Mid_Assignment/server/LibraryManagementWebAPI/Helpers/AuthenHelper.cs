using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementWebAPI.Helpers
{
    public static class AuthenHelper
    {
        public static int? GetCurrentLoginUserId(this ControllerBase controller)
        {
            if (controller.HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var userIdString = identity?.FindFirst("Id")?.Value;

                if (string.IsNullOrWhiteSpace(userIdString))
                    return null;

                return Int32.Parse(userIdString);
            }
            else
            {
                return null;
            }
        }
    }
}