using System;

namespace InsertionSort
{
	class Solution
	{
		static void insertionSort(int[] ar)
		{
			int len = ar.Length;
			int j, toMoveUp;
			string output = "";
			for (int i = 0; i < len; i++)
			{
				toMoveUp = ar[i];
				j = i;
				while (j > 0 && ar[j - 1] > toMoveUp)
				{
					ar[j] = ar[j - 1];
					j--;
					output = string.Join(" ", ar);
					Console.WriteLine(output);
				}
				ar[j] = toMoveUp;
			}
			output = string.Join(" ", ar);
			Console.WriteLine(output);
		}
		/* Tail starts here */
		static void Main(String[] args)
		{

			/*int _ar_size;
			_ar_size = Convert.ToInt32(Console.ReadLine());
			int[] _ar = new int[_ar_size];
			String elements = Console.ReadLine();
			String[] split_elements = elements.Split(' ');
			for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++)
			{
				_ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
			}*/
			int[] _ar = new int[] { 1, 2, 3, 4, 5, 0 };

			insertionSort(_ar);
		}
	}
}
