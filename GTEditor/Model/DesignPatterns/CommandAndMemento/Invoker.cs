using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTEditor.Model.DesignPatterns.CommandAndMemento
{
	class Invoker
	{
		List<ICommand> commands = new List<ICommand>();


		public void ExecuteCommand(ICommand com)
		{
			commands.Add(com);
			com.Execute();
		}

		public void UndoCommand()
		{
			ICommand com = commands[commands.Count - 1];
			commands.RemoveAt(commands.Count - 1);

			com.Undo();
		}

		



	}
}
