namespace Cayley.Net.Dsl.Gizmo.Steps
{
    public static class EmitPropertyStep
    {
        public static IGremlinQuery EmitProperty(this IGremlinQuery query,
            string propertyName)
        {
            IGremlinQuery newQuery = query.AddBlock(string.Format(".{0}", propertyName));
            return newQuery;
        }
    }
}