using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Cayley.Net.ApiModels;
using Cayley.Net.Dsl.Gizmo;
using Cayley.Net.Extensions;

namespace Cayley.Net
{
    public class CayleyClient : ICayleyClient
    {
        private readonly string _basePath;

        public CayleyClient(string basePath)
        {
            _basePath = basePath;
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
            var response = await client.PostAsync(_basePath, content);
            return new CayleyResponse()
            {
                Content = response.Content.ReadAsString()
            };
        }
    }
}