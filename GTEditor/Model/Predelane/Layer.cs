using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;

namespace GTEditor.VisualG.LayerG
{
    /// <summary>
    /// Represent part of graph, which can be edited separately
    public class Layer
    {

        private GraphPart innerPart;
        private string innerName;
        private bool locked;
        private bool visible;




        /// <summary>
        /// Create string with defined name
        /// </summary>
        /// <param name="name"></param>
        public Layer(string name)
        {
            innerName = name;
            innerPart = new GraphPart();
            locked = false;
            lockedSaved = false;

            visible = true;
        }

        /// <summary>
        /// if true, vertices and edges can be selected with mouse by clicking on it
        /// </summary>
        public bool IsLockedLayer
        {
            get { return locked; }
            set
            {
                if (value == locked) { return; }



                locked = value;
            

              

            }
        }

   

        private bool lockedSaved;


        /// <summary>
        /// Determines, whetever vertices and edges are visible on drawind canvas
        /// </summary>
        public bool IsVisibleLayer
        {
            get { return visible; }
            set
            {
                if (value == true) { visible = true; locked = lockedSaved; }
                else { visible = false; lockedSaved = locked; locked = true; }

                
           

                

            }
        }

        public GraphPart PartOfGraph
        {
            get { return innerPart; }
            set
            {
                if (value != null)
                {
                    value = innerPart;
                }
            }
        }

        public string Name
        {
            get { return innerName; }
            set { innerName = value; }
        }




	}
}
