using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTEditor.Model.DesignPatterns.CommandAndMemento;



namespace GTEditor.Model.DesignPatterns.GraphSpecialized
{
	public interface IGraphOriginator<T> : Originator where T : GraphObject
	{
		IMemento getMemento(T changedObject);
	}



}
