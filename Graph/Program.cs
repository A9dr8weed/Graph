using Graph.Model;

using System;

namespace Graph
{
    public static class Program
    {
        private static void Main()
        {
            var graph = new Graph<int>();

            var v1 = new Vertex(1);
            var v2 = new Vertex(2);
            var v3 = new Vertex(3);
            var v4 = new Vertex(4);
            var v5 = new Vertex(5);
            var v6 = new Vertex(6);
            var v7 = new Vertex(7);

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);
            graph.AddVertex(v6);
            graph.AddVertex(v7);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v3, v4);
            graph.AddEdge(v2, v5);
            graph.AddEdge(v2, v6);
            graph.AddEdge(v6, v5);
            graph.AddEdge(v5, v6);

            GetMatrix(graph);

            Console.WriteLine('\n');

            GetVertex(graph, v1);
            GetVertex(graph, v2);
            GetVertex(graph, v4);

            Console.WriteLine(graph.Wave(v1, v5));
            Console.WriteLine(graph.Wave(v2, v4));
        }

        private static void GetVertex(Graph<int> graph, Vertex vertex)
        {
            Console.Write($"{vertex.Number}: (");
            foreach (Vertex item in graph.GetVertexLists(vertex))
            {
                Console.Write($"{item.Number}, ");
            }
            Console.WriteLine(")");
        }

        private static void GetMatrix(Graph<int> graph)
        {
            int[,] matrix = graph.GetMatrix();
            for (int i = 0; i < graph.VertexCount; i++)
            {
                Console.Write(i + 1);
                for (int j = 0; j < graph.VertexCount; j++)
                {
                    Console.Write($" | {matrix[i, j]} | ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(" ________________________________________________");
            Console.WriteLine();
            for (int i = 0; i < graph.VertexCount; i++)
            {
                Console.Write($" | {i + 1} | ");
            }
        }
    }
}