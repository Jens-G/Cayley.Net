namespace Cayley.Net.Dsl.Gizmo.Steps
{
    public static class BackStep
    {
        public static IGremlinQuery BackV(this IGremlinQuery query, string label)
        {
            IGremlinQuery newQuery = query.AddBlock(".back({0})", label);
            return newQuery;
        }
    }
}