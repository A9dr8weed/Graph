namespace Graph.Model
{
    /// <summary>
    /// Vertex.
    /// </summary>
    public class Vertex
    {
        /// <summary>
        /// ID.
        /// </summary>
        public int Number { get; set; }

        public Vertex(int number)
        {
            Number = number;
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}