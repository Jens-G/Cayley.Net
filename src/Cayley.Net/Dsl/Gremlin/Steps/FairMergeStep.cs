namespace Cayley.Net.Dsl.Gizmo.Steps
{
    public static class FairMergeStep
    {
        public static IGremlinQuery FairMerge(this IGremlinQuery query)
        {
            IGremlinQuery newQuery = query.AddBlock(".fairMerge");
            return newQuery;
        }
    }
}