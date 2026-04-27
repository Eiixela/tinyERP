using TinyERP.Models;
using TinyERP.Services;

InventoryManager inventory = new InventoryManager();

string inputUser = "0";
bool keepRunning = true;
inventory.LoadData();

while (keepRunning == true) {
	Console.WriteLine("\n--- TinyERP Menu ---");
	Console.WriteLine("1. List All Products");
	Console.WriteLine("2. Add New Product");
	Console.WriteLine("3. Delete Product");
	Console.WriteLine("4. Edit Quantity");
	Console.WriteLine("5. Report");
	Console.WriteLine("6. Exit");
	Console.Write("> Select an option: ");
	inputUser = Console.ReadLine() ?? "";
	
	switch (inputUser){
		case "1":
			inventory.ListProducts();
			break ;

		case "2":
			getInfoProduct(inventory);
			break ;
		
		case "3":
			deleteProduct(inventory);
			break ;
		
		case "4":
			EditQuantity(inventory);
			break ;
		
		case "5":
			inventory.Report();
			break ;

		case "6":
			inventory.SaveData();
			keepRunning = false;
			break ;

		default:
			Console.WriteLine("Invalid option.");
			break ;
	}
}

void EditQuantity(InventoryManager inventory) {
	Console.WriteLine("\n--- Edit Quantity ---");
	Console.WriteLine("Enter Product ID: ");

	if (int.TryParse(Console.ReadLine(), out int id)) {
		Console.WriteLine("Enter New Quantity :");
		if (int.TryParse(Console.ReadLine(), out int quantity))
			inventory.EditQuantity(id, quantity);
	}
}

void deleteProduct(InventoryManager inventory) {
	Console.WriteLine("\n--- Delete Product ---");
	Console.WriteLine("Enter Product ID: ");
	
	if (int.TryParse(Console.ReadLine(), out int id))
		inventory.DeleteProduct(id);
}

void getInfoProduct(InventoryManager inventory) {
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
