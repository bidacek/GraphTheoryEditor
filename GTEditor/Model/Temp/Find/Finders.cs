using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using GTEditor.VisualG.PositionG;

namespace GTEditor.Find
{   


   


    public class MagicWandFinder
    {
       
        Graph innerGraph;
        
        public MagicWandFinder(Graph gr)
        {
            innerGraph = gr;
         
        }

        public GraphPart findPart(GraphPart start)
        {
            GraphPart p = new GraphPart();

            foreach (Vertex v in start.Vertices)
            {

                if (p.Vertices.Contains(v)) { continue; }

                Stack<Vertex> st = new Stack<Vertex>();
                st.Push(v);


                while (st.Count != 0)
                {
                    Vertex act = st.Pop();
                    p.Vertices.Add(act);

                    foreach (IEdge e in innerGraph.nextEdges(act))
                    {
                        Vertex son;
                        if (!p.Edges.Contains(e)) { p.Edges.Add(e); }

                        if (e.Vertex_1 == act) { son = e.Vertex_2; }
                        else {son= e.Vertex_1;}

                        if (!p.Vertices.Contains(son)) {st.Push(son); }
                    }

                }

            }

            return p;
        }

        

    }

    //public class PropertyFinder, MagicWand
}
