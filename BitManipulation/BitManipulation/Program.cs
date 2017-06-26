using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BitManipulation
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int n = Convert.ToInt32(Console.ReadLine());
			string[] a_temp = Console.ReadLine().Split(' ');
			int[] a = Array.ConvertAll(a_temp, Int32.Parse);

			int result = 0;
			foreach (int value in a)
			{
				result ^= value;
			}

			Console.WriteLine(result);
		}
	}
}
