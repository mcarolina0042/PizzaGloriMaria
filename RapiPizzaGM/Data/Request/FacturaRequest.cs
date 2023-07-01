namespace RapiPizzaGM.Data.Request
{
	public class FacturaRequest
	{
		public int Id { get; set; }


		public int ClienteId { get; set; }

        public int PizzaId { get; set; }
        public string Referencia { get; set; } = null!;
		public string Extra { get; set; } = null!;
		public decimal SubTotal { get; set; }

        public int Cantidad { get; set; }
        public decimal Descuento { get; set; }
		public decimal ITBIS { get; set; }
		public decimal Total { get; set; }
	}
}
