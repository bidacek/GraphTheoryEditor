using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTEditor.Edit
{
    /// <summary>
    /// Implementace orientovaného grafu povolující smyčky. Ale multihrany povoleny nejsou.
    /// </summary>
    class NonOriented : IEditor
    {
        Graph innerGraph;

        
        
        public Graph GraphForEdit
        {
            get { return innerGraph; }
           
        }

        public EdgeEventHandler eHandler { get; set; }
        public VertexEventHandler vHandler { get; set; }

        public NonOriented(Graph graph)
        {
            
        }



        public void addVertex(Vertex v)
        {
            if (v == null) { return; }
            if (innerGraph.Vertices.Contains(v)) { return; }
            innerGraph.Vertices.Add(v);

            if (vHandler != null) vHandler(this, new VertexChangeArgs(v, ChangeType.Add));
        }

        public void addEdge(IEdge e)
        {
            if (e == null) {return; }

            //neplatný graf
            if (!innerGraph.Vertices.Contains(e.Vertex_1) || !innerGraph.Vertices.Contains(e.Vertex_2)) { return; }

            //multihrana

            /*
            foreach(Edge ed in innerGraph.Edges)
            {
                if ((ed.vertex_1 == e.vertex_1 && ed.vertex_2 == e.vertex_2) || (ed.vertex_1 == e.vertex_2 && ed.vertex_2 == e.vertex_1))
                {
                    return;
                }
            }
             */

            if (GraphForEdit.Edges.Contains(e, GraphForEdit.getEdgeComparer())) { return; }

            innerGraph.Edges.Add(e);

            if (eHandler != null) eHandler(this, new EdgeChangeArgs(e, ChangeType.Add));
        }

        public void removeVertex(Vertex v)
        {
            if (v == null) { return; }

            GraphForEdit.Vertices.Remove(v);

            List<IEdge> incidentEdges = new List<IEdge>();

            //najdi incidenční hrany
            foreach (IEdge e in GraphForEdit.Edges)
            {
                if (e.Vertex_1 == v || e.Vertex_2 == v)
                {
                    incidentEdges.Add(e);
                }
            }

            if (vHandler != null) vHandler(this, new VertexChangeArgs(v, ChangeType.Remove));

            // Odstraň incidenční hrany
            foreach (IEdge e in incidentEdges)
            {
                removeEdge(e);
            }


        }

        public void removeEdge(IEdge e)
        {
            if (e == null) { return; }

            GraphForEdit.Edges.Remove(e); //odstraní přímo tu hranu (pokud by dostal hranu s opačnými vrcholy tak jí neodstraní)
           

            if (eHandler != null) eHandler(this, new EdgeChangeArgs(e, ChangeType.Add));
        }



        public List<IEdge> previousEdges(Vertex v)
        {
          
            List<IEdge> edg = new List<IEdge>();

            if (v == null) { return edg; }

            foreach (IEdge e in GraphForEdit.Edges)
            {
                if (e.Vertex_1 == v || e.Vertex_2 == v)
                {
                    edg.Add(e);
                }
            }

            return edg;
        }
        public List<IEdge> nextEdges(Vertex v)
        {
            List<IEdge> edg = new List<IEdge>();

            if (v == null) { return edg; }

            foreach (IEdge e in GraphForEdit.Edges)
            {
                if (e.Vertex_1 == v || e.Vertex_2 == v)
                {
                    edg.Add(e);
                }
            }

            return edg;
        }
    }

    //class Non-Oriented, ÚplnýGraf  atd...
}
