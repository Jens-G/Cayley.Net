using System;
using System.Linq.Expressions;

namespace Cayley.Net.Dsl.Gizmo
{
    internal class TypeFilter
    {
        public ExpressionType ExpressionType { get; set; }
        public Type Type { get; set; }
        public string FilterFormat { get; set; }
    }
}