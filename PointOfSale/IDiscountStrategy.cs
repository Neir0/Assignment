namespace PointOfSale
{
	// We might have different strategies for a discount, like for example  
	// discount for volume, or buy one get one free up to N items
	public interface IDiscountStrategy
	{
		string Name { get; }
		void AddProduct(Product product);
		decimal DiscountTotal { get; }
		void Reset();
	}
}
