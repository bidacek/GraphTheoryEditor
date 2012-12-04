using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTEditor.Model.DesignPatterns.Observer;



namespace GTEditor.Model.DesignPatterns.GraphSpecialized
{
	/// <summary>
	/// Přidává metody pro memento specializované na hranové a vrcholové operace
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IGraphSubject<T> :  IGraphOriginator<T> where T : GraphObject
	{
		void attachObserver(IGraphObserver<T> ob);
		void detachObserver(IGraphObserver<T> ob);
	}


	
}
