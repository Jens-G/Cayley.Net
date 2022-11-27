using System.Linq.Expressions;

namespace Cayley.Net.Dsl.Gizmo
{
    public struct Filter
    {
        public string PropertyName { get; set; }
        public object Value { get; set; }
        public ExpressionType? ExpressionType { get; set; }
    }
}