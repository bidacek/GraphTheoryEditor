using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using GTEditor.Model.DesignPatterns.GraphSpecialized;
using GTEditor.Model.DesignPatterns.CommandAndMemento;

namespace GTEditor.VisualG.PositionG
{

	//TODO: Zatím se to nemaže ale jenom nastaví na null

    /// <summary>
    /// public class, which holds positions of vertices. When position of point is changed, event must be raised.
    /// </summary>
    public class Positions : IGraphObserver<Vertex>
	{

		#region Private fields
		private Dictionary<Vertex, VPoint> _vertices;
        private Graph _graph;
        private Random _random;
        private int _height;
        private int _width;
		#endregion

		#region Constructors
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

            _random = new Random(seed);

        }

        /// <summary>
        /// Create instance of this public class without setting random seed.
        /// </summary>
        /// <param name="gr">Target graph</param>
        /// <param name="width">Width of canvas</param>
        /// <param name="height">Height of canvas</param>
        public Positions(Graph gr, int width, int height)
        {
            _vertices = new Dictionary<Vertex, VPoint>();
            _graph = gr;
            _height = height;
            _width = width;
            _random = new Random();

			gr.attachObserver(this);

        }
		#endregion

		#region Properties

		/// <summary>
        /// Width of canvas
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// Height of canvas
        /// </summary>
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }


		#endregion

		#region Specific methods
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
            if (v == null  || !_graph.Vertices.Contains(v) || p == null) {return false; }
   
            VPoint point = new VPoint();
            bool okay = true;

            if (p.X < 0) { point.X = 0; okay = false;}
            else
            {
                if (p.X > _width) { point.X = _width; okay = false; }
                else { point.X = p.X; }
            }

            if (p.Top < 0) { point.Y = 0; okay = false; }
            else
            {
                if (p.Top > _height) { point.Y = _height; okay = false; }
                else { point.Y = p.Y; }
            }

            _vertices[v] = point;

         

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

            return _vertices[v];

			

           
        }





		#endregion


		#region Observer interface
		public void update(Vertex changedObject, ChangeType typeOfChange)
		{

			switch (typeOfChange)
			{
				case ChangeType.Added:
					{
						int w = _random.Next(_width);
						int h = _random.Next(_height);
						VPoint v = new VPoint(w,h);

						_vertices[changedObject] = v;
						break;
					}

				case ChangeType.Removed:
					{
						
						_vertices.Remove(changedObject);
						break;
					}

			}

		}

		#endregion

		#region Originator interface

		public IMemento getMemento()
		{
			return new FullMemento(this);
		}

		public IMemento getMemento(Vertex changedObject)
		{
			return new PartialMemento(this, changedObject);
		}


		private class FullMemento : IMemento
		{
			Positions _positions;
			Dictionary<Vertex, VPoint> _vertices;

			public FullMemento(Positions pos)
			{
				_positions = pos;
				_vertices = new Dictionary<Vertex, VPoint>(pos._vertices);
			}

			public void Rollback()
			{
				_positions._vertices = _vertices;				
			}
		}

		private class PartialMemento : IMemento
		{
			private Positions  _position;
			private Vertex _vertex;
			private VPoint _point;

			public PartialMemento(Positions pos,Vertex v)
			{
				_position = pos;
				_vertex = v;
				_point = _position._vertices[v];

			}


			public void Rollback()
			{
				_position._vertices[_vertex] = _point;
			}
		}

		#endregion
	}
}
