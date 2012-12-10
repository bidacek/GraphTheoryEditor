using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTEditor.SelectorG;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Input;
using System.Diagnostics;


namespace GTEditor.ViewModel
{
	class SelectViewModel : INotifyPropertyChanged
	{
		SelectorGraph innSelector;

		public SelectViewModel(Graph gr)
		{
			innSelector = new SelectorGraph(gr);

		}

		public int CountOfVertices
		{
			get
			{
				return 42;
			}
		}

		public ICommand deleteAll
		{
			get
			{
				return new DeleteComm();
			}
		}

		class DeleteComm : ICommand 
		{

		public bool  CanExecute(object parameter)
		{
			return true;
		}

		public event EventHandler  CanExecuteChanged;

		public void  Execute(object parameter)
		{
			
			System.Environment.Exit(0);
		}
			}




		

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
