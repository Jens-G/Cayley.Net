using Cayley.Net.ApiModels;
using Cayley.Net.Dsl.Gizmo;
using System.Threading.Tasks;

namespace Cayley.Net
{
    public interface ICayleyClient
    {
        Task<CayleyResponse> Send(IGremlinQuery query);
        Task<CayleyResponse> Send(string query);
    }
}