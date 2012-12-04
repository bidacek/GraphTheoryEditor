using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTEditor.VisualG.PositionG
{
    /// <summary>
    /// public class for saving information about position of vertices on canvas.
    /// </summary>
    public class VPoint
    {

        private static readonly int radiusOfVertex = 5;   // tohle se musí dořešit jak přepočítávat 
        
        private double x;
        private double y;

        /// <summary>
        /// Set new point to 0,0 (left top corner)
        /// </summary>
        public VPoint()
            : this(0, 0)
        {
        }

        /// <summary>
        /// Create new point with specified coordinates
        /// </summary>
        /// <param name="l">Distance from left border</param>
        /// <param name="t">Distance from top border</param>
        public VPoint(double xpos, double ypos)
        {
            x = xpos;
            y = ypos;
        }

        /// <summary>
        /// Distance from left border of canvas
        /// </summary>
        public double Left
        {
            get { return x - radiusOfVertex; }
            
            
        }

        /// <summary>
        /// Distance from top border of canvas
        /// </summary>
        public double Top
        {
            get { return y - radiusOfVertex; }
    
        }

        public double X
        {
           get {return x;}
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value;  }

        }

    }

 

}
