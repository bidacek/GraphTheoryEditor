using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

using GTEditor.PropertyG;
using GTEditor.SelectorG;
using GTEditor.VisualG.PositionG;
using GTEditor.VisualG.ShapeG;
using GTEditor.VisualG.LayerG;
using GTEditor.VisualG.ShapeG.FormaterG.VertexG;
using GTEditor.VisualG.ShapeG.FormaterG.VertexG.ConditionG;

using System.Windows;
using System.Windows.Media;


namespace GTEditor
{/* /// <summary>
    /// Representation of painted graf in two canvases, first contains ellipses (vertices) and second contains lines (edges)
    /// </summary>
    public class PaintedGraph
    {


        private Canvas verticesCanvas = new Canvas();
        private Canvas edgesCanvas = new Canvas();
        private Dictionary<Vertex, Ellipse> vertElipse = new Dictionary<Vertex, Ellipse>();
        private Dictionary<Ellipse, Vertex> vertElipseRev = new Dictionary<Ellipse, Vertex>();
        private Dictionary<IEdge, Line> edgeLine = new Dictionary<IEdge, Line>();
        private Dictionary<Line, IEdge> edgeLineRev = new Dictionary<Line, IEdge>();


        private IGraph innerGraph;
        private SelectorGraph innerSelector;
        private Positions innerPositions;
        private PropertyGraph innerPropBag;
        private LayerGraph innerLayeredG;

        private GraphPart graphPart = new GraphPart();




        public PaintedGraph(IGraph g, SelectorGraph sel,Positions pos, PropertyGraph prop, LayerGraph lay, ShapeGraph sh)
        {

          
            innerGraph = g;
            innerSelector = sel;
            innerPositions = pos;
            innerPropBag = prop;
            innerLayeredG = lay;
            innerShaper = sh;

       


            

        }


        /// <summary>
        /// Canvas with edges
        /// </summary>
        public Canvas EdgeCanvas
        {
            get { return edgesCanvas; }
        }

        /// <summary>
        /// Canvas with vertices
        /// </summary>
        public Canvas VertexCanvas
        {
            get { return verticesCanvas; } 
        }

        /// <summary>
        /// Returns graphart in this rectangle area
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="pt2"></param>
        /// <returns></returns>
        public GraphPart getGraphPart(Point pt, Point pt2)
        {
            Rect a = new Rect(pt, pt2);

            RectangleGeometry geom = new RectangleGeometry(a);
            return getGraphPart(geom);
        }

        /// <summary>
        /// Returns Graphpart drawn on this point 
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public GraphPart getGraphPart(Point pt)
        {

            EllipseGeometry geom = new EllipseGeometry(pt, 1, 1);
            return getGraphPart(geom);
         
        }

      
        /// <summary>
        /// Return Graphpart drawn in this geomerty shape
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public GraphPart getGraphPart(Geometry g)
        {

            graphPart = new GraphPart();

            hitResultsListE.Clear();
            hitResultsListV.Clear();

            VisualTreeHelper.HitTest(verticesCanvas, null, new HitTestResultCallback(MyHitTestVertexResult), new GeometryHitTestParameters(g));

            VisualTreeHelper.HitTest(edgesCanvas, null, new HitTestResultCallback(MyHitTestEdgeResult), new GeometryHitTestParameters(g));

            graphPart.Edges = hitResultsListE;
            graphPart.Vertices = hitResultsListV;

            return graphPart;
        }


        List<IEdge> hitResultsListE = new List<IEdge>();
        List<Vertex> hitResultsListV = new List<Vertex>();



        #region HitTesting
        /// <summary>
       /// Uklada do listu pri jakem koliv kontaktu ... dořešit tahy zleva a zprava atd.
       /// </summary>
       /// <param name="result"></param>
       /// <returns></returns>
        private HitTestResultBehavior MyHitTestEdgeResult(HitTestResult result)
        {
            IntersectionDetail intersectionDetail = ((GeometryHitTestResult)result).IntersectionDetail;

            IEdge e = edgeLineRev[(Line)result.VisualHit];

            if (!innerLayeredG.isLocked(e)) { hitResultsListE.Add(e); }

            switch (intersectionDetail)
            {
                case IntersectionDetail.FullyContains:
                    {
                       
                 
                        return HitTestResultBehavior.Continue;
                    }
                case IntersectionDetail.Intersects:
                    {
                       
                    
                    return HitTestResultBehavior.Continue;
                    }
                case IntersectionDetail.FullyInside:
                    {
                        

                        return HitTestResultBehavior.Continue;
                    }
                default:
                    return HitTestResultBehavior.Stop;
            }

            
        }

        /// <summary>
        /// Uklada do listu pri jakemkoliv kontaktu ... dořešit tahy zleva a zprava
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private HitTestResultBehavior MyHitTestVertexResult(HitTestResult result)
        {
            IntersectionDetail intersectionDetail = ((GeometryHitTestResult)result).IntersectionDetail;

            Vertex v = vertElipseRev[(Ellipse)result.VisualHit];
            if (!innerLayeredG.isLocked(v)) { hitResultsListV.Add(v); }
         

            switch (intersectionDetail)
            {
                case IntersectionDetail.FullyContains:
                    {
                        

                        return HitTestResultBehavior.Continue;
                    }
                case IntersectionDetail.Intersects:
                    {
                        

                        return HitTestResultBehavior.Continue;
                    }
                case IntersectionDetail.FullyInside:
                    {
                        return HitTestResultBehavior.Continue;
                    }
                default:
                    return HitTestResultBehavior.Stop;
            }


        }
        #endregion





    }
  */

}
