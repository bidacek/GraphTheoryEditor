using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GTEditor.PropertyG
{
    /// <summary>
    /// public class which contains all properties for specified graph parts (edges or vertices).
    /// </summary>
    public class PropertyGraph
    {

        private Graph innerGraph;
        private Dictionary<string, object> innerProp = new Dictionary<string, object>();
        public Dictionary<string, Type> innerTypes = new Dictionary<string, Type>();

        

        public List<string> names = new List<string>();
    



        /// <summary>
        /// Create instance of Property bag
        /// </summary>
        /// <param name="g"></param>
        public PropertyGraph(Graph g)
        {
            innerGraph = g; 
           
        }


        /// <summary>
        /// Return target Graph
        /// </summary>
        public Graph GraphForProperties
        {
            get { return innerGraph; }
        }



        /// <summary>
        /// Generic method for getting edge property. Check type before returning property.
        /// </summary>
        /// <typeparam name="T">Type of property values</typeparam>
        /// <param name="name">Name of the property</param>
        /// <param name="property">Output property</param>
        /// <returns>true if property finded and type matches original type </returns>
        public bool getProperty<V,T>(string name, out IProperty<V,T> property)  where V: GraphObject
        {
            if (!innerProp.ContainsKey(name)) { property = default(IProperty<V,T>); return false; }

            Type innerType = innerTypes[name];

            if (innerType != typeof(T)) { property = default(IProperty<V,T>); return false; }


            property = (IProperty<V,T>)innerProp[name];
            return true;
        }

        /// <summary>
        /// Add edge property with specified unique name.
        /// </summary>
        /// <typeparam name="T">Type of property values</typeparam>
        /// <param name="name">Name of the property</param>
        /// <param name="property">Property for add</param>
        /// <returns>true if property has been added succesfully </returns>
		public bool addProperty<V,T>(string name, IProperty<V, T> property) where V: GraphObject
        {
            if (innerProp.ContainsKey(name))
            {

                return false;
            }

            //Adding null value
			if (EqualityComparer<IProperty<V, T>>.Default.Equals(property, default(IProperty<V, T>)))
            {
                return false;
            }



            innerTypes[name] = typeof(T);

            innerProp[name] = (object) property;

            names.Add(name);
            return true;
        }

        /// <summary>
        /// Remove edge property with specified name
        /// </summary>
        /// <param name="name">Name of the property</param>
        /// <returns>true if property has been succesfully removed</returns>
        public bool removeProperty(string name)
        {
            if (!innerProp.ContainsKey(name)) { return false; }

            innerProp.Remove(name);    // Maybe, I have to remove delegate too
            innerTypes.Remove(name);

            return true; 
        }


        /// <summary>
        /// Nongeneric method for getting property,which is using dynamic type (keyword).
        /// </summary>
        /// <param name="name">Name of property</param>
        /// <returns>Output property or null</returns>
        public dynamic getPropertyAsDynamic(string name)
        {
            if (!innerProp.ContainsKey(name)) { return null; } 
            return innerProp[name];
        }





        
       

    }
}
