namespace Cayley.Net.Dsl.Gizmo.Steps
{
    public static class RetainStep
    {
        public static IGremlinQuery RetainV(this IGremlinQuery query, string variable)
        {
            IGremlinQuery newQuery = query.AddBlock(string.Format(".retain({0})", variable));
            return newQuery;
        }
    }
}