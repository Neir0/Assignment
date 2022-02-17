using System;
using System.Collections;

namespace PointOfSale
{
	public interface ITerminal
	{
		void Scan(string item);
		decimal Total();
	}
}
