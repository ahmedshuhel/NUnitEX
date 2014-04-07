using System;

namespace NUnit.Framework.ExtensionsImpl
{
	public class ChildAndChainableConstraints<T, TParentConstraint> : ChildConstraint<T, TParentConstraint>,
	                                                                  IChildAndChainableConstraints<T, TParentConstraint>
		where TParentConstraint : class, IConstraints<T>, ICloneable
	{
		public ChildAndChainableConstraints(TParentConstraint parent) : base(parent) {}

		#region IChildAndChainableConstraints<T,TParentConstraint> Members

		public IAndConstraints<TParentConstraint> AndChain
		{
			get { return ConstraintsHelper.AndChain(AssertionParent); }
		}

		#endregion
	}
}