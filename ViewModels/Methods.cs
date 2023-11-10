using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AIS_LAB.ViewModels
{
    public class Methods
    {
        private string url = "https://api.vk.com/method/{0}&access_token={1}&v=5.81";
        private string accesToken = ConfigurationManager.AppSettings.Get("AccessToken");
        public async Task<string> GET(string Url, string Method, string Token)
        {
            WebRequest req = WebRequest.Create(String.Format(Url, Method, Token));
            WebResponse resp = await req.GetResponseAsync();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            return Out;
        }
        public async Task<string> GET(string Method)
        {
            WebRequest req = WebRequest.Create(String.Format(url, Method, accesToken));
            WebResponse resp = await req.GetResponseAsync();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            return Out;
        }
    }
}
