using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable IDE1006

namespace Cayley.Net
{
    public class ParsedResponse
    {
        public List<Quad> result { get; set; }
    }

    public class Quad
    {
        public string id { get; set; }
    }
}
