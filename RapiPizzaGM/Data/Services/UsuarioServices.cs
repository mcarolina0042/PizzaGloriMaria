using Microsoft.EntityFrameworkCore;
using RapiPizzaGM.Data.Context;
using RapiPizzaGM.Data.Models;
using RapiPizzaGM.Data.Request;
using RapiPizzaGM.Data.Response;

namespace RapiPizzaGM.Data.Services
{
	public class Res
	{
		public bool Success { get; set; }
		public string? Message { get; set; }

	}
	public class Res<T>
	{
		public bool Success { get; set; }
		public string? Message { get; set; }
		public T? Data { get; set; }
	}
	public class UsuarioServices : IUsuarioServices
	{
		private readonly IRapiPizzaDbContext dbContext;

		public UsuarioServices(IRapiPizzaDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<Res> Crear(UsuarioRequest request)
		{
			try
			{
				var usuario = Usuario.Crear(request);
				dbContext.Usuarios.Add(usuario);
				await dbContext.SaveChangesAsync();
				return new Res() { Message = "OK", Success = true };
			}

			catch (Exception E)
			{
				return new Res() { Message = E.Message, Success = false };
			}
		}


		public async Task<Res> Modificar(UsuarioRequest request)
		{
			try
			{
				var usuario = await dbContext.Usuarios.FirstOrDefaultAsync(d => d.Id == request.Id);
				if (usuario == null)
					return new Res() { Message = "No Se Encontro El Cliente ", Success = false };

				if (usuario.Modificar(request))
					await dbContext.SaveChangesAsync();

				return new Res() { Message = "OK", Success = true };
			}

			catch (Exception E)
			{
				return new Res() { Message = E.Message, Success = false };
			}
		}

		public async Task<Res> Eliminar(UsuarioRequest request)
		{
			try
			{
				var usuario = await dbContext.Usuarios.FirstOrDefaultAsync(d => d.Id == request.Id);
				if (usuario == null)
					return new Res() { Message = "No Se Encontro el Usuario ", Success = false };

				dbContext.Usuarios.Remove(usuario);
				await dbContext.SaveChangesAsync();

				return new Res() { Message = "OK", Success = true };
			}

			catch (Exception E)
			{
				return new Res() { Message = E.Message, Success = false };
			}
		}

		public async Task<Res<List<UsuarioResponse>>> Consultar(string filtro)
		{
			try
			{
				var usuario = await dbContext.Usuarios
					.Where(d =>
						(d.Nombre + " " + d.Email + " " + d.Contraseña + " " + d.Sexo)
						.ToLower()
						.Contains(filtro.ToLower()
						)
					)
					.Select(d => d.ToResponse())
					.ToListAsync();
				return new Res<List<UsuarioResponse>>()
				{
					Message = "Ok",
					Success = true,
					Data = usuario

				};
			}
			catch (Exception E)
			{
				return new Res<List<UsuarioResponse>>
				{
					Message = E.Message,
					Success = false
				};
			}
		}

	}
}

