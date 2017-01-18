using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualisingTheArray
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			/* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
			//Int32.Parse(Console.ReadLine());
			string list = "1 1 1 1 2 3 4 5 5 5 5 5 5 5 5 5";
			int lengthOfArray = list.Split(' ').Count();
			List<string> elems = list.Split(' ').ToList();//Console.ReadLine().Split(' ').ToList();

			var groups = elems.GroupBy(e => e).OrderBy(group => group.Count()); ;

			int result = lengthOfArray - groups.Last().Count();

			Console.WriteLine(result.ToString());
		}
	}
}
