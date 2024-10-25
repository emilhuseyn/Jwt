using App.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Helpers
{
    public static class EnumExtensions
    {
        public static string EnumToString(this Enum enumType)
        {
            return enumType switch
            {
                ELanguage.AZ => "AZ",
                ELanguage.EN => "EN",
                ELanguage.RU => "RU",
                _ => throw new ArgumentOutOfRangeException(nameof(enumType), enumType, null)
            };
        }
    }
}
