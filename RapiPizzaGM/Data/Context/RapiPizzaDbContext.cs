using Microsoft.EntityFrameworkCore;
using RapiPizzaGM.Data.Models;
using System.Runtime.InteropServices;

namespace RapiPizzaGM.Data.Context
{
	public class RapiPizzaDbContext : DbContext, IRapiPizzaDbContext
	{
		private readonly IConfiguration config;

		public RapiPizzaDbContext(IConfiguration Config)
		{
			config = Config;
		}
		public DbSet<Clientes> Clientes { get; set; }
		public DbSet<Factura> Facturas { get; set; }
		public DbSet<Pizza> Pizzas { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(config.GetConnectionString("MSSQL"));
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return base.SaveChangesAsync(cancellationToken);
		}
	}
}
