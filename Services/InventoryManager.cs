using TinyERP.Models;

namespace TinyERP.Services {


	public class InventoryManager { 
		public List<Product> inventory = new List<Product>();
		public int Count;

		public InventoryManager() {
			Count = 0;
		}

		public void ListProducts() {

			Console.WriteLine("--- Products List --- ");
			string format = "{0,-6} | {1,-16} | {2,-12} | {3,-4} | {4,-10} | {5,-10}";
			Console.WriteLine(format, "ID", "Name", "Category", "Qty", "Price", "Total");
			Console.WriteLine(new string('-', 70));

			for (int i = 0; i < this.Count; i++) {
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
			Product newEntry = new Product(Count, name, price, category, quantity);
			inventory.Add(newEntry);
			Count++;
		}

		public void DeleteProduct(int id) {
			
		}

		public void EditQuantity(int id, int quantity) {

		}

		public void Report() {

		}

		//List of Product in the inventory
		//Add a new Product in the inventory
		//Delete a Product from the inventory
		//Update Product Quantity in the inventory
		//Add reports for low stocks
	}
}