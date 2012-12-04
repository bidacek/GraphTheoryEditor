using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using GTEditor.PropertyG;
using System.Windows.Media;

namespace GTEditor.VisualG.ShapeG.FormaterG.VertexG.ConditionG
{
    /// <summary>
    /// Podmínka kontrolující typicky nějakou property. Pokud je splněna můžeme si získat tvar vrcholu či hrany, odpovídající této splněné podmínce.
    /// </summary>
    public interface ICondition<V,T> where V : GraphObject
	{

        bool matchCondition(V v);
        Shape getShape(V v);
    }

    
    /// <summary>
    /// Pro danou Iproperty kontroluje zatím jen rovnost s danou hodnotou.
    /// </summary>
    public class EqualsToValue<V,T> : ICondition<V,T>	where V: GraphObject
																where T: IEqualityComparer<T>
    {
        T innerVal;
        IProperty<V,T> innerProp;

		public EqualsToValue(T value, IProperty<V, T> prop)
        {
           innerVal = value;
           innerProp = prop;
        }

      
    
        public bool matchCondition(V v)
        {
            if (innerProp.getValue(v) == null) { return false; }
           if (innerProp.getValue(v).Equals(innerVal)) { return true; }
            else { return false; }
        }

        public Shape getShape(V v)
        {


			Ellipse e = new Ellipse();
			e.Width = 10;
			e.Height = 10;

			e.Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0));

			return e;

        }
	   
	  
        
    }
    


}
