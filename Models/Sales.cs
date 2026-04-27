namespace TinyERP.Models {

	public class Sale {
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public decimal Total { get; set; }

		public Sale(int id, DateTime date, string productName, int quantity, decimal total ) {
			Id = id;
			Date = date;
			ProductName = productName;
			Quantity = quantity;
			Total = total;
		}
	}
}