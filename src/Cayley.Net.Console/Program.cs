﻿using Cayley.Net.ApiModels;
using Cayley.Net.Dsl;
using Cayley.Net.Dsl.Gizmo;
using Cayley.Net.Dsl.Gizmo.Steps;

namespace Cayley.Net.Console
{
    public class Program
    {
        private static async Task Main()
        {
            ICayleyClient client = new CayleyClient("http://localhost:64210/api/v1/query/gizmo");
            IGraphObject g = new GraphObject();

            IGremlinQuery query = g.V().Has("name", "Casablanca")
                .Out("/film/film/starring")
                .Out("/film/performance/actor")
                .Out("name")
                .All();
            CayleyResponse response = await client.Send(query);
            System.Console.WriteLine(response.Content);

            System.Console.WriteLine("--------------------------------------------------------------------------------");

            var filmToActor = g.Morphism().Out("/film/film/starring").Out("/film/performance/actor");
            IGremlinQuery queryWithMorphism = g.V()
                .Has("name", "Casablanca")
                .Follow(filmToActor)
                .Out("name")
                .All();
            CayleyResponse morpResponse = await client.Send(queryWithMorphism);
            System.Console.WriteLine(morpResponse.Content);

            System.Console.WriteLine("--------------------------------------------------------------------------------");

            string emitQuery = g.Emit(new {name = "John Doe", age = 25, hasRoom = true});
            CayleyResponse emitResponse = await client.Send(emitQuery);
            System.Console.WriteLine(emitResponse.Content);
            System.Console.ReadLine();
        }
    }
}
