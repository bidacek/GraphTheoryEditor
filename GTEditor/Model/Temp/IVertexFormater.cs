using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

using GTEditor.PropertyG;
using GTEditor.SelectorG;

using GTEditor.VisualG.ShapeG.FormaterG.VertexG.ConditionG;

using System.Windows;

namespace GTEditor.VisualG.ShapeG.FormaterG.VertexG
{
   /*
    /// <summary>
    /// Vrací Shape vrcholů, pokud isSet vrací true (např když je vrchol vybrán, nebo když je splněna podmínka pro podmíněné formátování)
    /// </summary>
    public interface IVertexFormater
    {
        bool isSet(Vertex v);
        void getShape(Vertex  v, Ellipse e);
    
    }



    /// <summary>
    /// Zvýrazňuje vybrané hrany vybrané daným selectorem
    /// </summary>
    public class VertexFormSelected : IVertexFormater
    {
        private SelectorGraph innerSel;
      
        

        public VertexFormSelected(SelectorGraph sel)
        {
            innerSel = sel;

          
        }

        private void ShapeOfVertex(Ellipse e)
        {

            e.Fill = new SolidColorBrush(Colors.DarkOrange);
            e.Width = 10;
            e.Height = 10;

          

        }



        public bool isSet(Vertex v)
        {

            return innerSel.PeekSelectedPart().Vertices.Contains(v);
           
        }

        public void getShape(Vertex v, Ellipse e)
        {
            
            ShapeOfVertex(e);
        }

    }

    /// <summary>
    /// Ručně definované tvary nějakých význačných hran
    /// </summary>
    public class VertexFormSpecified : IVertexFormater
    {
        private IGraph innerGraph;
        Dictionary<Vertex, Ellipse> dict = new Dictionary<Vertex, Ellipse>();

        public VertexFormSpecified(IGraph g)
        {
            innerGraph = g;
            innerGraph.BasicVertexChange += onVertex;

        }

        public bool isSet(Vertex v)
        {
            return dict.ContainsKey(v);
        }

        public Shape getShape(Vertex v)
        {
            return dict[v];
        }

        private void onVertex(object sender,BasicVertexArgs vArgs)
        {
            if (vArgs.Type == BasicChangeType.Remove) { dict.Remove(vArgs.Vertex); }
        }


    }
    /// <summary>
    /// Podmíněné formátování, pořadí ICondtion v Listu definuje jejich priority
    /// </summary>


    public class VertexFormConditional : IVertexFormater
    {

        public List<IVertexCondition> conditions = new List<IVertexCondition>();

        public  VertexFormConditional()
        {
            
          
            
        }

        public bool isSet(Vertex v)
        {
            foreach (IVertexCondition c in conditions)
            {
               if (c.matchCondition(v)) { return true; }
            }
            return false;
        }

        public void getShape(Vertex v, Ellipse e)
        {

            foreach (IVertexCondition c in conditions)
            {
                if (c.matchCondition(v)) {
                    c.getShape(v, e);
                    return;
                }
            }
            
        }

     

    }
   


    
*/

    
}
