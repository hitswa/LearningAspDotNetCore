
using System.Text.RegularExpressions;

namespace WebApplication1;

public class MonthConstraint : IRouteConstraint
{
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        if( values.ContainsKey(routeKey) ) {
            return false;
        }

        Regex regex = new Regex($"^(jan|feb|mar|jun|jul|aug|sep|oct|nov|dec)$");
        
        string? monthValue = Convert.ToString(values[routeKey]);

        if( regex.IsMatch(monthValue)) {
            return true;
        }
        return false;
    }
}
