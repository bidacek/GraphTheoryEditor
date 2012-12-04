using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Shapes;
using GTEditor.VisualG.ShapeG.FormaterG.VertexG;

namespace GTEditor.VisualG.ShapeG
{
    /*
	/// <summary>
    /// Podle zadaných formaterů vrací Shape pro vrcholy a hrany
    /// pořadí formaterů v listu určuje jejich priority
    /// </summary>
    public class VertexShapes
    {

     
        private List<IVertexFormater> VertexForm = new List<IVertexFormater>();
        private IGraph innerGraph;



		public VertexShapes(IGraph g)
        {
            innerGraph = g;
                
        }

        /// <summary>
        /// Add new Vertex formater, to the end of list( the lowest precedence), will be called only if all previous formater has failed
        /// </summary>
        /// <param name="v"></param>
        public void addVertexFormater(IVertexFormater v)
        {
            if (v == null || VertexForm.Contains(v)) { return; }
            VertexForm.Add(v);
        }



        /// <summary>
        /// Set actual shape of vertex, based on all formaters 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="e"></param>
        public void getShape(Vertex v, Ellipse e)
        {
            foreach (IVertexFormater f in VertexForm)
            {
                if (f.isSet(v)) {


                    f.getShape(v, e);
                    return;
                
                }
            }

            defaultShapeOfVertex(e);
        }





        private void defaultShapeOfVertex(Ellipse e)
        {
            
           e.Fill = new SolidColorBrush(Color.FromRgb(12, 12, 12));
            e.Width = 10;
            e.Height = 10;


        }

       

    }
	 * 
	 * */
}
