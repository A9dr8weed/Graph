using System;
using System.Collections.Generic;

namespace Graph.Model
{
    public class Graph<T>
    {
        /// <summary>
        /// Множина вершин.
        /// </summary>
        private readonly List<Vertex> Vertices = new List<Vertex>();

        /// <summary>
        /// Множина ребер.
        /// </summary>
        private readonly List<Edge> Edges = new List<Edge>();

        public int VertexCount => Vertices.Count;
        public int EdgeCount => Edges.Count;

        /// <summary>
        /// Adds a new vertex to the graph.
        /// </summary>
        /// <param name="vertex"> New vertex. </param>
        /// <returns> Returns the success of the operation. </returns>
        public void AddVertex(Vertex vertex)
        {
            // We will keep the implementation simple and focus on the concepts
            if (Vertices.Find(x => x.Number == vertex.Number) != null)
            {
                Console.WriteLine($"Ignore {vertex.Number}");

                // Ignore duplicate vertices.
                return;
            }

            // Add vertex to the graph
            Vertices.Add(vertex);
        }

        /// <summary>
        /// Adds a new edge between two given vertices in the graph.
        /// </summary>
        /// <param name="from"> First vertex. </param>
        /// <param name="to"> Name of the second vertex. </param>
        /// <returns> Returns the success of the operation. </returns>
        public void AddEdge(Vertex from, Vertex to)
        {
            Edges.Add(new Edge(from, to));
        }

        /// <summary>
        /// Generation of adjacency matrices.
        /// </summary>
        /// <returns> Adjacency matrix. </returns>
        public int[,] GetMatrix()
        {
            // The size of the matrix.
            int[,] matrix = new int[Vertices.Count, Vertices.Count];

            // Go through all the edges and make marks in the intersection of the table.
            foreach (Edge edge in Edges)
            {
                // Rows.
                int row = edge.From.Number - 1;
                // Speakers.
                int column = edge.To.Number - 1;

                // For all edges to put down those parameters which have set.
                matrix[row, column] = edge.Weight;
            }

            return matrix;
        }

        /// <summary>
        /// Get adjacent vertices.
        /// </summary>
        /// <param name="vertex"> The vertex on which we look for adjacent. </param>
        /// <returns> List of adjacent vertices. </returns>
        public List<Vertex> GetVertexLists(Vertex vertex)
        {
            List<Vertex> result = new List<Vertex>();

            // Go through all the ribs.
            foreach (var edge in Edges)
            {
                // If there is a direction.
                if (edge.From == vertex)
                {
                    // Add to the list.
                    result.Add(edge.To);
                }
            }

            return result;
        }

        /// <summary>
        /// Traverse the graph.
        /// </summary>
        /// <param name="start"> Starting vertex from where the traversal should start. </param>
        /// <param name="end"> Ending vertex from where the traversal should start. </param>
        /// <returns> True, if list contains link. </returns>
        public bool Wave(Vertex start, Vertex end)
        {
            // Take the first item.
            List<Vertex> list = new List<Vertex>
            {
                start
            };

            for (int i = 0; i < list.Count; i++)
            {
                Vertex vertex = list[i];

                // Get all adjacent ribs.
                foreach (Vertex v in GetVertexLists(vertex))
                {
                    // If not yet visited.
                    if (!list.Contains(v))
                    {
                        // Alternately add all adjacent vertices.
                        list.Add(v);
                    }
                }
            }

            return list.Contains(end);
        }
    }
}