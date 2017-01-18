using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MatchingSocks
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int n = 9; //Convert.ToInt32(Console.ReadLine());
					   //string[] c_temp = Console.ReadLine().Split(' ');
			int[] c = {10, 20, 20, 10, 10, 30, 50, 10, 20 };//Array.ConvertAll(c_temp, Int32.Parse);

			int sockPairs = 0;

			foreach (var colour in c.Distinct().ToArray())
			{
				sockPairs = sockPairs + (int)(c.Count(s => s == colour) / 2);
			}

			Console.WriteLine(sockPairs.ToString());
		}
	}
}
