using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTEditor.VisualG.PositionG;
using GTEditor.Model.Predelane;

namespace GTEditor.ViewModel
{
	class GraphViewModel
	{
		List<VertexVievModel> vertices = new List<VertexVievModel>();
		private static Graph g = new OrientedGraph();
		private static Positions p = new Positions(g,500,500);
		private static Names n = new Names(g);


		public GraphViewModel()
		{
			for (int i = 0; i < 8; i++)
			{
				Vertex v = new Vertex();
				g.addVertex(v);

				vertices.Add(new VertexVievModel(v, g, p, n));
			}

		

		}
		public List<VertexVievModel> Vertices
		{
			get
			{
				return vertices;
			} 
		}
	}
}
