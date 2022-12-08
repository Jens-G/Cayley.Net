namespace Cayley.Net.Dsl.Gizmo.Steps
{
    public static class StoreStep
    {
        public static IGremlinQuery Save(this IGremlinQuery query, string predicate, string variable)
        {
            IGremlinQuery newQuery = query.AddBlock(string.Format(".save(\"{0}\",\"{1}\")", predicate, variable));
            return newQuery;
        }
    }
}