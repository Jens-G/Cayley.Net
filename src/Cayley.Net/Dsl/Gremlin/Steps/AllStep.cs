namespace Cayley.Net.Dsl.Gizmo.Steps
{
    public static class AllStep
    {
        private const string ALL = ".all()";

        public static IGremlinQuery All(this IGremlinQuery query)
        {
            IGremlinQuery newQuery = query.AddBlock(ALL);
            return newQuery;
        }
    }
}