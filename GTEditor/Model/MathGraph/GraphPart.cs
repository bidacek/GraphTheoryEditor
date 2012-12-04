using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTEditor
{
    /// <summary>
    /// Represent some subset of graph. Contains list of edges and list of vertices, 
    /// but it doesn't have to be a graph (for example: Some node of edge isn't contained in list of nodes of this GraphPart.) 
    /// </summary>
    public class GraphPart
    {
        private List<IEdge> innerEdges;
        private List<Vertex> innerVertices;

        /// <summary>
        /// Create empty GraphPart
        /// </summary>
        public GraphPart()
        {
            innerVertices = new List<Vertex>();
            innerEdges = new List<IEdge>();

        }

        /// <summary>
        /// Get or set list of edges in this graphPart. Null value can't be set.
        /// </summary>
        public List<IEdge> Edges
        {
            get { return innerEdges; }
            set {
                if (value == null) { return; }
                innerEdges = value;
            }
        }

        /// <summary>
        /// Get or set list of vertices in this graphPart. Null value can't be set.
        /// </summary>
        public List<Vertex> Vertices
        {
            get { return innerVertices; }
            set { innerVertices = value;

            if (value == null) { return; }
            innerVertices = value;


            }
        }


        /// <summary>
        /// Merge two GraphParts through the use of Union operation.
        /// </summary>
        /// <param name="p">The other GraphPart</param>
        public void Union(GraphPart p)
        {
            if (p == null) { return; }

            foreach (IEdge e in p.Edges)
            {
                if (!innerEdges.Contains(e)) { innerEdges.Add(e); }
            }

          

            foreach (Vertex v in p.Vertices)
            {
                if (!innerVertices.Contains(v)) { innerVertices.Add(v); }
            }

           
        }

        /// <summary>
        /// Merge two GraphParts  through the use of Intersect operation.
        /// </summary>
        /// <param name="p">The other GraphPart</param>
        public void Intersect(GraphPart p)
        {
            if (p == null) { return; }

            List<IEdge> forRemoveE = new List<IEdge>();

            foreach (IEdge e in innerEdges)
            {
                if (!p.Edges.Contains(e)) { forRemoveE.Add(e); }
            }

            foreach (IEdge e in forRemoveE)
            {
                innerEdges.Remove(e);
            }



            List<Vertex> forRemoveV = new List<Vertex>();

            foreach (Vertex v in innerEdges)
            {
                if (!p.Vertices.Contains(v)) { forRemoveV.Add(v); }
            }

            foreach (Vertex v in forRemoveV)
            {
                innerVertices.Remove(v);
            }


        }

     

        /// <summary>
        /// Merge two GraphParts  through the use of Except operation.
        /// </summary>
        /// <param name="p">The other GraphPart</param>
        public void Except(GraphPart p)
        {
            if (p == null) { return; }

            List<Vertex> forRemoveV = new List<Vertex>();

            foreach (Vertex v in innerVertices)
            {
                if (p.Vertices.Contains(v)) { forRemoveV.Add(v); }
            }

            foreach (Vertex v in forRemoveV)
            {
                innerVertices.Remove(v);
            }


            List<IEdge> forRemoveE = new List<IEdge>();

            foreach (IEdge e in innerEdges)
            {
                if (p.Edges.Contains(e)) { forRemoveE.Add(e); }
            }

            foreach (IEdge e in forRemoveE)
            {
                innerEdges.Remove(e);
            }

        }
    }
}
