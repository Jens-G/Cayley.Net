namespace Cayley.Net.Dsl.Gizmo.Steps
{
    public static class ExhaustMergeStep
    {
        public static IGremlinQuery ExhaustMerge(this IGremlinQuery query)
        {
            IGremlinQuery newQuery = query.AddBlock(".exhaustMerge");
            return newQuery;
        }
    }
}