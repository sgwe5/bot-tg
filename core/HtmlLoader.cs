using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace bot_tg.core
{
    class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;
        public HtmlLoader(Iparsersettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseUrl}/{settings.Prefix}/";
        }
   public async Task<string> GetSourceByPageld(int id)
        {
            var currentUrl = url.Replace("{CurrentId}", id.ToString());
            var response = await client.GetAsync(currentUrl);

            string source = null;

            if(response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }
            return source;
        }
    }
}
