using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTEditor.Model.DesignPatterns.CommandAndMemento;
using GTEditor.VisualG.PositionG;
using GTEditor.Model.Predelane;

namespace GTEditor.Ladeni
{
	class Parser
	{

		Invoker _invoker = new Invoker();
		Graph g = new NonOrientedGraph();
		Positions pos;
		Names nam;


		public Graph Graph
		{
			get
			{
				return g;
			}
		}




		public Parser()
		{
			pos = new Positions(g,500,400);
			nam = new Names(g);

		}

		public void ExecuteCommand(string s)
		{
			string[] pole = s.Split(new char[]{' '});

			switch (pole[0])
			{
				case "AddV" :

					
				
					int x = 0;
 					int.TryParse(pole[1],out x);
					int y = 0;
					int.TryParse(pole[2],out y);

					ICommand c = new AddVToPosCommand(g, pos, x, y);

					_invoker.ExecuteCommand(c);

						break;
					
				case "DeleteV" :

						Vertex v = nam.getVertex(pole[1]);

						ICommand d = new DeleteVertexCommand(g, v);

						_invoker.ExecuteCommand(d);


						break;


				case "AddE" :


						ICommand e = new AddEdgeCommand(g, nam.getVertex(pole[1]), nam.getVertex(pole[2]));
						_invoker.ExecuteCommand(e);

						break;

				case "DeleteE" :

						ICommand f = new DeleteEdgeCommand(g, nam.getEdge(pole[1], pole[2]));
						_invoker.ExecuteCommand(f);
						break;

				case "Undo" :

						_invoker.UndoCommand();

						break;
			}



		}
	}









	class AddVToPosCommand : ICommand
	{
		Graph innGraph;
		Positions _pos;
		int _x;
		int _y;

	
		public AddVToPosCommand(Graph gr,Positions pos,int x, int y)
		{
			innGraph = gr;
			_pos = pos;
			_x = x;
			_y = y;


		
		}
		
		public override void Execute()
		{
			Vertex v =  new Vertex();
			mementos.Add(innGraph.getMemento());
			
			innGraph.addVertex(v);
			_pos.setPosition(v,new VPoint(_x, _y));
		}



	}


	class DeleteVertexCommand : ICommand
	{
		Graph innGraph;
		Vertex innVertex;

		public DeleteVertexCommand(Graph gr, Vertex v)
		{
			innGraph = gr;
			innVertex = v;
		}

		public override void Execute()
		{
			mementos.Add(innGraph.getMemento());
			innGraph.removeVertex(innVertex);
		}
	}

	//TODO: predelat metodu grafu addEdge aby se dala pridávat hrana pomoci addEdge(IEdge e) ... ale nastává problém s orient vs neorientovaný někdo by mohl narvat do orientovanýho grafu hranu neorientovanou
	class AddEdgeCommand : ICommand
	{
		private Graph _graph;
		private IEdge _edge;

		public AddEdgeCommand(Graph g, Vertex v1, Vertex v2)
		{
			mementos.Add(g.getMemento());
			
			_edge = g.addEdge(v1, v2);

		}

		public override void Execute()
		{

		}
	}

	class DeleteEdgeCommand : ICommand
	{
		private IEdge _edge;
		private Graph _graph;

		public DeleteEdgeCommand(Graph g, IEdge e)
		{
			_graph = g;
			_edge = e;
		}
		
		public override void Execute()
		{
			mementos.Add(_graph.getMemento());

			_graph.removeEdge(_edge);
		}

	}

}
