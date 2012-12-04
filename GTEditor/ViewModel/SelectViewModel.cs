using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTEditor.SelectorG;
using System.ComponentModel;
using System.Reflection;
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


		//TODO: Vyzkoumat jak by tohle melo proboha fungovat
		/*
		 * private void OnPropertyChanged<T>(System.Linq.Expressions.Expression<Func<TNotifiableObject, T>> property)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				string propertyName = property == null ? null : Reflect<TNotifiableObject>.Infoof(property).Name;
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		*/

		private void RaiseEvent(string property)
		{

			if (PropertyChanged == null) return;

			PropertyInfo[] propertyInfos;

			propertyInfos = typeof(SelectViewModel).GetProperties(BindingFlags.Public |BindingFlags.Static);

			foreach (PropertyInfo propertyInfo in propertyInfos)
			{
				if (propertyInfo.Name == property)
				{
					PropertyChanged(this, new PropertyChangedEventArgs(property));
				}
			}

			throw new Exception("Blbý jméno property asi si refraktoroval");
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
