using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTEditor.Model.DesignPatterns.CommandAndMemento;
using GTEditor.Model.DesignPatterns.GraphSpecialized;


namespace GTEditor.Model.DesignPatterns.Observer
{

	
	
	public interface IObserverPattern<T>: Originator where T : GraphObject
    {
		

		void update(T changedObject, ChangeType typeOfChange);


    }

}
