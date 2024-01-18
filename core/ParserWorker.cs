using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot_tg.core
{
    internal class ParserWorker <T> where T : class
    {
        Iparser<T> parser;
        Iparsersettings parserSettings;

        HtmlLoader loader;

        bool isActive;

        #region Properties

        public Iparser<T> Parser
        {
            get
            {
                return parser;
            }
            set 
            { 
                parser = value;
            }
        }
        
        public Iparsersettings Settings
        {
            get 
            { 
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }
        
        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }
        #endregion

        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;
        public ParserWorker(Iparser<T> parser)
        {
            this.parser = parser;
        }
    
        public ParserWorker(Iparser<T> parser,Iparsersettings parserSetings) : this (parser)
        {
            this.parserSettings = parserSetings;
        }
    
    public void Start()
        {
            isActive = true;
            Worker();
        }
    
        public void Abort()
        {
            isActive = false;
        }
    private async void Worker()
        {
            for(int i = parserSettings.StartPoint; i <= parserSettings.EndPoint; i++)
            {
                if(isActive)
                {
                    OnCompleted?.Invoke(this);
                    return;
                }
            var source = await loader.GetSourceByPageld(i);
            var domParser = new HtmlParser();

            var document = await domParser.ParseDocumentAsync(source);
            
            var result = parser.Parse(document);
           
            OnNewData?.Invoke(this, result);
            }
            OnCompleted?.Invoke(this);
            isActive = false;
        }    
    }
}
