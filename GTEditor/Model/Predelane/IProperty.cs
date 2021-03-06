﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTEditor.Model.DesignPatterns.GraphSpecialized;
using GTEditor.Model.DesignPatterns.CommandAndMemento;



namespace GTEditor.PropertyG
{


	public interface DProperty<V>
	{
		string getValue(V target);
		void setValue(V target, string value);
	}



	public interface EProperty<V, T>: DProperty<V>
	{
		/// <summary>
		/// Get value for specified edge.
		/// </summary>
		/// <param name="e">Target edge</param>
		/// <returns>Value</returns>
		T getValue(V e);

		/// <summary>
		/// Set value for specified edge.
		/// </summary>
		/// <param name="e">Targe edge</param>
		/// <param name="value">Value for this edge</param>
		void setValue(V e, T value);
	}


	class blah
	{
		List<DProperty<Vertex>> v = new List<DProperty<Vertex>>();

		void ahoj()
		{
			


			foreach (var item in v)
			{
						
			} 
		}
	}

	interface Convertor<T>
	{
		T convertFromString(string s);
		string convertToString(T value);
	}


	class cucik<V, T> : EProperty<V, T>
	{
		Dictionary<V, T> klice = new Dictionary<V, T>();
		Convertor<T> _convert;

		public cucik(Convertor<T> conver)
		{
			_convert = conver;
		}


		public T getValue(V e)
		{
			return klice[e];
		}

		public void setValue(V e, T value)
		{
			klice[e] = value;

		}

		string DProperty<V>.getValue(V target)
		{

			return _convert.convertToString(klice[target]);

		}

		public void setValue(V target, string value)
		{
			klice[target] = _convert.convertFromString(value);
		}
	}



    /// <summary>
    /// Generic interface for edge properties
    /// </summary>
    /// <typeparam name="T">Type of property values</typeparam>
	public interface IProperty<V,T> : IGraphObserver<V>  where V : GraphObject
    {

	

        /// <summary>
        /// Get value for specified edge.
        /// </summary>
        /// <param name="e">Target edge</param>
        /// <returns>Value</returns>
        T getValue(V e);

        /// <summary>
        /// Set value for specified edge.
        /// </summary>
        /// <param name="e">Targe edge</param>
        /// <param name="value">Value for this edge</param>
        void setValue(V e, T value);

		
     

    }
    
    /// <summary>
    /// Basic implementation of property, which hold value for each edge in Dictionary.
    /// </summary>
    /// <typeparam name="T">Type of property values</typeparam>
	public class DictProperty<V, T> : IProperty<V, T> where V : GraphObject
    {
        private Graph innerGraph;
        private T defVal = default(T);
        private Dictionary<IEdge, T> dict = new Dictionary<IEdge, T>();

     

        /// <summary>
        /// Create instance of DictEdgeProperty and default value is set to default(T)
        /// </summary>
        /// <param name="g">Target graph</param>
        public DictProperty (Graph g)
        {
            innerGraph = g;
         
        }

        /// <summary>
        /// Create instance with specified default value.
        /// </summary>
        /// <param name="g">Target graph</param>
        /// <param name="def">Default value</param>
        public DictProperty(Graph g, T def)
            : this(g)
        {
            
            defVal = def;
        }


     



		public T getValue(V e)
		{
			throw new NotImplementedException();
		}

		public void setValue(V e, T value)
		{
			throw new NotImplementedException();
		}

		public void update(V changedObject, ChangeType typeOfChange)
		{
			throw new NotImplementedException();
		}

		public IMemento getMemento()
		{
			throw new NotImplementedException();
		}

		public IMemento getMemento(V changedObject)
		{
			throw new NotImplementedException();
		}
	}


    /// <summary>
    /// Property, which returns constant specified value.  
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public class ConstantProperty<V, T> : IProperty<V, T> where V : GraphObject
    {
        private T defVal;
        private Graph innerGraph;

       /// <summary>
       /// Create 
       /// </summary>
       /// <param name="g"></param>
       /// <param name="def"></param>
        public ConstantProperty(Graph g,T def)
        {
            defVal = def;
            innerGraph = g; 
        }




		public T getValue(V e)
		{
			throw new NotImplementedException();
		}

		public void setValue(V e, T value)
		{
			throw new NotImplementedException();
		}


		public void update(V changedObject, ChangeType typeOfChange)
		{
			throw new NotImplementedException();
		}

		public IMemento getMemento(V changedObject)
		{
			throw new NotImplementedException();
		}

		public IMemento getMemento()
		{
			throw new NotImplementedException();
		}
	}
    
}
