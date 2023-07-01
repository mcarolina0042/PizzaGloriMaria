using RapiPizzaGM.Data.Request;

namespace RapiPizzaGM.Data.Response
{
	public class UsuarioResponse
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = null!;


		public string Email { get; set; } = null!;
		public string Contraseña { get; set; } = null!;


		public string Sexo { get; set; } = null!;

		public UsuarioRequest ToRequest()
		{
			return new UsuarioRequest
			{
				Id = Id,
				Nombre = Nombre,
				Email = Email,
				Contraseña = Contraseña,
				Sexo = Sexo

			};

		}
	}
}
