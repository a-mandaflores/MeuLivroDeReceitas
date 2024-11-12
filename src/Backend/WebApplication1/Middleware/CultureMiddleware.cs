using System.Globalization;

namespace MyRecipeBook.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;

        }
        public async Task Invoke(HttpContext context)
        {
            var suportedLanguage = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var requestCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            var cultureInfo = new CultureInfo("en");

            if(string.IsNullOrWhiteSpace(requestCulture) == false 
                && suportedLanguage.Any(c => c.Name.Equals(requestCulture)))
            {
                cultureInfo = new CultureInfo(requestCulture);
            }

            CultureInfo.CurrentCulture =
            CultureInfo.CurrentUICulture = cultureInfo;

            await _next(context);
        }
    }
}
