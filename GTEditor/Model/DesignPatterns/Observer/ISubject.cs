using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTEditor.Model.DesignPatterns.CommandAndMemento;

namespace GTEditor.Model.DesignPatterns.Observer
{
	
	
	public interface ISubjectPattern<T> : Originator where T : GraphObject
    {
		void attachObserver(IObserver<T> ob);
		void detachObserver(IObserver<T> ob);

    }

	
	

 


}
