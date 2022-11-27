﻿using Cayley.Net.ApiModels;
using Cayley.Net.Dsl.Gizmo;

namespace Cayley.Net
{
    public interface ICayleyClient
    {
     
        CayleyResponse Send(IGremlinQuery query);
        CayleyResponse Send(string query);
    }
}