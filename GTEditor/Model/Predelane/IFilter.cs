using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTEditor.SelectorG
{
    public interface IFilter
    {
        void  filterPart(GraphPart gp);
       
    }

    public class GraphFilter : IFilter
    {
        public void filterPart(GraphPart gp)
        {
            List<IEdge> forRemove = new List<IEdge>();

            foreach (IEdge e in gp.Edges)
            {
                if (!gp.Vertices.Contains(e.Vertex_1) || !gp.Vertices.Contains(e.Vertex_2))
                {
                    forRemove.Add(e);
                }
            }

            foreach (IEdge e in forRemove)
            {
                gp.Edges.Remove(e);
            }
        }
    }
}
