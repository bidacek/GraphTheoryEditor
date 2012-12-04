using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTEditor.Model.DesignPatterns.GraphSpecialized
{
	/// <summary>
	/// Interface pro class týkající se Grafu, přidává navíc metody pro zmenšení pamětové náročnosti mementa
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IGraphObserver<T> :  IGraphOriginator<T> where T : GraphObject
	{
		void update(T changedObject, ChangeType typeOfChange);
	}
}
