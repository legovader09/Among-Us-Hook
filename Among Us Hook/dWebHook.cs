using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Among_Us_Hook
{
    public class dWebHook : IDisposable
    {
        private readonly WebClient dWebClient;
        private static NameValueCollection discordValues = new NameValueCollection();
        public string WebHook { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
        public string AppID { get; set; }

        public dWebHook()
        {
            dWebClient = new WebClient();
        }

        public bool SendMessageAsync(string msgSend)
        {
            try
            {
                discordValues.Add("username", UserName);
                discordValues.Add("avatar_url", ProfilePicture);
                discordValues.Add("content", msgSend);
                discordValues.Add("application_id", AppID);

                dWebClient.UploadValuesAsync(new Uri(WebHook), "POST", discordValues);
                discordValues.Clear(); 
                return true;
            } 
            catch
            {
                discordValues.Clear();
                return false;
            }
        }

        public void Dispose()
        {
            dWebClient.Dispose();
        }
    }
}