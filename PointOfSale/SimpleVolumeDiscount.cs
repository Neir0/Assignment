namespace PointOfSale
{
	public class SimpleVolumeDiscount : IDiscountStrategy
	{
		public string Name { get; private set; }
		public decimal DiscountTotal => (productsCounter / amount) * discountPerAmount;

		private readonly string productCode;
		private readonly uint amount;
		private readonly decimal discountPerAmount;

		private int productsCounter;

		public SimpleVolumeDiscount(string name, string productCode,
					    uint amount, decimal pricePerAmount)
		{
			Name = name;
			this.productCode = productCode;
			this.amount = amount;
			this.discountPerAmount = pricePerAmount;
		}

		public void AddProduct(Product product)
		{
			if (product.Code == this.productCode)
			{
				productsCounter++;
			}
		}

		public void Reset()
		{
			productsCounter = 0;
		}

	}
}
