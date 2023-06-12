using System.Security.Claims;

namespace TVRS.WebUI.Extensions
{
    public static class HttpContextExtensions
    {
        public static int GetUserId(this HttpContext httpContext)
        {
            var userIdString = httpContext.User.FindFirstValue("Id");
            int userId;
            if (!int.TryParse(userIdString, out userId))
            {
                throw new Exception("Geçersiz UserId");
            }
            return userId;
        }
    }
}
