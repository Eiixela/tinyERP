using TinyERP.Models;
using TinyERP.Services;

InventoryManager inventory = new InventoryManager();
SaleManager sales = new SaleManager();

string inputUser = "0";
bool keepRunning = true;
bool keepRunningInventory = true;
bool keepRunningSales = true;
inventory.LoadData();
sales.LoadData();

while (keepRunning) {
	Console.WriteLine("\n === TinyERP Main System ===");
	Console.WriteLine("1. Inventory Management");
	Console.WriteLine("2. Sales & Transactions");
	Console.WriteLine("3. Exit");

	Console.Write("> Select an option: ");
	inputUser = Console.ReadLine() ?? "";

	switch (inputUser) {
		case "1":
			keepRunningInventory = true;
			InventoryMenu();
			break ;

		case "2":
			keepRunningSales = true;
			SalesMenu();
			break ;

		case "3":
			inventory.SaveData();
			sales.SaveData();
			keepRunning = false;
			break ;

	}
}

void SalesMenu() {

	while (keepRunningSales == true) {
		Console.WriteLine("\n--- Sales Menu ---");
		Console.WriteLine("1. View All Sales");
		Console.WriteLine("2. Record New Sale");
		Console.WriteLine("3. Exit");

		Console.Write("> Select an option: ");
		inputUser = Console.ReadLine() ?? "";

		switch (inputUser) {
			case "1":
				sales.ListSales();
				break;
			
			case "2":
				UserInterface.recordSale(sales, inventory);
				break;

			case "3":
				keepRunningSales = false;
				break;

		}
	}
}

void InventoryMenu () {

	while (keepRunningInventory == true) {
		Console.WriteLine("\n--- Inventory Menu ---");
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
				UserInterface.getInfoProduct(inventory);
				break ;

			case "3":
				UserInterface.deleteProduct(inventory);
				break ;

			case "4":
				UserInterface.EditQuantity(inventory);
				break ;

			case "5":
				inventory.Report();
				break ;

			case "6":
				keepRunningInventory = false;
				break ;

			default:
				Console.WriteLine("Invalid option.");
				break ;
		}
	}
}

