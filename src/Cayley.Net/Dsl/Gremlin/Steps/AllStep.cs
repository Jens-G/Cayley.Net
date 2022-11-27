namespace Cayley.Net.Dsl.Gizmo.Steps
{
    public static class AllStep
    {
        public static IGremlinQuery All(this IGremlinQuery query)
        {
            IGremlinQuery newQuery = query.AddBlock(".all()");
            return newQuery;
        }
    }
}