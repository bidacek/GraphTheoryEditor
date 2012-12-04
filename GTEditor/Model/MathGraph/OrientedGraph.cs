﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTEditor.Model.DesignPatterns.GraphSpecialized;

namespace GTEditor
{
	/// <summary>
	/// Oriented graph, which contains list of oriented edges and list of nodes
	/// </summary>
	public class OrientedGraph : Graph
	{


		#region Constructors
		/// <summary>
		/// Create empty oriented graph
		/// </summary>
		public OrientedGraph()
		{
			innerEdges = new List<IEdge>();
			innerVertices = new List<Vertex>();
			counter = 0;
		}
		#endregion





		#region AddRemoveMethods
		/// <summary>
		/// Create new node in this graph and raise corresponding event 
		/// </summary>
		/// <returns>Reference to the added node</returns>
		public override Vertex addVertex()
		{
			Vertex v = new Vertex(counter++);

			innerVertices.Add(v);



			foreach (var obs in innerVertObs)
			{
				obs.update(v, ChangeType.Added);
			}




			return v;
		}


		/// <summary>
		/// Remove vertex from this graph
		/// </summary>
		/// <param name="v">Target node</param>
		/// <returns>true if vertex was succesfully removed</returns>
		public override bool removeVertex(Vertex v)
		{
			if (v == null || !innerVertices.Contains(v)) { return false; }

			List<IEdge> incidentEdges = new List<IEdge>();

			foreach (IEdge e in innerEdges)
			{
				if (e.Vertex_1 == v || e.Vertex_2 == v) { incidentEdges.Add(e); }
			}

			foreach (IEdge e in incidentEdges)
			{
				this.removeEdge(e);
			}

			innerVertices.Remove(v);

			foreach (var obs in innerVertObs)
			{
				obs.update(v, ChangeType.Removed);
			}

			return true;


		}





		/// <summary>
		/// Create new edge between two nodes. If the same edge is already contained in this graph, new edge isn't created.
		/// </summary>
		/// <param name="v1">Starting node</param>
		/// <param name="v2">Ending node</param>
		/// <returns> Reference to the added (or finded) edge</returns>
		public override IEdge addEdge(Vertex v1, Vertex v2)
		{
			if (v1 == null || v2 == null) { return null; }

			IEdge e = new OrientedEdge(v1, v2);

			foreach (IEdge edge in innerEdges)
			{
				if (edge.Equals(e)) { return edge; }
			}

			innerEdges.Add(e);


			foreach (var obs in innerEdgeObs)
			{
				obs.update(e, ChangeType.Added);
			}


			return e;
		}

		/// <summary>
		/// Remove edge from this graph
		/// </summary>
		/// <param name="e">Target edge</param>
		/// <returns>true if edges was succesfully removed</returns>
		public override bool removeEdge(IEdge e)
		{
			if (e == null || !innerEdges.Contains(e)) { return false; }


			innerEdges.Remove(e);

			foreach (var obs in innerEdgeObs)
			{
				obs.update(e, ChangeType.Removed);
			}


			return true;


		}


		#endregion


		#region EdgesMethods
		/// <summary>
		/// Return list of incoming edges
		/// </summary>
		/// <param name="v">Target node</param>
		/// <returns>Incoming edges</returns>
		public override List<IEdge> previousEdges(Vertex v)
		{
			List<IEdge> l = new List<IEdge>();

			if (v == null) { return l; }

			foreach (IEdge e in innerEdges)
			{
				if (e.Vertex_2 == v) { l.Add(e); }
			}

			return l;
		}



		/// <summary>
		/// Return list of outcoming edges
		/// </summary>
		/// <param name="v">Target node</param>
		/// <returns>Outcoming nodes</returns>
		public override List<IEdge> nextEdges(Vertex v)
		{
			List<IEdge> l = new List<IEdge>();

			if (v == null) { return l; }

			foreach (IEdge e in innerEdges)
			{
				if (e.Vertex_1 == v) { l.Add(e); }
			}

			return l;
		}


		/// <summary>
		/// Return all edges which contains target node.
		/// </summary>
		/// <param name="v">Target node</param>
		/// <returns>Incident edges</returns>
		public override List<IEdge> incidentEdges(Vertex v)
		{
			List<IEdge> l = new List<IEdge>();

			if (v == null) { return l; }

			foreach (IEdge e in innerEdges)
			{
				if (e.Vertex_1 == v || e.Vertex_2 == v) { l.Add(e); }
			}

			return l;
		}


		#endregion



		/// <summary>
		/// Overrided ToString method, which return list of vertices on first line and list of edges on second line
		/// </summary>
		/// <returns>String explanation of this graph</returns>
		public override string ToString()
		{
			StringBuilder s = new StringBuilder();
			foreach (Vertex v in innerVertices)
			{
				s.Append(v.ToString() + ",");
			}



			s.AppendLine();



			foreach (IEdge e in innerEdges)
			{
				s.Append(e.ToString());
			}

			return s.ToString();
		}



	}
}
