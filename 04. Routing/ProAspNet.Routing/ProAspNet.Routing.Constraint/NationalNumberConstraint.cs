
using System.Text.RegularExpressions;
using Zamin.Utilities.Extensions;

namespace ProAspNet.Routing.Constraint
{
    public class NationalNumberConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string value = values[routeKey] as string ?? string.Empty;
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            return value.IsNationalCode();

        }


        //public bool IsNationalCode(string nationalCode)
        //{
        //    if (string.IsNullOrWhiteSpace(nationalCode) || IsLengthBetween(nationalCode, 8, 10))
        //        return false;

        //    nationalCode = nationalCode.PadLeft(10, '0');

        //    if (!IsNumeric(nationalCode))
        //        return false;

        //    if (!IsFormat1Validate(nationalCode))
        //        return false;

        //    if (!IsFormat2Validate(nationalCode))
        //        return false;
        //    return true;

        //    static bool IsFormat1Validate(string nationalCode)
        //    {
        //        var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
        //        if (!allDigitEqual.Contains(nationalCode))
        //            return true;
        //        return false;
        //    }

        //    static bool IsFormat2Validate(string nationalCode)
        //    {
        //        var chArray = nationalCode.ToCharArray();
        //        var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
        //        var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
        //        var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
        //        var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
        //        var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
        //        var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
        //        var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
        //        var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
        //        var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
        //        var a = Convert.ToInt32(chArray[9].ToString());

        //        var b = num0 + num2 + num3 + num4 + num5 + num6 + num7 + num8 + num9;
        //        var c = b % 11;

        //        var result = c < 2 && a == c || c >= 2 && 11 - c == a;
        //        if (result)
        //            return true;
        //        return false;
        //    }
        //}

        //public bool IsNumeric(string nationalCode)
        //{
        //    var regex = new Regex(@"\d+");
        //    if (regex.IsMatch(nationalCode))
        //        return true;
        //    return false;
        //}

        //public bool IsLengthBetween(string input, int minLength, int maxLenght)
        //{
        //    if (input.Length <= maxLenght && input.Length >= minLength)
        //        return true;
        //    return false;
        //}


    }
}
