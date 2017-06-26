using System;
using System.Collections.Generic;
using System.IO;

namespace DFSConnectedCellsInGrid
{
	class MainClass
	{

		public static void Main(string[] args)
		{
			System.IO.StreamReader file = new System.IO.StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "input1.txt"));


			int n = Convert.ToInt32(file.ReadLine());//Convert.ToInt32(Console.ReadLine());
			int m = Convert.ToInt32(file.ReadLine());//Convert.ToInt32(Console.ReadLine());
			int[][] grid = new int[n][];
			bool[,] visited = new bool[n, m];
			List<Graph> connectedGraphs = new List<Graph>();


			for (int grid_i = 0; grid_i < n; grid_i++)
			{
				string[] grid_temp = file.ReadLine().Split(' ');
				grid[grid_i] = Array.ConvertAll(grid_temp, Int32.Parse);
			}

			for (int row = 0; row < n; row++)
			{
				for (int col = 0; col < m; col++)
				{
					if (!visited[row, col])
					{
						//Construct Connected Graph
						GetConnectedGraph(row, col, connectedGraphs, grid, visited, n, m);
					}
				}
			}

			/*
				Run through all connected graphs and find the largest
			*/
			int biggestConnectedGraph = 0;
			foreach (Graph connectedGraph in connectedGraphs)
			{
				int size = connectedGraph.GetSize();
				if (size > biggestConnectedGraph)
				{
					biggestConnectedGraph = size;
				}
			}

			Console.WriteLine(biggestConnectedGraph.ToString());

		}

		public static List<Graph> GetConnectedGraph(int row, int col, List<Graph> connectedGraphs, int[][] grid, bool[,] visited, int n, int m)
		{

			connectedGraphs.Add(DepthFirstSearch(row, col, grid, visited, n, m));

			return connectedGraphs;
		}

		public static Graph DepthFirstSearch(int row, int col, int[][] grid, bool[,] visited, int n, int m)
		{
			// Create a new connected tree
			Graph graph = new Graph();

			//Cell Translations 	
			List<int[]> translations = new List<int[]>();
			translations.Add(new int[2] { -1, -1 });
			translations.Add(new int[2] { 0, -1 });
			translations.Add(new int[2] { 1, -1 });
			translations.Add(new int[2] { -1, 0 });
			translations.Add(new int[2] { 0, 0 });
			translations.Add(new int[2] { 1, 0 });
			translations.Add(new int[2] { -1, 1 });
			translations.Add(new int[2] { 0, 1 });
			translations.Add(new int[2] { 1, 1 });

			//set Current Node to Visited
			visited[row, col] = true;

			/*Check if current node is a 1
			 * 	Look at all adjacent nodes to see if they are 1s
			 * 	if they are a 1 and not already visited then:
			 * 		Perform DepthFirstSearch on that node
			*/
			if (grid[row][col] == 1)
			{
				graph.nodes.Add(new Node(row, col));

				//Loop through the different translations of coordinates
				foreach (int[] translation in translations)
				{
					int newRow = row + translation[0];
					int newCol = col + translation[1];

					//Checking Coordinates are valid
					if (newRow >= 0 && newCol >= 0 && newRow < n && newCol < m)
					{
						if (!visited[newRow, newCol])
						{
							graph.nodes.AddRange(DepthFirstSearch(newRow, newCol, grid, visited, n, m).nodes);
						}
					}
				}
			}

			return graph;
		}
				
			

	}

	public class Node
	{
		int row;
		int col;

		public Node(int row, int col)
		{
			this.row = row;
			this.col = col;
		}
	}

	public class Graph
	{
		public List<Node> nodes;

		public Graph()
		{
			nodes = new List<Node>();
		}

		public int GetSize()
		{
			return nodes.Count;
		}
	}

}
