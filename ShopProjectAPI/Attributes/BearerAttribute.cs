using Microsoft.AspNetCore.Mvc.Filters;

namespace ShopProjectAPI.Attributes
{
    public class BearerAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var header = context.HttpContext.Request.Headers.Authorization;
            if (header.ToString() == "") throw new Exception("Brak nagłówka autoryzacyjnego.");

            var splittedHeader = header.ToString().Split(" ");
            if (splittedHeader.Length != 2) throw new Exception("Źle skonstruowany nagłówek autoryzacyjny.");

            var bearerAuth = splittedHeader[0];
            var serverAuth = splittedHeader[1];

            if (bearerAuth != "Bearer") throw new Exception("Błąd autoryzacji.");
            if (serverAuth != "ServerAuth") throw new Exception("Błąd autoryzacji.");
        }
    }
}
