using System;
using System.IO;
using System.Linq;

namespace BinarySearch
{
	class MainClass
	{
		public static int[] findChoices(int[] menu, int money)
		{
			int[] sortedMenu = new int[menu.Length];
			Array.Copy(menu, sortedMenu, menu.Length);
			Array.Sort(sortedMenu);

			for (int i = 0; i < sortedMenu.Length; i++)
			{
				int compliment = money - sortedMenu[i];
				if (sortedMenu.Contains(compliment))
				{
					int location = Array.BinarySearch(sortedMenu, i + 1, sortedMenu.Length-i-1, (int)compliment);

					if (location >= 0 && location < sortedMenu.Length && sortedMenu[location] == compliment)
					{
						int[] indices = getIndicesFromValues(menu, sortedMenu[i], compliment);
						return indices;
					}
				}

			}

			return null;

		}

		public static int[] getIndicesFromValues(int[] menu, int value1, int value2)
		{
			int index1 = indexOf(menu, value1, -1);
			int index2 = indexOf(menu, value2, index1);

			return new[] { Math.Min(index1, index2), Math.Max(index1, index2) };
		}

		public static int indexOf(int[] menu, int value1, int excludedIndex)
		{
			for (int i = 0; i < menu.Length; i++)
			{
				if (menu[i] == value1 && i != excludedIndex)
				{
					return i;
				}
			}

			return -1;
		}

		static void Main(String[] args)
		{
			System.IO.StreamReader file = new System.IO.StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "input1.txt"));

			int t = Convert.ToInt32(file.ReadLine());//Console.ReadLine());
			for (int a0 = 0; a0 < t; a0++)
			{
				int m = Convert.ToInt32(file.ReadLine());//Console.ReadLine());
				int n = Convert.ToInt32(file.ReadLine());//Console.ReadLine());
				string[] a_temp = file.ReadLine().Split(' ');//Console.ReadLine().Split(' ');
				int[] a = Array.ConvertAll(a_temp, Int32.Parse);

				int[] indexes = findChoices(a, m);

				for (int i = 0; i < indexes.Length; i++)
				{
					indexes[i] = indexes[i] + 1;
				}

				Console.WriteLine(string.Join(" ", indexes));
			}
		}
	}
}
