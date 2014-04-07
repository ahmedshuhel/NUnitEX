using System;
using System.Linq.Expressions;

namespace NUnit.Framework
{
	public interface IConstraints<T>
	{
		IAssertionInfo<T> AssertionInfo { get; }
		void Satisfy(Expression<Func<T, bool>> assertion);
	}

	public interface INegableConstraints<TConstraint> where TConstraint : class
	{
		TConstraint Not { get; }
	}

	public interface IBeConstraints<TConstraint> where TConstraint : class
	{
		TConstraint Be { get; }
	}

	public interface IHaveConstraints<TConstraint> where TConstraint : class
	{
		TConstraint Have { get; }
	}

	public interface IAndConstraints<TConstraints> where TConstraints : class, ICloneable
	{
		TConstraints And { get; }
	}

	public interface IChildConstraints<T, TParentConstraint> : IConstraints<T> where TParentConstraint : IConstraints<T>
	{
		TParentConstraint AssertionParent { get; }
	}

	public interface IChildAndChainableConstraints<T, TParentConstraint> : IChildConstraints<T, TParentConstraint>
		where TParentConstraint : class, IConstraints<T>, ICloneable
	{
	}
}