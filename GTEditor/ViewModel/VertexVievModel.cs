using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTEditor.Model.Predelane;
using GTEditor.VisualG.PositionG;

namespace GTEditor.ViewModel
{
	class VertexVievModel
	{
		private Vertex vertex;
		private Graph graph;
		private Names namedGraph;
		private Positions positionedGraph;

		public VertexVievModel(Vertex v, Graph g, Positions p, Names n)
		{
			vertex= v;

			graph = g;
			positionedGraph = p;

			namedGraph = n;

		}


		public string Name
		{
			get
			{
				return namedGraph.getName(vertex);
			}
		}

		public double Xsouradnice
		{
			get {return positionedGraph.getPosition(vertex).Left;}
		}

		public double Ysouradnice
		{
			get
			{
				return positionedGraph.getPosition(vertex).Top;
			}
		}
	}
}
