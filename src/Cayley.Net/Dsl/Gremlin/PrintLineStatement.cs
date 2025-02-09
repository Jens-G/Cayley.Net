namespace Cayley.Net.Dsl.Gizmo
{
    public static class PrintLineStatement
    {
        public static IGremlinQuery PrintLine(this IGremlinQuery query, string value)
        {
            IGremlinQuery newQuery = query.AddBlock(string.Format("println {0}", value));
            return newQuery;
        }
    }
}