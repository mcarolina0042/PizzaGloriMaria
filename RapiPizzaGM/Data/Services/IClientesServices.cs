using RapiPizzaGM.Data.Request;
using RapiPizzaGM.Data.Response;

namespace RapiPizzaGM.Data.Services
{
    public interface IClientesServices
    {
        Task<Results<List<ClientesResponse>>> Consultar(string filtro);
        Task<Results> Crear(ClientesRequest request);
        Task<Results> Eliminar(ClientesRequest request);
        Task<Results> Modificar(ClientesRequest request);
    }
}