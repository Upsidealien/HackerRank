using System;
using System.Text;

namespace CamelCase
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string s = "oneTwoThree";

			int numOfWords = 1;

			char[] sArray = s.ToCharArray();

			foreach (char c in sArray)
			{
				if ((int)c < 97)
				{
					numOfWords++;
				}

			}

			Console.WriteLine(numOfWords.ToString());
		}
	}
}
