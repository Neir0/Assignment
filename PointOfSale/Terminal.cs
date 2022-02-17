using System.Collections.Generic;
using System.Linq;

namespace PointOfSale
{
	public class Terminal : ITerminal
	{
		private readonly Dictionary<string, Product> products;
		private readonly IReadOnlyList<IDiscountStrategy> discountStrategies;
		private decimal currentTotal;

		public Terminal(IEnumerable<Product> products,
			    IReadOnlyList<IDiscountStrategy> discountStrategies)
		{
			this.products = products.ToDictionary(x => x.Code);
			this.discountStrategies = discountStrategies;
		}

		public void Scan(string item)
		{
			if(!products.TryGetValue(item, out Product product)) throw new System.Exception($"Product {item} was not found");

			foreach (var discountStrategy in discountStrategies)
			{
				discountStrategy.AddProduct(product);
			}

			currentTotal += product.Price;
		}

		public decimal Total()
		{
			return currentTotal - discountStrategies.Sum(x => x.DiscountTotal);
		}

		public void Reset()
		{
			currentTotal = 0;
			foreach (var discountStrategy in discountStrategies)
			{
				discountStrategy.Reset();
			}
		}
	}
}
