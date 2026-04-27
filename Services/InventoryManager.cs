using TinyERP.Models;
using System.Text.Json;
using System.IO;

namespace TinyERP.Services {


	public class InventoryManager { 
		public List<Product> inventory = new List<Product>();
		private int _nextId = 0;

		public void SaveData() {
			string fileName = "data.json";

			var options = new JsonSerializerOptions { WriteIndented = true };
			string jsonString = JsonSerializer.Serialize(inventory, options);

			File.WriteAllText(fileName, jsonString);
			Console.WriteLine("[i] Data saved to data.json");
		}

		public void LoadData() {
			string fileName = "data.json";

			if (File.Exists(fileName)) {
				string jsonString = File.ReadAllText(fileName);
				
				inventory = JsonSerializer.Deserialize<List<Product>>(jsonString) ?? new List<Product>();
				if (inventory.Count > 0) {
					_nextId = inventory.Max(p => p.Id) + 1;
				}
				Console.WriteLine($"[i] Loaded {inventory.Count} products from storage.");
			}
		}

		public InventoryManager() {}

		public void ListProducts() {

			Console.WriteLine("\n--- Products List --- ");
			string format = "{0,-6} | {1,-16} | {2,-12} | {3,-4} | {4,-10} | {5,-10}";
			Console.WriteLine(format, "ID", "Name", "Category", "Qty", "Price", "Total");
			Console.WriteLine(new string('-', 70));

			for (int i = 0; i < inventory.Count; i++) {
				Console.WriteLine(format, 
					inventory[i].Id, 
					inventory[i].Name, 
					inventory[i].Category, 
					inventory[i].Quantity, 
					inventory[i].Price.ToString("C2"), 
					(inventory[i].Quantity * inventory[i].Price).ToString("C2")
				);
			}
		}

		public void AddProduct(string name, decimal price, string category, int quantity) {
			Product newEntry = new Product(_nextId, name, price, category, quantity);
			inventory.Add(newEntry);
			_nextId++;
		}

		public void DeleteProduct(int id) {
			int removedCount = inventory.RemoveAll(p => p.Id == id);

			if (removedCount > 0) {
				Console.WriteLine($"[+] Product with ID {id} has been deleted");
			} else {
				Console.WriteLine($"[!] No product found with ID {id}");
			}
		}

		public void EditQuantity(int id, int newQuantity) {
			Product? p = inventory.Find(x => x.Id == id);
			if (p != null) {
				p.Quantity = newQuantity;
				Console.WriteLine($"[+] Updated {p.Name} to {newQuantity} units.");
			} else {
				Console.WriteLine($"[!] Product ID {id} not found.");
			}
		}

		public void Report() {
			Console.WriteLine("\n--- Inventory Report ---");
			decimal totalValue = inventory.Sum(p => p.Price * p.Quantity);
			Console.WriteLine($"Total Warehouse Value: {totalValue:C2}");

			var lowStock = inventory.Where(p => p.Quantity < 5).ToList();

			if (lowStock.Count > 0) {
				Console.WriteLine("\n[!] LOW STOCK ALERT:");
				foreach (var p in lowStock) {
					Console.WriteLine($" - {p.Name} (ID: {p.Id}): {p.Quantity} units left");
				}
			} else {
				Console.WriteLine("\n[+] All stock levels are healthy");
			}
		}
	}
}