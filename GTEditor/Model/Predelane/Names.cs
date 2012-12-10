using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTEditor.Model.DesignPatterns.GraphSpecialized;
using GTEditor.Model.DesignPatterns.CommandAndMemento;

namespace GTEditor.Model.Predelane
{
	
	class Names : IGraphObserver<Vertex>
	{
		Dictionary<string,Vertex> vert = new Dictionary<string,Vertex>();
		Dictionary<Vertex, string> reversVert = new Dictionary<Vertex, string>();

		private int _counter = 0;
		Graph innGraph;

		public Names(Graph g)
		{
			innGraph = g;
			g.attachObserver(this);
			
		}

		public Vertex getVertex(string s)
		{
			return vert[s];
		}


		//TODO: pomaly a nespolehlivy
		public IEdge getEdge(string v1, string v2)
		{
			Vertex vr1 = vert[v1];
			Vertex vr2 = vert[v2];

			

			foreach ( IEdge e in innGraph.Edges)
			{
				if ((e.Vertex_1 == vr1 && e.Vertex_2 == vr2) || (e.Vertex_1 == vr2) && (e.Vertex_2 == vr1))
				{
					return e;
				}
			}

			throw new Exception("Edge doesnt exist");
		}


		public string getName(Vertex v)
		{
			return reversVert[v];
		}


		#region Observer interface
		public void update(Vertex changedObject, ChangeType typeOfChange)
		{

			switch (typeOfChange)
			{
				case ChangeType.Added:
					{
						vert[_counter.ToString()] = changedObject;
						reversVert[changedObject] = _counter.ToString();

						_counter++;
						break;
					}
				case ChangeType.Removed:
					{
						string keyRev = reversVert[changedObject];

						reversVert.Remove(changedObject);
						vert.Remove(keyRev);
						break;
					}

			}

		}


		#endregion

		#region Originator interface

		public IMemento getMemento()
		{
			return new FullMemento(this);
		}


		
		

		public IMemento getMemento(Vertex changedObject)
		{
			throw new NotImplementedException();
		}





		private class FullMemento : IMemento
		{
			private Dictionary<string,Vertex> _vert;
			private Dictionary<Vertex, string> _revVert;
			private Names _names;

			public FullMemento(Names n)
			{
				_names = n;
				_vert = new Dictionary<string, Vertex>(n.vert);
				_revVert = new Dictionary<Vertex, string>(n.reversVert);



			}

			public void Rollback()
			{
				_names.vert = _vert;
				_names.reversVert = _revVert;

			}
		}

		#endregion
	}
}
