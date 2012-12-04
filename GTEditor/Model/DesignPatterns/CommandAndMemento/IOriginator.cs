using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTEditor.Model.DesignPatterns.CommandAndMemento
{
	//TODO: There is problem, when IObserver is Originator at the sime time

	public interface Originator
    {
		IMemento getMemento();

    }

	
}

