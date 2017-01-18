using System;
using System.Collections.Generic;
using System.Linq;

namespace JourneyToTheMoon
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string[] basicInfo = Console.ReadLine().Split(' ');

			Int64 numAst = Int64.Parse(basicInfo[0]);
			int numEdges = 2; //Int32.Parse(basicInfo[1]);

			/*
			Loop through each edge of the graph
				initialise tempStartSubGraphs
				initialise tempEndSubGraphs
				foreach(subgraph in subgraphs) 
					if first value of edge is in subgraph
						add index of subgraph to tempStartSubGraph
					else if second value of edge is in subgraph
						add index of subgraph to tempEndSubGraph
				if (tempStartSubGraph is empty and tempEndSubGraph is empty) 
					create a new subgraph containing first value and second value of edge
				else if (tempStartSubGraphs is empty and tempEndSubGraph is not empty)
					add first value to subgraphs[tempEndSubGraph]
				else if (tempEndSubGraph is empty and tempStartSubGraph is not empty)
					add second value to subgraphs[tempStartSubGraph]
				else if (tempStartSubGraph is not empty and tempEndSubGraph is not empty)
					Union subgraphs[tempEndSubGraph] and subgraphs[tempStartSubGraph]
			*/
			List<List<int>> edges = new List<List<int>>();

			edges.Add(new List<int>(new int[] { 1, 2 }));
			edges.Add(new List<int>(new int[] { 3, 4 }));
			//edges.Add(new List<int>(new int[] { 0, 4 }));
			//edges.Add(new List<int>(new int[] { 1, 2 }));
			//edges.Add(new List<int>(new int[] { 1, 3 }));
			//edges.Add(new List<int>(new int[] { 1, 5 }));
			//edges.Add(new List<int>(new int[] { 1, 7 }));
			//edges.Add(new List<int>(new int[] { 1, 8 }));
			//edges.Add(new List<int>(new int[] { 1, 9 }));
			//edges.Add(new List<int>(new int[] { 2, 8 }));
			//edges.Add(new List<int>(new int[] { 2, 7 }));
			//edges.Add(new List<int>(new int[] { 3, 5 }));
			//edges.Add(new List<int>(new int[] { 3, 8 }));
			//edges.Add(new List<int>(new int[] { 3, 7 }));
			//edges.Add(new List<int>(new int[] { 4, 9 }));
			//edges.Add(new List<int>(new int[] { 4, 5 }));
			//edges.Add(new List<int>(new int[] { 4, 6 }));
			//edges.Add(new List<int>(new int[] { 4, 7 }));
			//edges.Add(new List<int>(new int[] { 6, 8 }));
			//edges.Add(new List<int>(new int[] { 6, 7 }));


			List<List<int>> subgraphs = new List<List<int>>();

			for (int i = 0; i < numEdges; i++)
			{
				int startSubGraphIndex = -1;
				int endSubGraphIndex = -1;

				List<int> edge = edges.ElementAt(i);
				int edgeStart = edge.ElementAt(0);
				int edgeEnd = edge.ElementAt(1);

				foreach (var subgraph in subgraphs)
				{
					if (subgraph.Contains(edgeStart))
					{
						startSubGraphIndex = subgraphs.IndexOf(subgraph);
					}
					    else if (subgraph.Contains(edgeEnd))
					{
						endSubGraphIndex = subgraphs.IndexOf(subgraph);
					}
				}

				if (startSubGraphIndex == -1 && endSubGraphIndex == -1)
				{
					List<int> newSubGraph = new List<int>(new int[] { edgeStart, edgeEnd });
					subgraphs.Add(newSubGraph);
				}
				else if (startSubGraphIndex != -1 && endSubGraphIndex == -1)
				{
					if (!subgraphs[startSubGraphIndex].Contains(edgeEnd)) 
					{
						subgraphs[startSubGraphIndex].Add(edgeEnd);
					}    
				}
				else if (startSubGraphIndex == -1 && endSubGraphIndex != -1)
				{
					if (!subgraphs[endSubGraphIndex].Contains(edgeStart))
					{
						subgraphs[endSubGraphIndex].Add(edgeStart);
					}

				}
				else if (startSubGraphIndex != -1 && endSubGraphIndex != -1)
				{
					var tempStartSubGraph = subgraphs[startSubGraphIndex];
					var tempEndSubGraph = subgraphs[endSubGraphIndex];
					var tempNewSubGraph = (subgraphs[startSubGraphIndex].Union(subgraphs[endSubGraphIndex])).Distinct().ToList();
					subgraphs.Add(tempNewSubGraph);
					subgraphs.Remove(tempStartSubGraph);
					subgraphs.Remove(tempEndSubGraph);
				}
			}

			Int64 sizeConnectedSubGraphs = 0;

			foreach (var subgraph in subgraphs)
			{
				sizeConnectedSubGraphs += ((subgraph.Count() * (subgraph.Count() - 1)) / 2);
			}

			Int64 answer = (Int64) ((numAst * (numAst - 1)) / 2) - sizeConnectedSubGraphs;

			Console.WriteLine(answer.ToString());

		}
	}
}
