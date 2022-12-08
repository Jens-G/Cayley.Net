using System.Collections.Generic;
using System.Dynamic;

#pragma warning disable IDE1006  // naming convemtion

namespace Cayley.Net.ApiModels
{
    public class CayleyObjectResponseContent
    {
        public List<ExpandoObject> result { get; set; }
    }

    public class CayleyMixedResponseContent
    {
        public List<object> result { get; set; }
    }

    public class CayleyResponse
    {
        public CayleyObjectResponseContent Content { get; set; }
        public CayleyMixedResponseContent Mixed { get; set; }
    }
}