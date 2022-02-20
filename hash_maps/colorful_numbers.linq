<Query Kind="Program" />

void Main()
{
	Assert(123, CutFromRight(123, 0));
	Assert(12, CutFromRight(123, 1));
	Assert(1, CutFromRight(123, 2));

	Assert(23, CutFromLeft(123, 1));
	Assert(3, CutFromLeft(123, 2));
	Assert(34, CutFromLeft(1234, 2));
	Assert(234, CutFromLeft(1234, 1));
	Assert(1234, CutFromLeft(1234, 0));
	Assert(4, CutFromLeft(1234, 3));
	Assert(0, CutFromLeft(1234, 4));

	Assert(1, Product(1));
	Assert(2, Product(12));
	Assert(6, Product(23));
	Assert(24, Product(234));

	Assert(true, IsColorful(3245));
	Assert(true, IsColorful(263));
	Assert(false, IsColorful(236)); 
}


bool IsColorful(int value)
{
	var products = new HashSet<int>();
	var digits = getOrder(value) + 1;
	digits.Dump("digits");
	for(int size = 1; size < digits; size++)
	{
		for(int i = 0; i < digits - size + 1; i++)
		{
			var cutLeft = i;
			var cutRight = digits - cutLeft - size;
			var num = CutFromRight(CutFromLeft(value, cutLeft), cutRight);
			var product = Product(num);
			
			if(products.Contains(product))
			{
				return false;
			}
			
			products.Add(product);

			$"s:{size}, i:{i}, num: {num}, product: {product}".Dump();
		}
	}
	
	return true;
}

int Product(int value)
{
	var product = 1;
	while (value != 0)
	{
		product *= (value % 10);
		value /= 10;
	}

	return product;
}

int CutFromRight(int value, int cut) => value / (int)(Math.Pow(10, cut));
int CutFromLeft(int value, int cut)
{
	var order = getOrder(value);
	var pow = order - cut + 1;
	return value % (int)Math.Pow(10, pow);
}

int getOrder(int value) => (int)Math.Log10(value);

void Assert(int expected, int actual)
{
	if (expected != actual) throw new Exception($"{expected} != {actual}");
}

void Assert(bool expected, bool actual)
{
	if (expected != actual) throw new Exception($"{expected} != {actual}");
}

