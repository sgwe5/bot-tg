using AngleSharp.Html.Dom;
using System.Linq;

namespace bot_tg.core.strike
{
    internal class strikeparser : Iparser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("sc-fbYMXx jRMaON    "));
        
            foreach ( var item in items )
            {
                list.Add(item.TextContent);
            }
        return list.ToArray();
        }
    }
}
