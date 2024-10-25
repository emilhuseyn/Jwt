using App.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Helpers
{
    public static class LanguageChanger
    {
        public static ELanguage Change(string language)
        {
            return language.ToLower() switch
            {
                "en" => ELanguage.EN,
                "ru" => ELanguage.RU,
                "az" => ELanguage.AZ,
                _ => throw new ArgumentOutOfRangeException(nameof(language), language, null)
            };
        }
    }
}
