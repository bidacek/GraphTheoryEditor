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
		public static int counter = 0;


		public Vertex()
		{
			id = counter++;
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
