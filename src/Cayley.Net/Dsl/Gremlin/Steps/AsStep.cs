namespace Cayley.Net.Dsl.Gizmo.Steps
{
    public static class AsStep
    {
        public static IGremlinQuery As(this IGremlinQuery query, string label)
        {
            IGremlinQuery newQuery = query.AddBlock(".as({0})", label);
            return newQuery;
        }
    }
}