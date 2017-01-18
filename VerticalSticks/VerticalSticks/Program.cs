using System;
using System.Collections.Generic;
using System.Linq;

namespace VerticalSticks
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int cases = 1; //long.Parse(Console.ReadLine());

			for (int i = 0; i < cases; i++)
			{
				int numberOfSticks = 3;//long.Parse(Console.ReadLine());

				int[] stickHeights = new int[] { 2, 2, 3 };//Array.ConvertAll(Console.ReadLine().Split(' '), s => long.Parse(s));

				List<double> probs = new List<double>();

				for (int j = 0; j < numberOfSticks; j++)
				{
					probs.Add((double)((double)(numberOfSticks + 1) / (double)(Array.FindAll(stickHeights, elem => stickHeights[j] <= elem).Count() + 1)));
				}

				Console.WriteLine(String.Format("{0:0.00}", probs.Sum()));
			}
		}
	}
}
