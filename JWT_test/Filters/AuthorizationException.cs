using JWT_test.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JWT_test.Filters
{
    public class AuthorizationException : Attribute, IAuthorizationFilter
    {
        private readonly int[] _userType ;
        public AuthorizationException(params int[] userType)
        {
            _userType= userType;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            var claims = user.Claims.ToList();
            //if else
            var userTypeClaim = claims.FirstOrDefault(c => c.Type == CustomClaimTypes.UserType);
            if (userTypeClaim != null)
            {
                int userType = int.Parse(userTypeClaim.Value);
                if (!_userType.Contains(userType))
                {
                    context.Result = new UnauthorizedObjectResult(new { message = $"User type = {userType} không có quyền" });
                }
            }
            else
            {
                context.Result = new UnauthorizedObjectResult(new { message = $"Không có quyền" });
            }
        }
    }
}
