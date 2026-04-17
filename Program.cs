using TinyERP.Models;
using TinyERP.Services;

InventoryManager inventory = new InventoryManager();

string inputUser = "0";
bool keepRunning = true;

while (keepRunning == true) {
	Console.Write("> Select an option: ");
	inputUser = Console.ReadLine() ?? "";
	
	switch (inputUser){
		case "1":
			inventory.ListProducts();
			break ;

		case "2":
			getInfoProduct();
			break ;

		case "6":
			keepRunning = false;
			break ;

		default:
			break ;
	}
}

void getInfoProduct(InventoryManager inventory) {
	Console.WriteLine("Enter Product Name: ")
	string name = Console.ReadLine() ?? "";

	if (!name) {
		Console.WriteLine("Please enter a valid Product Name");
		return ;
	}

	Console.WriteLine("Enter Category (Electronics, Food, Furniture):")

	string category = Console.ReadLine() ?? "";
	if (!category) {
		Console.WriteLine("Please enter a valid Category");
		return ;
	}

	Console.WriteLine("Enter Quantity:")

	int category = ToInt(Console.ReadLine()) ?? 0;
	if (!category) {
		Console.WriteLine("Please enter a valid Quantity");
		return ;
	}

	decimal price = ToDecimal(Console.Readline(:)) ?? 0.0;
	if (!price) {
		Console.WriteLine("Please enter a valid Price")
	}
	inventory.AddProduct(name, price, category, quantity);
/* 
	Console.WriteLine("Enter Product Name:");
    string name = Console.ReadLine() ?? "";

    if (string.IsNullOrWhiteSpace(name)) {
        Console.WriteLine("Please enter a valid Product Name");
        return;
    }

    Console.WriteLine("Enter Category (Electronics, Food, Furniture):");
    string category = Console.ReadLine() ?? "";

    if (string.IsNullOrWhiteSpace(category)) {
        Console.WriteLine("Please enter a valid Category");
        return;
    }

    Console.WriteLine("Enter Quantity:");
    // TryParse is safer: it returns false instead of crashing if input is "abc"
    if (!int.TryParse(Console.ReadLine(), out int quantity)) {
        Console.WriteLine("Please enter a valid Quantity");
        return;
    }

    Console.WriteLine("Enter Price:");
    if (!decimal.TryParse(Console.ReadLine(), out decimal price)) {
        Console.WriteLine("Please enter a valid Price");
        return;
    }

    inventory.AddProduct(name, price, category, quantity);
    Console.WriteLine("[+] Product added successfully!"); */
}
