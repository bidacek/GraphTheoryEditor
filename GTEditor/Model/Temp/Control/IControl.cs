using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GTEditor.Control
{
    /// <summary>
    /// Check validity of graph
    /// </summary>
    interface IControl
    {
        Graph GraphForControl
        {
            get;
        }


        bool isValid();

        GraphPart getInvalidPart();
    }

    /// <summary>
    /// Control, whetever the graph is tree or not 
    /// </summary>
    public class TreeControl : IControl
    {
       
        private Graph innerGraph;
        private List<Vertex> opened = new List<Vertex>();
        private List<Vertex> closed = new List<Vertex>();

        public TreeControl(Graph g)
        {
            innerGraph = g;
        }

        public Graph GraphForControl
        {
            get { return innerGraph; }
           
        }

        public bool isValid()
        {
            return !IsCycle();
        }


        /// <summary>
        /// Return all cycles in grpah
        /// </summary>
        /// <returns></returns>
        public GraphPart getInvalidPart()
        {
           GraphPart gr = new GraphPart();
            // gr = najdiKruznici();

            return gr;
        }
        
        /// <summary>
        /// Check if there is cycle in this graph
        /// </summary>
        /// <returns></returns>
        public bool IsCycle()
        {
                foreach(Vertex v in innerGraph.Vertices)
                {
                    if (Dfs(v)) { return true; }
                
                }

                return false;
        }


        public bool Dfs(Vertex v)
        {

            if (closed.Contains(v))
            {
                return false; 
            }

                if (opened.Contains(v)) { return true; }

               
                
                opened.Add(v);
                
                foreach (IEdge e in innerGraph.nextEdges(v))
                {
                    

                    Vertex son;
                    if (e.Vertex_1 == v) { son = e.Vertex_2; }
                    else { son = e.Vertex_1; }


                    if (Dfs(son)) { return true; }
                    

                }
                
                opened.Remove(v);
                closed.Add(v);

                return false; 


        }
    }

    public class RegularGraph : IControl
    {
       private Graph innerGraph;
       private int innerK;

        public RegularGraph(Graph g, int k)
        {
            innerGraph = g;
            innerK = k;
        }

        public Graph GraphForControl
        {
            get { return innerGraph; }
        }

        public bool isValid()
        {
            foreach (Vertex v in innerGraph.Vertices)
            {
                if (innerGraph.nextEdges(v).Count != innerK) { return false; }
            }


            return true;
        }

        public GraphPart getInvalidPart()
        {
            GraphPart gp = new GraphPart();

            foreach (Vertex v in innerGraph.Vertices)
            {
                if (innerGraph.nextEdges(v).Count != innerK) { gp.Vertices.Add(v); }
            }

            return gp;
        }
    }

    //public class N-aryTreeControl atd...
}
