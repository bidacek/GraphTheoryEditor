using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTEditor.Model.DesignPatterns.CommandAndMemento
{
	abstract class ICommand
	{
		protected List<IMemento> mementos = new List<IMemento>();

		public abstract void Execute();

		public virtual void Undo()
		{
			foreach (var m in mementos)
			{
				m.Rollback();
			}
		}
	}

	
}
