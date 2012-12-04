using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using GTEditor.Model.DesignPatterns.GraphSpecialized;
using GTEditor.Model.DesignPatterns.CommandAndMemento;


namespace GTEditor.SelectorG
{
    /// <summary>
    /// Defines the part of graph, which is actually selected. You can set some task (interface Task) to this selector.
    /// </summary>
    public class SelectorGraph : IGraphObserver<Vertex>, IGraphObserver<IEdge>
    {
        private Graph innerGraph;
        private Operation innerActOp = Operation.Union;
        private GraphPart innerGp = new GraphPart();
        private IFilter innerFilter = new GraphFilter();

       

        public SelectorGraph(Graph g)
        {
            innerGraph = g;
            innerActOp = Operation.Union;


        }



        public IFilter Filter
        {
            get { return innerFilter; }
            set
            {
                if (value != null)
                {
                    innerFilter = value;
                }
            }
        }
           

        public GraphPart PeekSelectedPart()
        {
            return innerGp;
        }

        public GraphPart PopSelectedPart()
        {
            GraphPart g = innerGp;
            innerGp = new GraphPart();
            return g;

            
        }

        public void PushPart(GraphPart gp)
        {
            innerGp = gp;
            innerFilter.filterPart(innerGp);
        }

        public void PushPartWithControl(GraphPart g)
        {
            switch (innerActOp)
            {
                case Operation.Union:
                    {
                        innerGp.Union(g);
                        
                        break;
                    }
                case Operation.Intersect:
                    {
                        innerGp.Intersect(g);
                        break;
                    }
                case Operation.Except:
                    {
                        innerGp.Except(g);
                        break;
                    }
            }

            innerFilter.filterPart(innerGp);
        }




		public void update(Vertex changedObject, ChangeType typeOfChange)
		{
			throw new NotImplementedException();
		}

		public IMemento getMemento()
		{
			throw new NotImplementedException();
		}

		public IMemento getMemento(Vertex changedObject, ChangeType typeOfChange)
		{
			throw new NotImplementedException();
		}

		public void update(IEdge changedObject, ChangeType typeOfChange)
		{
			throw new NotImplementedException();
		}


		public IMemento getMemento(IEdge changedObject, ChangeType typeOfChange)
		{
			throw new NotImplementedException();
		}
	}


    public enum Operation
    {
        Union, Intersect,Except
    }
}
