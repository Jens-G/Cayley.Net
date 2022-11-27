using System.Collections.Generic;

namespace Cayley.Net.Dsl.Gizmo
{
    internal struct FormattedFilter
    {
        public string FilterText { get; set; }
        public IDictionary<string, object> FilterParameters { get; set; }
    }
}