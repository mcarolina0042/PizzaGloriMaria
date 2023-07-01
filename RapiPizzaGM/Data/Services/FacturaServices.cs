using Microsoft.EntityFrameworkCore;
using RapiPizzaGM.Data.Context;
using RapiPizzaGM.Data.Models;
using RapiPizzaGM.Data.Request;
using RapiPizzaGM.Data.Response;


namespace RapiPizzaGM.Data.Services
{
	public class Resul
	{
		public bool Success { get; set; }
		public string? Message { get; set; }

	}
	public class Resul<T>
	{
		public bool Success { get; set; }
		public string? Message { get; set; }
		public T? Data { get; set; }
	}
    public class FacturaServices : IFacturaServices
    {

        private readonly IRapiPizzaDbContext dbContext;

        public FacturaServices(IRapiPizzaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Resul> Crear(FacturaRequest request)
        {
            try
            {
                var factura = Factura.Crear(request);
                dbContext.Facturas.Add(factura);
                await dbContext.SaveChangesAsync();
                return new Resul() { Message = "OK", Success = true };
            }

            catch (Exception E)
            {
                return new Resul() { Message = E.Message, Success = false };
            }
        }




        public async Task<Resul<List<FacturaResponse>>> Consultar(string filtro)
        {
            try
            {
                var facturas = await dbContext.Facturas
     .Where(d =>
         (d.ClienteId + " " + d.PizzaId + " " + d.Referencia + " " + d.Extra + " " + d.SubTotal + " " + d.ITBIS + " " + d.Total + " " + d.Cantidad)
         .ToLower()
         .Contains(filtro.ToLower())
     )
     .Select(d => d.ToResponse())
     .ToListAsync();

                return new Resul<List<FacturaResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = facturas
                };
            }
            catch (Exception E)
            {
                return new Resul<List<FacturaResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }


    }
}
