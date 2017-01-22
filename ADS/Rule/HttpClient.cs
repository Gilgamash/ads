using System.IO;
using System.Net;
using System.Text;

namespace ADS.Rule
{
    public class HttpClient
    {
        public static string Get(string url, int timeout = 30000)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "Get";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Timeout = timeout;
            var response = request.GetResponse() as HttpWebResponse;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }
    }
}