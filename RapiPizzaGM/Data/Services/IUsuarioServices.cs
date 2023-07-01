using RapiPizzaGM.Data.Request;
using RapiPizzaGM.Data.Response;

namespace RapiPizzaGM.Data.Services
{
	public interface IUsuarioServices
	{
		Task<Res<List<UsuarioResponse>>> Consultar(string filtro);
		Task<Res> Crear(UsuarioRequest request);
		Task<Res> Eliminar(UsuarioRequest request);
		Task<Res> Modificar(UsuarioRequest request);
	}
}