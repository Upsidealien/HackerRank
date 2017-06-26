using System;
using System.Collections.Generic;
using System.IO;

namespace FibonacciNumbers
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int n = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine(Fibonacci(n));
		}

		public static int Fibonacci(int n)
		{

			double a = Math.Pow((1 + Math.Sqrt(5)), n);
			double b = Math.Pow((1 - Math.Sqrt(5)), n);
			double c = (Math.Pow(2, n) * Math.Pow(5, 0.5));

			return  (int)Math.Round((a - b)/c);
		}

	}
}
