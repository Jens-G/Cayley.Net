namespace Cayley.Net.Dsl.Gizmo.Steps
{
    public static class GremlinDistinctStep
    {
        public static IGremlinQuery GremlinDistinct(this IGremlinQuery query)
        {
            IGremlinQuery newQuery = query.AddBlock(".dedup()");
            return newQuery;
        }
    }
}