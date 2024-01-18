
using AngleSharp.Html.Dom;

namespace bot_tg.core
{
    interface Iparser <T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
