using System;
namespace NUnit.Framework.ExtensionsImpl
{
	public class AndConstraint<T>: IAndConstraints<T> where T : class, ICloneable
	{
		private readonly T rootConstraint;

		public AndConstraint(T rootConstraint)
		{
			this.rootConstraint = rootConstraint;
		}

		public T And
		{
			get { return rootConstraint; }
		}
	}
}