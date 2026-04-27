using TinyERP.Services;

namespace TinyERP.Services {
	
	public static class UserInterface {
			
		public static void EditQuantity(InventoryManager inventory) {
			Console.WriteLine("\n--- Edit Quantity ---");
			Console.WriteLine("Enter Product ID: ");

			if (int.TryParse(Console.ReadLine(), out int id)) {
				Console.WriteLine("Enter New Quantity :");
				if (int.TryParse(Console.ReadLine(), out int quantity))
					inventory.EditQuantity(id, quantity);
			}
		}

		public static void deleteProduct(InventoryManager inventory) {
			Console.WriteLine("\n--- Delete Product ---");
			Console.WriteLine("Enter Product ID: ");

			if (int.TryParse(Console.ReadLine(), out int id))
				inventory.DeleteProduct(id);
		}

		public static void getInfoProduct(InventoryManager inventory) {
			Console.WriteLine("\n--- Add New Product ---");

			Console.WriteLine("Enter Product Name: ");
			string name = Console.ReadLine() ?? "";

			if (string.IsNullOrWhiteSpace(name)) {
				Console.WriteLine("Please enter a valid Product Name");
				return ;
			}

			Console.WriteLine("Enter Category (Electronics, Food, Furniture):");
			string category = Console.ReadLine() ?? "";
			if (string.IsNullOrWhiteSpace(category)) {
				Console.WriteLine("Please enter a valid Category");
				return ;
			}

			Console.WriteLine("Enter Quantity:");
			if (!int.TryParse(Console.ReadLine(), out int quantity)) {
				Console.WriteLine("Please enter a valid Quantity");
				return ;
			}

			Console.WriteLine("Enter Product Price:");
			if (!decimal.TryParse(Console.ReadLine(), out decimal price)) {
				Console.WriteLine("Invalid price format.");
				return;
			}

			inventory.AddProduct(name, price, category, quantity);
			Console.WriteLine("[+] Product added successfully!");
		}

		public static void recordSale(SaleManager saleManager, InventoryManager inventory) {
			Console.WriteLine("\n--- Record New Sale ---");
			Console.Write("Enter Product ID: ");

			if (int.TryParse(Console.ReadLine(), out int pid)) {
				var product = inventory.inventory.Find(p => p.Id == pid);

				if (product == null) {
					Console.WriteLine("[!] Product not found");
					return ;
				}

				Console.WriteLine($"Enter Quantity to Sell (Available {product.Quantity}): ");
				if (int.TryParse(Console.ReadLine(), out int quantity)) {

					if (quantity > product.Quantity) {
						Console.WriteLine("[!] Error: Insufficent stock.");
						return ;
					}

					product.Quantity -= quantity;
					saleManager.recordSale(product.Name, quantity, product.Price);
					
					Console.WriteLine($"[+] Sale recorded! {product.Name} stock updated.");
				}	
			}

		}
	}
}