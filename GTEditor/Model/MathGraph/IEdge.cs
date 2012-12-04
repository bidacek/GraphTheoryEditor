using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTEditor
{
    /// <summary>
    /// Ordered or unordered (depends on IsOriented property at parent graph) set of two vertices, 
    /// which is represented by vertex_1 and vertex_2 property.
    /// </summary>
    public interface IEdge : GraphObject
    {

        Vertex Vertex_1
        {
            get;
        }
        Vertex Vertex_2
        {
            get;
        }


    }

    /// <summary>
    /// Represent edge of oriented graph.
    /// </summary>
   public  class OrientedEdge : IEdge
    {

        private Vertex innerV1;
        private Vertex innerV2;

        /// <summary>
        /// Create oriented edge.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public OrientedEdge(Vertex v1, Vertex v2)
        {
            innerV1 = v1;
            innerV2 = v2;
        }
        /// <summary>
        /// Starting node of this edge
        /// </summary>
        public Vertex Vertex_1
        {
            get { return innerV1; }
        }

        /// <summary>
        /// Ending node of this edge
        /// </summary>
        public Vertex Vertex_2
        {
            get { return innerV2; }
        }

        /// <summary>
        /// Return HashCode of this edge
        /// </summary>
        /// <returns> HashCode </returns>
        public override int GetHashCode()
        {
            int hc = Vertex_1.GetHashCode() - Vertex_2.GetHashCode();
            return hc.GetHashCode();
        }


        /// <summary>
        /// Determines whether this two edges are equal. 
        /// </summary>
        /// <param name="obj">The other edge</param>
        /// <returns>true if starting and ending node are the same</returns>
        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }

            OrientedEdge e = obj as OrientedEdge;

            if (e == null) { return false; }

            return (this.Equals(e));
        }

        /// <summary>
        /// Determines whether this two edges are equal.
        /// </summary>
        /// <param name="e">The other edge</param>
        /// <returns>true if starting and ending node are the same</returns>
        public bool Equals(OrientedEdge e)
        {
            if (this.Vertex_1 == e.Vertex_1 && this.Vertex_2 == e.Vertex_2) { return true; }
            else { return false; }
        }

        /// <summary>
        /// Overrided ToString method (notation like ordered set)
        /// </summary>
        /// <returns>Two vertices in parentheses (it means ordered set)</returns>
        public override string ToString()
        {

            return "(" + innerV1.ToString() + "," + innerV2.ToString() + ")";
        }


    }

    /// <summary>
    /// Edge contained in Nonoriented graph
    /// </summary>
    public class NonOrientedEdge : IEdge
    {

        private Vertex innerV1;
        private Vertex innerV2;
        /// <summary>
        /// Create nonoriented edge
        /// </summary>
        /// <param name="v1">First node</param>
        /// <param name="v2">Other node</param>
        public NonOrientedEdge(Vertex v1, Vertex v2)
        {
            innerV1 = v1;
            innerV2 = v2;
        }

        /// <summary>
        /// One of the unordered set of nodes
        /// </summary>
        public Vertex Vertex_1
        {
            get { return innerV1; }
        }
        /// <summary>
        /// One of the unordered set of nodes
        /// </summary>
        public Vertex Vertex_2
        {
            get { return innerV2; }
        }


        /// <summary>
        /// Determines whether this two edges are equal.
        /// </summary>
        /// <param name="obj">The other edge</param>
        /// <returns>true if unordered sets of node are the same </returns>
        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }

            NonOrientedEdge e = obj as NonOrientedEdge;

            if (e == null) { return false; }

            return (this.Equals(e));
        }

        /// <summary>
        /// Determines whether this two edges are equal.
        /// </summary>
        /// <param name="e">The other edge</param>
        /// <returns>true if unordered sets of node are the same</returns>
        public bool Equals(NonOrientedEdge e)
        {
            if ((this.Vertex_1 == e.Vertex_1 && this.Vertex_2 == e.Vertex_2) || (this.Vertex_1 == e.Vertex_2 && this.Vertex_2 == e.Vertex_1)) { return true; }
            else { return false; }
        }

        /// <summary>
        /// Return HashCode of this edge.
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            int hc = Vertex_1.GetHashCode() - Vertex_2.GetHashCode();
            return hc.GetHashCode();
        }






        /// <summary>
        /// Overrided ToString method (notation like unordered set)
        /// </summary>
        /// <returns>Two vertices in curly brackets</returns>
        public override string ToString()
        {

            return "{" + innerV1.ToString() + "," + innerV2.ToString() + "}";
        }


    }
}
