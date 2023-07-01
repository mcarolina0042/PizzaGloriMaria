using RapiPizzaGM.Data.Request;

namespace RapiPizzaGM.Data.Response
{
	public class ClientesResponse
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = null!;

		public ClientesRequest ToRequest() 
		{
			return new ClientesRequest
			{
				Id = Id,
				Nombre = Nombre
			};

		}
	}
}
