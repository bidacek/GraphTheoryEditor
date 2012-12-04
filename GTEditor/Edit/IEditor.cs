using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTEditor.Edit
{
    /// <summary>
    /// Zajišťuje základní operace s grafem jako přidávání a mazaní vrcholů či hran. Tyto operace vyvolávají příslušný event (odchytávají ho skoro všechny ostatní třídy) 
    /// NextEdges a PreviousEdges jsou spíš pro pohodlí a optimalizaci (může to být cacheováno nebo v úplně jiné vnitřní reprezentaci grafu než moje class Graph)
    /// </summary>
    interface IEditor
    {   
       
        Graph GraphForEdit
        {
            get;
        }

        EdgeEventHandler eHandler { get; set; }

        VertexEventHandler vHandler { get; set; }

        /// <summary>
        /// Přidá hranu do našeho grafu a vyvolá příslušný event s parametrem ChangeType.Add
        /// </summary>
        /// <param name="v"></param>
        void addVertex(Vertex v);

        /// <summary>
        /// Přidá hranu do našeho grafu a vyvolá příslušný event s parametrem ChangeType.Add
        /// </summary>
        /// <param name="e">Vybraná hrana</param>
        void addEdge(IEdge e);

        /// <summary>
        /// Odstraní vrchol z grafu a vyvolá příslušný event s parametrem typu ChangeType.Remove
        /// </summary>
        /// <param name="v">Vybraný vrchol</param>
        void removeVertex(Vertex v);

        /// <summary>
        /// Odstraní hranu z grafu a vyvolá příslušný event s parametrem typu ChangeType.Remove
        /// </summary>
        /// <param name="e">Vybraná hrana</param>
        void removeEdge(IEdge e);

        /// <summary>
        /// Returns edges, which goes to this node. In oriented graph it means input edges,but In non-oriented graph is always true that previousEdges == nextEdges.
        /// </summary>
        /// <param name="v"> Vertex </param>
        /// <returns></returns>
        List<IEdge> previousEdges(Vertex v);

        /// <summary>
        /// Returns edgs, which goes from this node. In oriented graph it means output edges,but In non-oriented graph is always true that previousEdges == nextEdges.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        List<IEdge> nextEdges(Vertex v);
    }


    delegate void EdgeEventHandler(object sender, EdgeChangeArgs eArgs);
    delegate void VertexEventHandler(object sender, VertexChangeArgs vArgs);

    class EdgeChangeArgs : EventArgs
    {
        public IEdge edge;
        public ChangeType type;

        public EdgeChangeArgs(IEdge e, ChangeType t)
        {
            edge = e;
            type = t;
        }
    }


    class VertexChangeArgs : EventArgs
    {
        public Vertex vertex;
        public ChangeType type;

        public VertexChangeArgs(Vertex v, ChangeType t)
        {
            vertex = v;
            type = t;
        }
    }



    /// <summary>
    /// Operace s vrcholem či hranou, zasílaná prostřednictvím eventů
    /// </summary>
    enum ChangeType
    {
        Add, Remove
    }


}
