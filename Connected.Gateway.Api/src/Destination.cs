using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Connected.Gateway.Api
{
    public class Destination
    {
        public string Uri { get; set; }

        public bool RequestAuthentication { get; set; }

        private static HttpClient client = new HttpClient();

        public Destination(string uri, bool requestAuthentication)
        {
            Uri = uri;
            RequestAuthentication = requestAuthentication;
        }

        public Destination(string uri) : this(uri, false)
        {
        }

        private Destination()
        {
            Uri = "/";
            RequestAuthentication = false;
        }

        public async Task<HttpResponseMessage> SendRequest(HttpRequest request)
        {
            string requestContent;
            using (Stream receiveStream = request.Body)
            {
                using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    requestContent = readStream.ReadToEnd();
                }
            }

            using (var newRequest = new HttpRequestMessage(new HttpMethod(request.Method), CreateDestinationUri(request)))
            {
                newRequest.Content = new StringContent(requestContent, Encoding.UTF8, request.ContentType);
                var respone = await client.SendAsync(newRequest);

                return respone;
            }
        }

        private string CreateDestinationUri(HttpRequest request)
        {
            var requestPath = request.Path.ToString();
            var queryString = request.QueryString.ToString();

            var endpoint = string.Empty;
            var endpointSplit = requestPath.Substring(1).Split("/");

            if (endpointSplit.Length > 1)
            {
                endpoint = endpointSplit[2];
            }

            return Uri + endpoint + queryString;
        }
    }
}
