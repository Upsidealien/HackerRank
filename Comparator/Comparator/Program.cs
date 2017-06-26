﻿using System;

namespace Comparator
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Scanner scan = new Scanner(System.in);
			int n = scan.nextInt();

			Player[] player = new Player[n];
			Checker checker = new Checker();

			for (int i = 0; i < n; i++)
			{
				player[i] = new Player(scan.next(), scan.nextInt());
			}
			scan.close();

			Arrays.sort(player, checker);
			for (int i = 0; i < player.length; i++)
			{
				System.out.printf("%s %s\n", player[i].name, player[i].score);
			}
		}
	}

	class Player
	{
		String name;
		int score;

		Player(String name, int score)
		{
			this.name = name;
			this.score = score;
		}
	}

	class Checker
	{ 
		
	}
}
