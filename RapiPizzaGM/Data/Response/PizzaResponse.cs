using RapiPizzaGM.Data.Models;
using RapiPizzaGM.Data.Request;

namespace RapiPizzaGM.Data.Response
{
	public class PizzaResponse
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = null!;


		public string Tamaño { get; set; } = null!;


		public decimal Precio { get; set; }

		public PizzaRequest ToRequest()
		{
			return new PizzaRequest
			{
				Id = Id,
				Nombre = Nombre,
				Tamaño = Tamaño,
				Precio = Precio,
				
			};

		}
	}
}
