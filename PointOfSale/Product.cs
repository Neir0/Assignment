namespace PointOfSale
{
	public class Product
	{
		public string Code { get; private set; }
		public decimal Price { get; private set; }

		public Product(string code, decimal price)
		{
			Code = code;
			Price = price;
		}

	}
}
