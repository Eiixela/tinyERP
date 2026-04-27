using TinyERP.Models;
using System.Text.Json;
using System.IO;

namespace TinyERP.Services {

	public class AnalyticsManager {
		private InventoryManager _inventory;
		private SaleManager _sales;

		public AnalyticsManager(InventoryManager inventory, SaleManager sales) {
			_inventory = inventory;
			_sales = sales;
		}

		public void DisplayDashboard() {
			Console.WriteLine("\n=== TinyERP Analytics Dashboard ===");

			decimal totalWarehouseValue =  _inventory.inventory.Sum(p => p.Price * p.Quantity);
			decimal totalRevenue = _sales.sales.Sum(s => s.Total);

			Console.WriteLine($"\n[ FINANCE ]");
			Console.WriteLine($"Total Warehouse Value : {totalWarehouseValue:C2}");
			Console.WriteLine($"Total Revenue Generated: {totalRevenue:C2}");
			Console.WriteLine($"Estimated Net Profit   : {(totalRevenue * 0.3m):C2}");

			showTopSeller();
		}

		private void showTopSeller() {

			Console.WriteLine("\n[ PERFORMANCE ]");

			if (_sales.sales.Count == 0) {
				Console.WriteLine("Top seller : No sales yet.");
				return ;
			}

			var top = _sales.sales
					.GroupBy(s => s.ProductName)
					.Select(g => new {
							Name = g.Key,
							TotalSold = g.Sum(s => s.Quantity)
							}).OrderByDescending(x => x.TotalSold).FirstOrDefault();

			if (top != null) {
				Console.WriteLine($"Top seller : {top.Name} ({top.TotalSold}) units).");
			}
		}
	}
}