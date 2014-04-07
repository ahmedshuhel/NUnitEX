using System;

namespace NUnit.Framework.ExtensionsImpl
{
	public class ConstraintsHelper
	{
		private ConstraintsHelper() {}

		public static IAndConstraints<TParentConstraint> AndChain<TParentConstraint>(TParentConstraint parent)
			where TParentConstraint : class, ICloneable
		{
			return new AndConstraint<TParentConstraint>((TParentConstraint)parent.Clone());
		}
	}
}