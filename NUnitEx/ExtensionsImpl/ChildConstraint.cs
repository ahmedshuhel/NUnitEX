using System;
using System.Linq.Expressions;

namespace NUnit.Framework.ExtensionsImpl
{
	public class ChildConstraint<T, TParentConstraint> : IChildConstraints<T, TParentConstraint> 
		where TParentConstraint : IConstraints<T>
	{
		public ChildConstraint(TParentConstraint parent)
		{
			AssertionParent = parent;
		}

		public IAssertionInfo<T> AssertionInfo
		{
			get { return AssertionParent.AssertionInfo; }
		}

		public void Satisfy(Expression<Func<T, bool>> assertion)
		{
			AssertionParent.Satisfy(assertion);
		}

		public TParentConstraint AssertionParent { get; private set; }
	}
}