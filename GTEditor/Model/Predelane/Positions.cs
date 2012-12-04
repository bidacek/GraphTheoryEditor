using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using GTEditor.Model.DesignPatterns.GraphSpecialized;
using GTEditor.Model.DesignPatterns.CommandAndMemento;

namespace GTEditor.VisualG.PositionG
{
    /// <summary>
    /// public class, which holds positions of vertices. When position of point is changed, event must be raised.
    /// </summary>
    public class Positions : IGraphObserver<Vertex>
    {
        private Dictionary<Vertex, VPoint> vertices;
        private Graph innerGraph;
        private Random innerRandom;
        private int innerHeight;
        private int innerWidth;

       
    
        /// <summary>
        /// Create instance of this public class width specified random seed.
        /// </summary>
        /// <param name="gr">Target graph</param>
        /// <param name="seed">Specified seed for random vertex positions</param>
        /// <param name="width">Width of canvas</param>
        /// <param name="height">Height of canvas</param>
        public Positions(Graph gr, int seed, int width, int height) 
            : this(gr,width,height)
        {

            innerRandom = new Random(seed);

        }

        /// <summary>
        /// Create instance of this public class without setting random seed.
        /// </summary>
        /// <param name="gr">Target graph</param>
        /// <param name="width">Width of canvas</param>
        /// <param name="height">Height of canvas</param>
        public Positions(Graph gr, int width, int height)
        {
            vertices = new Dictionary<Vertex, VPoint>();
            innerGraph = gr;
            innerHeight = height;
            innerWidth = width;
            innerRandom = new Random();

			gr.attachObserver(this);

        }

        /// <summary>
        /// Width of canvas
        /// </summary>
        public int Width
        {
            get { return innerWidth; }
            set { innerWidth = value; }
        }

        /// <summary>
        /// Height of canvas
        /// </summary>
        public int Height
        {
            get { return innerHeight; }
            set { innerHeight = value; }
        }

        public bool setPosition(Vertex v, Point p)
        {
           VPoint vp = new VPoint(p.X,p.Y);
        
            return setPosition(v, vp);
        }

        /// <summary>
        /// Set position of given vertex. Position can't be out of range of this canvas (it's modified, when this situation occurs).
        /// Left property has to be between 0 and width of this canvas and top property has to be between 0 and height of this canvas.
        /// </summary>
        /// <param name="v">Target vertex</param>
        /// <param name="p">Specified point</param>
        /// <returns>true if vertex has been moved exactly to given point  </returns>
        public bool setPosition(Vertex v, VPoint p)
        {
            //Check whether the new point is equal to old point 
            if (v == null  || !innerGraph.Vertices.Contains(v) || p == null) {return false; }
   
            VPoint point = new VPoint();
            bool okay = true;

            if (p.X < 0) { point.X = 0; okay = false;}
            else
            {
                if (p.X > innerWidth) { point.X = innerWidth; okay = false; }
                else { point.X = p.X; }
            }

            if (p.Top < 0) { point.Y = 0; okay = false; }
            else
            {
                if (p.Top > innerHeight) { point.Y = innerHeight; okay = false; }
                else { point.Y = p.Y; }
            }

            vertices[v] = point;

         

            return okay;

        }


        /// <summary>
        /// Get position of specified vertex
        /// </summary>
        /// <param name="v">Target vertex</param>
        /// <returns>Point of this vertex</returns>
        public VPoint getPosition(Vertex v)
        {
            if (v == null) { return null; }

            return vertices[v];

           
        }










		public void update(Vertex changedObject, ChangeType typeOfChange)
		{

			switch (typeOfChange)
			{
				case ChangeType.Added:
					{
						int w = innerRandom.Next(innerWidth);
						int h = innerRandom.Next(innerHeight);
						VPoint v = new VPoint(w,h);

						vertices.Add(changedObject, v);
						break;
					}

				case ChangeType.Removed:
					{
						
						vertices.Remove(changedObject);
						break;
					}

			}

		}

		public IMemento getMemento()
		{
			return new FullMemento(this);
		}

		public IMemento getMemento(Vertex changedObject, ChangeType typeOfChange)
		{
			throw new NotImplementedException();
		}


		private class FullMemento : IMemento
		{
			Positions innerPos;
			Dictionary<Vertex, VPoint> innerDict;

			public FullMemento(Positions pos)
			{
				innerPos = pos;
				innerDict = new Dictionary<Vertex, VPoint>(pos.vertices);
			}



			public void Rollback()
			{
				innerPos.vertices = innerDict;				
			}
		}
	}
}
