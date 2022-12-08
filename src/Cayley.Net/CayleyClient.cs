using System;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Schema;
using Cayley.Net.ApiModels;
using Cayley.Net.Dsl.Gizmo;
using Cayley.Net.Extensions;
using Newtonsoft.Json;

namespace Cayley.Net
{
    public class CayleyClient : ICayleyClient
    {
        private const string QUERY_PATH = "/api/v1/query/gizmo";
        private const string URL_TEMPLATE = "{0}://{1}:{2}" + QUERY_PATH;

        private readonly Uri QueryUrl;

        public CayleyClient(string basePath)
        {
            QueryUrl = new Uri(basePath + QUERY_PATH);
        }

        public CayleyClient(string server, int port, bool useHttps = false)
        {
            var sProt = useHttps ? "https" : "http";
            QueryUrl = new Uri(string.Format(URL_TEMPLATE, sProt, server, port));
        }


        public Task<CayleyResponse> Send(IGremlinQuery query)
        {
            string queryText = query.Build();
            return Send(queryText);
        }

        public async Task<CayleyResponse> Send(string query)
        {
            HttpClient client = new HttpClient();
            var content = new StringContent(query);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var response = await client.PostAsync(QueryUrl, content);
            var sData = response.Content.ReadAsString();
            try
            {
                return new CayleyResponse()
                {
                    Content = JsonConvert.DeserializeObject<CayleyObjectResponseContent>(sData),
                };
            }
            catch(ArgumentException)
            {
                return new CayleyResponse()
                {
                    Mixed = JsonConvert.DeserializeObject<CayleyMixedResponseContent>(sData),
                };
            }
        }
    }
}