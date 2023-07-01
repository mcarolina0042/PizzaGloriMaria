using RapiPizzaGM.Data.Request;
using RapiPizzaGM.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace RapiPizzaGM.Data.Models
{
	public class Clientes
	{
		[Key]
		public int Id { get; set; }
		public string Nombre { get; set; } = null!;


		public static Clientes Crear(ClientesRequest cliente)
		=> new Clientes()
		{
			Nombre = cliente.Nombre,
		};
		public bool Modificar(ClientesRequest cliente)
		{
			var cambio = false;
			if (Nombre != cliente.Nombre)
			{
				Nombre = cliente.Nombre;
				cambio = true;
			}
			return cambio;
		}

		public ClientesResponse ToResponse()
		{
			return new ClientesResponse
			{
				Id=Id,
				Nombre = Nombre,
			};

		}
	}
}
