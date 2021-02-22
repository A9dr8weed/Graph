using System;

namespace Graph.Model
{
    /// <summary>
    /// Ribs.
    /// </summary>
    public class Edge
    {
        /// <summary>
        /// From.
        /// </summary>
        public Vertex From { get; set; }

        /// <summary>
        /// To.
        /// </summary>
        public Vertex To { get; set; }

        /// <summary>
        /// Graph weight (data for a weighted graph).
        /// </summary>
        public int Weight { get; set; }

        public Edge(Vertex from, Vertex to, int weight = 1)
        {
            if (from == null || to == null)
            {
                throw new ArgumentNullException(nameof(from), nameof(to));
            }

            Weight = weight;
            From = from;
            To = to;
        }

        public override string ToString()
        {
            return $"({From}; {To})";
        }
    }
}