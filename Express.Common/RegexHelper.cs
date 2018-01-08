using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Express.Common
{
    using System.Text.RegularExpressions;
    public static class RegexHelper
    {
        public static bool IsNumber(this string input)
        {
            Regex reg = new Regex(@"^\d+$");
            return reg.IsMatch(input);
        }
    }
}
