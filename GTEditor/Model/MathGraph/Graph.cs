using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTEditor.Model.DesignPatterns.GraphSpecialized;
using GTEditor.Model.DesignPatterns.CommandAndMemento;



namespace GTEditor
{
	/// <summary>
	/// Math definition of graph, which contains list of edges (oriented or nonoriented) and list of vertices. Multiedges aren't allowed.
	/// </summary>
	public abstract class Graph : IGraphSubject<IEdge>, IGraphSubject<Vertex>
	{

		protected List<IEdge> innerEdges;
		protected List<Vertex> innerVertices;
		protected int counter;

		protected List<IGraphObserver<Vertex>> innerVertObs = new List<IGraphObserver<Vertex>>();
		protected List<IGraphObserver<IEdge>> innerEdgeObs = new List<IGraphObserver<IEdge>>();




		//TODO: jenom pokus je tohle

		public void getList(out List<IEdge> list) 
		{
					list = innerEdges;
		}


		public void getList(out List<Vertex> list)
		{
			list = innerVertices;
		}





		/// <summary>
		/// Returns list of edges
		/// </summary>
		public List<IEdge> Edges
		{
			get
			{
				return innerEdges;
			}
		}

		/// <summary>
		/// Returns list of vertices
		/// </summary>
		public List<Vertex> Vertices
		{
			get
			{
				return innerVertices;
			}
		}

		/// <summary>
		/// Add vertex to this graph
		/// </summary>
		/// <returns>Reference to the added vertex</returns>
		public abstract Vertex addVertex(Vertex v);


		/// <summary>
		/// Remove vertex from this graph
		/// </summary>
		/// <param name="v">Target vertex</param>
		/// <returns>true if vertex was succesfully removed</returns>
		public abstract bool removeVertex(Vertex v);

		/// <summary>
		/// Add edge between two nodes.
		/// </summary>
		/// <param name="v1">First node</param>
		/// <param name="v2">The other node</param>
		/// <returns>Reference to the added edge</returns>
		public abstract IEdge addEdge(Vertex v1, Vertex v2);

		/// <summary>
		/// Remove edge from this graph.
		/// </summary>
		/// <param name="e">Target edge</param>
		/// <returns>true if edge was succesfully removed</returns>
		public abstract bool removeEdge(IEdge e);

		/// <summary>
		/// Return edges, which are going to this node
		/// </summary>
		/// <param name="v">Target node</param>
		/// <returns> Incoming edges </returns>
		public abstract List<IEdge> previousEdges(Vertex v);


		/// <summary>
		/// Return edges, which are going from this node
		/// </summary>
		/// <param name="v">Target node</param>
		/// <returns>Outcoming edges</returns>
		public abstract List<IEdge> nextEdges(Vertex v);

		/// <summary>
		/// Return all edges, which contains this node
		/// </summary>
		/// <param name="v">Target node</param>
		/// <returns>Incident edges</returns>
		public abstract List<IEdge> incidentEdges(Vertex v);



		public void attachObserver(IGraphObserver<IEdge> ob)
		{
			innerEdgeObs.Add(ob);
		}

		public void detachObserver(IGraphObserver<IEdge> ob)
		{
			innerEdgeObs.Remove(ob);
		}

		public void attachObserver(IGraphObserver<Vertex> ob)
		{
			innerVertObs.Add(ob);
		}

		public void detachObserver(IGraphObserver<Vertex> ob)
		{
			innerVertObs.Remove(ob);
		}





		private class FullMemento : IMemento
		{
			private List<IEdge> zalohaEdges;
			private List<Vertex> zalohaVertices;
			private int zalohacounter;
			private Graph originator;

			private List<IMemento> mementosFromObservers;


			public FullMemento(Graph o, List<IMemento> memFromObservers)
			{
				originator = o;
				zalohacounter = o.counter;
				zalohaEdges = new List<IEdge>(o.innerEdges);

				zalohaVertices = new List<Vertex>(o.innerVertices);


				mementosFromObservers = memFromObservers;

			}


			public void Rollback()
			{

				originator.counter = zalohacounter;
				originator.innerEdges = zalohaEdges;
				originator.innerVertices = zalohaVertices;

				foreach (var mem in mementosFromObservers)
				{
					mem.Rollback();
				}

			}
		}

		private class PartialMemento<T> : IMemento where T: GraphObject
		{
			Graph innGraph;
			T innObject;
			List<T> innList;
			

			public PartialMemento(Graph gr, T obj, List<T> list)
			{

				innGraph = gr;
				innObject = obj;
				innList = list;

						
				
			}

			public void Rollback()
			{
				if (innList.Contains(innObject))
				{
					innList.Remove(innObject);

				}
				else
				{
					innList.Add(innObject);
				}
			}


		}





	


		public IMemento getMemento()
		{
			List<IMemento> m = new List<IMemento>();

			foreach (var eObs in innerEdgeObs)
			{

				m.Add(eObs.getMemento());
			}

			foreach (var vObs in innerVertObs)
			{
				m.Add(vObs.getMemento());

			}

			return new FullMemento(this, m);


		}





		public IMemento getMemento(IEdge changedObject)
		{
			return new PartialMemento<IEdge>(this, changedObject, innerEdges);
		}

		public IMemento getMemento(Vertex changedObject)
		{
			return new PartialMemento<Vertex>(this, changedObject, innerVertices);
		}
	}




}



