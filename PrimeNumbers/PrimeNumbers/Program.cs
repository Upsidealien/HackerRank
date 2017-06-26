using System;

namespace PrimeNumbers
{
	class MainClass
	{
		static void Main(String[] args)
		{
			int p = Convert.ToInt32(Console.ReadLine());
			int[] numbers = { 12, 5, 7 };
			for (int a0 = 0; a0 < p; a0++)
			{
				int n = Convert.ToInt32(Console.ReadLine());
				bool notPrime = false;
				int count = 1;

				while (!notPrime && count <= (int)Math.Round(Math.Sqrt(n), 0))
				{
					count++;

					if ((n % count) == 0)
					{
						notPrime = true;
						Console.WriteLine("Not Prime");
					}


				}

				if (count > Math.Sqrt(n))
				{
					Console.WriteLine("Prime");
				}
			}
		}
	}
}
