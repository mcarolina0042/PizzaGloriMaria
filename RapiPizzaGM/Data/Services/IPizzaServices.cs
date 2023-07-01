using RapiPizzaGM.Data.Request;
using RapiPizzaGM.Data.Response;

namespace RapiPizzaGM.Data.Services
{
	public interface IPizzaServices
	{
		Task<Resu<List<PizzaResponse>>> Consultar(string filtro);
		Task<Resu> Crear(PizzaRequest request);
		Task<Resu> Eliminar(PizzaRequest request);
		Task<Resu> Modificar(PizzaRequest request);
	}
}