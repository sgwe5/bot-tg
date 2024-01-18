

using AngleSharp.Dom.Events;

namespace bot_tg.core.strike
{
    internal class strikesettings : Iparsersettings
    {
        public string BaseUrl { get; set; } = "https://1win.com.ci/casino/play/1play_1play_luckyjet";

        public string Prefix { get; set; } = "page{CurrentId}";
        
        public int StartPoint { get; set; }
        
        public int EndPoint { get; set; }
        
    }
}
