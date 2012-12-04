using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using GTEditor.VisualG.PositionG;
using GTEditor.SelectorG;
using GTEditor.PropertyG;
using GTEditor.VisualG.ShapeG;
using GTEditor.VisualG.LayerG;
using GTEditor.VisualG.ShapeG.FormaterG.VertexG;
using GTEditor.VisualG.ShapeG.FormaterG.VertexG.ConditionG;
using System.Windows.Shapes;
using System.Collections.Generic;
using GTEditor.Model.DesignPatterns.CommandAndMemento;
using System.Diagnostics;






namespace GTEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

      


        public MainWindow()
        {

			Graph graph = new OrientedGraph();

			




			Positions positions = new Positions(graph, 500, 500);


			Invoker MyInvoker = new Invoker();

			AddVertexCommand a = new AddVertexCommand(graph);

			AddVertexCommand b = new AddVertexCommand(graph);

			AddVertexCommand c = new AddVertexCommand(graph);


			MyInvoker.ExecuteCommand(a);

			Debug.WriteLine(graph.ToString());

			MyInvoker.ExecuteCommand(b);

			Debug.WriteLine(graph.ToString());

			MyInvoker.ExecuteCommand(c);

			Debug.WriteLine(graph.ToString());

			




			MyInvoker.UndoCommand();

			MyInvoker.UndoCommand();

			

			Debug.WriteLine(graph.ToString());


		
				



            
        }

     
      
       


      
    }

   
}
