using System.Collections.Generic;

namespace Cayley.Net.Dsl.Gizmo
{
    public class IdentityPipe : IGremlinQuery
    {
        private readonly IList<string> _queryDeclarations = new List<string>();
        private readonly IDictionary<string, object> _queryParameters = new Dictionary<string, object>();

        public string QueryText
        {
            get { return "_()"; }
        }

        public IDictionary<string, object> QueryParameters
        {
            get { return _queryParameters; }
        }

        public IList<string> QueryDeclarations
        {
            get { return _queryDeclarations; }
        }
    }
}