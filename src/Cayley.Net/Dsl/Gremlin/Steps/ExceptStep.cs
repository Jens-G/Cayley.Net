namespace Cayley.Net.Dsl.Gizmo.Steps
{
    public static class ExceptStep
    {
        public static IGremlinQuery ExceptV(this IGremlinQuery query, string variable)
        {
            IGremlinQuery newQuery = query.AddBlock(string.Format(".except({0})", variable));
            return newQuery;
        }
    }
}