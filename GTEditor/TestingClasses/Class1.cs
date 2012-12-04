using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTEditor.TestingClasses
{
	abstract class AClass1
	{
		public virtual void Vypis()
		{
			Console.WriteLine("cus");
		}
	}

	abstract class AClass2
	{
		public abstract void Zapis();
	}

	interface I1
	{
		void Dopis();
	}

	interface I2
	{
		void Dopis();
	}


	class Class3 : AClass1, I1, I2
	{


		 void I1.Dopis()
		{
			throw new NotImplementedException();
		}

		 void I2.Dopis()
		{
			throw new NotImplementedException();
		}
	}
}
