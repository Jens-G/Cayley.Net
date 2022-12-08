using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable IDE1006

namespace Cayley.Net.Write
{
    public class DataQuad
    {
        public string subject { get; set; }
        public string predicate { get; set; }
        
        public string @object { get; set; }
    }
    
    public class LabelledQuad : DataQuad
    {
        public string label { get; set; }
    }

    public class Writer
    {
        private const string URL_TEMPLATE = "{0}://{1}:{2}/api/v1/write";

        private readonly Uri WriterApi;
        private readonly List<DataQuad> Quads = new List<DataQuad>();
        public uint WriteThreshold { get; set; } = 4096;

        public Writer(string server, int port, bool useHttps = false)
        {
            var sProt = useHttps ? "https" : "http";
            WriterApi = new Uri( string.Format( URL_TEMPLATE, sProt, server, port));
        }

        public async Task AppendData(string subject, string predicate, string @object, bool forceFlush = false)
        {
            var quad = new DataQuad()
            {
                subject = subject,
                predicate = predicate,
                @object = @object
            };
            await Append(quad, forceFlush);
        }

        public async Task AppendData(string subject, string predicate, string @object, string label, bool forceFlush = false)
        {
            var quad = new LabelledQuad()
            {
                subject = subject,
                predicate = predicate,
                @object = @object,
                label = label,
            };
            await Append(quad, forceFlush);
        }

        public async Task Append(DataQuad quad, bool forceFlush = false)
        {
            if (string.IsNullOrEmpty(quad.subject))
                throw new ArgumentException("invalid argument", nameof(quad.subject));
            if (string.IsNullOrEmpty(quad.predicate))
                throw new ArgumentException("invalid argument", nameof(quad.predicate));
            if (string.IsNullOrEmpty(quad.@object))
                throw new ArgumentException("invalid argument", nameof(quad.@object));

            Quads.Add(quad);
            if(forceFlush || (Quads.Count >= WriteThreshold))
                await Flush();
        }

        public async Task Flush()
        {
            var sJSON = JsonConvert.SerializeObject(Quads, Formatting.Indented);

            using (var client = new HttpClient())
            {
                var content = new StringContent(sJSON);
                var response = await client.PostAsync(WriterApi, content);
                if (response.IsSuccessStatusCode)
                {
                    Quads.Clear();
                    return;
                }

                throw new Exception(string.Format("Sending data failed: {0} {1}", response.StatusCode, response.Content.ToString()));
            }
        }

    }
}
