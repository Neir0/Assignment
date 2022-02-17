using System;
using Xunit;
using PointOfSale;

namespace PointOfSale.Tests
{
	public class BasicTest
	{
		ITerminal terminal;

		public BasicTest()
		{
			var products = new[]{
		new Product("A", 2),
		new Product("B", 12),
		new Product("C", 1.25M),
		new Product("D", 0.15M),
	    };

			var discountStrategies = new[]{
                // $2.00 each or 4 for $7.00
                // Discount for 4 products would be 1$ 
                new SimpleVolumeDiscount("Discount for a Product A", "A", 4, 1),

                // $1.25 each or $6 for a six pack
                // Discount for 6 products would be $1,5
                new SimpleVolumeDiscount("Discount for a Product C", "C", 6, 1.5M)
	    };

			terminal = new Terminal(products, discountStrategies);
		}

		[Fact]
		public void Test1()
		{
			var itemsToScan = "ABCDABAA";

			foreach (var item in itemsToScan)
			{
				terminal.Scan(item.ToString());
			}

			Assert.Equal(32.4M, terminal.Total());
		}

		[Fact]
		public void Test2()
		{
			var itemsToScan = "CCCCCCC";

			foreach (var item in itemsToScan)
			{
				terminal.Scan(item.ToString());
			}

			Assert.Equal(7.25M, terminal.Total());
		}

		[Fact]
		public void Test3()
		{
			var itemsToScan = "ABCD";

			foreach (var item in itemsToScan)
			{
				terminal.Scan(item.ToString());
			}

			Assert.Equal(15.40M, terminal.Total());
		}
	}
}





