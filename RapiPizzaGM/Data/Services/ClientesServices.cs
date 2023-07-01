using Microsoft.EntityFrameworkCore;
using RapiPizzaGM.Data.Context;
using RapiPizzaGM.Data.Models;
using RapiPizzaGM.Data.Request;
using RapiPizzaGM.Data.Response;


namespace RapiPizzaGM.Data.Services
{
	public class Results
	{
		public bool Success { get; set; }
		public string? Message { get; set; }

	}
	public class Results<T>
	{
		public bool Success { get; set; }
		public string? Message { get; set; }
		public T? Data { get; set; }
	}
    public class ClientesServices : IClientesServices
    {

        private readonly IRapiPizzaDbContext dbContext;

        public ClientesServices(IRapiPizzaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Results> Crear(ClientesRequest request)
        {
            try
            {
                var cliente = Clientes.Crear(request);
                dbContext.Clientes.Add(cliente);
                await dbContext.SaveChangesAsync();
                return new Results() { Message = "OK", Success = true };
            }

            catch (Exception E)
            {
                return new Results() { Message = E.Message, Success = false };
            }
        }


        public async Task<Results> Modificar(ClientesRequest request)
        {
            try
            {
                var cliente = await dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (cliente == null)
                    return new Results() { Message = "No Se Encontro El Cliente ", Success = false };

                if (cliente.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Results() { Message = "OK", Success = true };
            }

            catch (Exception E)
            {
                return new Results() { Message = E.Message, Success = false };
            }
        }



        public async Task<Results> Eliminar(ClientesRequest request)
        {
            try
            {
                var cliente = await dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (cliente == null)
                    return new Results() { Message = "No Se Encontro El Cliente", Success = false };

                dbContext.Clientes.Remove(cliente);
                await dbContext.SaveChangesAsync();

                return new Results() { Message = "OK", Success = true };
            }
            catch (Exception E)
            {
                return new Results() { Message = E.Message, Success = false };
            }
        }


        public async Task<Results<List<ClientesResponse>>> Consultar(string filtro)
        {
            try
            {
                var clientes = await dbContext.Clientes
                    .Where(c =>
                        (c.Nombre)
                        .ToLower()
                        .Contains(filtro.ToLower()
                        )
                    )
                    .Select(c => c.ToResponse())
                    .ToListAsync();
                return new Results<List<ClientesResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = clientes
                };
            }
            catch (Exception E)
            {
                return new Results<List<ClientesResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }

    }

}
