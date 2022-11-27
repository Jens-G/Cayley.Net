namespace Cayley.Net.Dsl.Gizmo.Steps
{
    public static class HasNextStep
    {
        public static IGremlinQuery GremlinHasNext(this IGremlinQuery query)
        {
            IGremlinQuery newQuery = query.AddBlock(".hasNext()");
            return newQuery;
        }
    }
}