using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Helpers
{
    public class LanguageCatcher
    {
        private readonly IHttpContextAccessor _http;

        public LanguageCatcher(IHttpContextAccessor http)
        {
            _http = http;
        }

        public string GetLanguage()
        {
            var lang = _http.HttpContext?.Request.Headers["Accepted-Language"].FirstOrDefault()?.ToLower() ?? "en";

            var supportedLanguages = new[] { "en", "ru", "az" };
            if (!supportedLanguages.Contains(lang))
            {
                lang = "en";
            }

            return lang;
        }
    }
}
