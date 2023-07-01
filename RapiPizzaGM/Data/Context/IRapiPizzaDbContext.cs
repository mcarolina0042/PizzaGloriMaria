using Microsoft.EntityFrameworkCore;
using RapiPizzaGM.Data.Models;

namespace RapiPizzaGM.Data.Context
{
	public interface IRapiPizzaDbContext
	{
		public DbSet<Clientes> Clientes { get; set; }
		public DbSet<Factura> Facturas { get; set; }
		public DbSet<Pizza> Pizzas { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }

		public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}