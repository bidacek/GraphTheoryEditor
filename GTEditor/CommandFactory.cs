using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTEditor.Model.DesignPatterns.CommandAndMemento;

namespace GTEditor
{
	/// <summary>
	/// There will be command Factory
	/// 
	/// </summary>
	class CommandFactory
	{
	}


	class AddVertexCommand : ICommand
	{
		Graph innGraph;


		public AddVertexCommand(Graph gr)
		{
			innGraph = gr;

		}

		public override void Execute()
		{
			mementos.Add(innGraph.getMemento());
			innGraph.addVertex();
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



}
