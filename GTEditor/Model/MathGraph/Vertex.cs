using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTEditor
{
    /// <summary>
    /// public class, which represents graph's vertex 
    /// </summary>
    public class Vertex : GraphObject
    {
        private int id;


        /// <summary>
        /// Create vertex with specified id
        /// </summary>
        /// <param name="i">ID of this node</param>
        public Vertex(int i)
        {
            id = i;
        }

        /// <summary>
        /// Overrided ToString method for easy debugging 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return id.ToString();
        }
    }
}
