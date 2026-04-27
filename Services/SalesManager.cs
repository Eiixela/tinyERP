using TinyERP.Models;
using System.Text.Json;
using System.IO;

namespace TinyERP.Services {

	public class SaleManager {
		public List<Sale> sales = new List<Sale>();
		private int _nextId = 0;

 		public void SaveData() {
			string fileName = "Sale.json";

			var options = new JsonSerializerOptions { WriteIndented = true };
			string jsonString = JsonSerializer.Serialize(sales, options);

			File.WriteAllText(fileName, jsonString);
			Console.WriteLine("[i] Sales saved to Sale.json");
		}

		public void LoadData() {
			string fileName = "Sale.json";

			if (File.Exists(fileName)) {
				string jsonString = File.ReadAllText(fileName);
				
				sales = JsonSerializer.Deserialize<List<Sale>>(jsonString) ?? new List<Sale>();
				if (sales.Count > 0) {
					_nextId = sales.Max(p => p.Id) + 1;
				}
				Console.WriteLine($"[i] Loaded {sales.Count} products from storage.");
			}
		}

		public SaleManager() {}

		public void ListSales() {
			Console.WriteLine("\n--- Sales --- ");
			string format = "{0,-6} | {1,-16} | {2,-12} | {3,-4} | {4,-10}";
			Console.WriteLine(format, "ID", "Date", "Product Name", "Qty", "Total");
			Console.WriteLine(new string('-', 70));

			for (int i = 0; i < sales.Count; i++) {
				Console.WriteLine(format, 
					sales[i].Id, 
					sales[i].Date.ToString("yyyy-MM-dd HH:mm"), 
					sales[i].ProductName, 
					sales[i].Quantity, 
					sales[i].Total.ToString("C2") 
				);
			}
		}

		public void recordSale(string productName, int quantity, decimal price) {
			Sale newSale = new Sale(
					_nextId, 
					DateTime.Now, 
					productName, 
					quantity, 
					quantity * price
				);
			sales.Add(newSale);
			_nextId++;
		}
	}
}