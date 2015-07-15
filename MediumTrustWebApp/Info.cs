using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MediumTrustWebApp
{
    public static class Info
    {
        public static string PrintInfoAboutDomainAndAssemblies()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("---");
            var appDomain = AppDomain.CurrentDomain;
            sb.AppendFormat("AppDomain: {0} | Is Full Trusted: {1}<br/>\n", appDomain.FriendlyName, appDomain.IsFullyTrusted);
            var assems = appDomain.GetAssemblies();
            if (assems.Length == 0) sb.AppendFormat("No assemblies loaded in this domain<br/>\n");
            else
            {
                sb.AppendFormat("{0} assemblies loaded:<br/>\n", assems.Length);
                sb.Append("<table cellspacing=\"0\" cellpadding=\"0\"><tr><td>Assembly</td><td>Full Trusted</td></tr>");
                
                foreach (var a in assems.OrderBy(item => item.FullName).ToList())
                {
                    sb.Append("<tr>");
                    var assemblySimpleName = new AssemblyName(a.FullName).Name;
                    sb.AppendFormat("<td>" + assemblySimpleName + "</td>");
                    sb.AppendFormat("<td>" + a.IsFullyTrusted + "</td>");
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                var mi = MethodBase.GetCurrentMethod(); ;
                var codeLayer = mi.IsSecurityTransparent ? "Transparent" : "Critical";
                sb.AppendFormat("--- Current method: {0} layer<br/>\n", codeLayer);
            }
            return sb.ToString();
        }
    }
}
