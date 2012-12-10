using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using GTEditor.SelectorG;
using System.Collections.ObjectModel;
using System.Windows;
using GTEditor.Model.DesignPatterns.GraphSpecialized;
using GTEditor.Model.DesignPatterns.CommandAndMemento;

namespace GTEditor.VisualG.LayerG
{
    /// <summary>
    /// Zachycuje vizuální podobu grafu při práci s vrstvami (skrývání a uzamykání)
    /// Přidává se do aktuální vrstvy vždy.
    /// Když do neviditelného vrcholu vede alespoň jedna viditelná hrana, tak ho zviditelní, ale uzamkne.
    /// </summary>
    public  class LayerGraph : IGraphObserver<Vertex>, IGraphObserver<IEdge>
    {


        private Layer activeLayer;
        private ObservableCollection<Layer> layers = new ObservableCollection<Layer>();
        private Graph innerGraph;
        private int counter = 0;

        Dictionary<IEdge, Layer> dictEdge = new Dictionary<IEdge, Layer>();
        Dictionary<Vertex, Layer> dictVertex = new Dictionary<Vertex, Layer>();

     
        


        public LayerGraph(Graph gr)
        {
            if (gr == null) { throw new Exception("Layered graph get null value graph"); }

            
            innerGraph = gr;


            activeLayer = new Layer("Default layer");

            layers.Add(activeLayer);



        }

        /// <summary>
        /// Returns observable collection of all the layers
        /// </summary>
        public ObservableCollection<Layer> Layers
        {
            get { return layers; }
        }


        /// <summary>
        /// Return layer, which is actually active. All vertices and edges are added to this layer.
        /// </summary>
        public Layer ActiveLayer
        {
            get { return activeLayer; }
        }


        /// <summary>
        /// Create new layer with determined name, which should be unique, if not the name is changed.
        /// </summary>
        /// <param name="name"></param>
        public void addLayer(string name)
        {
            foreach (Layer l in layers)
            {
                if (l.Name == name) { name = name + counter++.ToString(); }
            }

            Layer layer = new Layer(name);
     
            layers.Add(layer);

        }

       
        /// <summary>
        /// Merge two layers to one layer 
        /// </summary>
        /// <param name="from">Layer, which will be deleted</param>
        /// <param name="to">Target layer </param>
        public void mergeLayer(Layer from, Layer to)
        {
            if (from == null || !layers.Contains(from) || to == null || !layers.Contains(to)) { return; }

            moveGraphPartToLayer(from.PartOfGraph, to.Name);

            if (activeLayer == from) { activeLayer = to; }

            layers.Remove(from);
        }

       

        public void setActiveLayer(string name)
        {
            foreach (Layer l in layers)
            {
                if (l.Name == name) { activeLayer = l; } 
            }
        }

        public void moveGraphPartToLayer(GraphPart p, string targetLayer)
        {
            Layer l = null;

            foreach (Layer lay in layers)
            {
                if (lay.Name == targetLayer) { l = lay; break; }
            }
            
            if (l == null || p == null) { return; }

            l.PartOfGraph.Union(p);

            foreach (IEdge e in p.Edges)
            {

                dictEdge[e].PartOfGraph.Edges.Remove(e);
                dictEdge[e] = l;
            }

            foreach (Vertex v in p.Vertices)
            {
                dictVertex[v].PartOfGraph.Vertices.Remove(v);
                dictVertex[v] = l;
            }


        }


        /// <summary>
        /// Return true if this edge is visible
        /// </summary>
        /// <param name="e">Target edge</param>
        /// <returns></returns>
        public bool isVisible(IEdge e)
        {
            return dictEdge[e].IsVisibleLayer;
        }

        /// <summary>
        /// Return true if this vertex is visible
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool isVisible(Vertex v)
        {
            if (dictVertex[v].IsVisibleLayer) { return true; }
            else
            {
                //Některá incidentní hrana je viditelná tudíž vrchol musí být také viditelný
                foreach (IEdge e in innerGraph.incidentEdges(v))
                {
                    if (isVisible(e)) { return true; }
                }
            }

            return false;
        }


        /// <summary>
        /// Return true if this edge is locked (can't click on it) 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool isLocked(IEdge e)
        {
            return dictEdge[e].IsLockedLayer;
        }

        /// <summary>
        /// Return true if this vertex is locked (can't click on it)
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool isLocked(Vertex v)
        {
            return dictVertex[v].IsLockedLayer;
        }


        /// <summary>
        /// Return visible part of graph (part contained in visible layers)
        /// </summary>
        /// <returns></returns>
        public GraphPart getVisiblePart()
        {
            GraphPart p = new GraphPart();

            foreach (IEdge e in innerGraph.Edges)
            {
                if (isVisible(e)) { p.Edges.Add(e); }
            }

            foreach (Vertex v in innerGraph.Vertices)
            {
                if (isVisible(v)) { p.Vertices.Add(v); }
            }

            return p;
        }

        /// <summary>
        /// Return unlocked part of graph (part contained in layers, which aren't locked)
        /// </summary>
        /// <returns></returns>
        public GraphPart getUnlockedPart()
        {
            GraphPart p = new GraphPart();

            foreach (IEdge e in innerGraph.Edges)
            {
                if (!isLocked(e)) { p.Edges.Add(e); }
            }

            foreach (Vertex v in innerGraph.Vertices)
            {
                if (!isLocked(v)) { p.Vertices.Add(v); }
            }

            return p;
        }




		public void update(Vertex changedObject, ChangeType typeOfChange)
		{
			throw new NotImplementedException();
		}

		public IMemento getMemento()
		{
			throw new NotImplementedException();
		}




		public IMemento getMemento(Vertex changedObject)
		{
			throw new NotImplementedException();
		}

		public void update(IEdge changedObject, ChangeType typeOfChange)
		{
			throw new NotImplementedException();
		}


		public IMemento getMemento(IEdge changedObject)
		{
			throw new NotImplementedException();
		}
	}
}
