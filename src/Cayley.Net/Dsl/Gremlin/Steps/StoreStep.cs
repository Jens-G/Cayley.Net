namespace Cayley.Net.Dsl.Gizmo.Steps
{
    public static class StoreStep
    {
        public static IGremlinQuery StoreV(this IGremlinQuery query, string variable)
        {
            IGremlinQuery newQuery = query.AddBlock(string.Format(".store({0})", variable));
            return newQuery;
        }
    }
}