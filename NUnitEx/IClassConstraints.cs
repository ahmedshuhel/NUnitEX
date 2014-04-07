using System;

namespace NUnit.Framework
{
	public interface IClassConstraints : IConstraints<object>, IBeConstraints<IClassBeConstraints>,
	                                     INegableConstraints<IClassConstraints>, ICloneable {}

	public interface IClassBeConstraints : IChildAndChainableConstraints<object, IClassConstraints>
	{
		IAndConstraints<IClassConstraints> EqualTo(object expected);
		IAndConstraints<IClassConstraints> Null();
		IAndConstraints<IClassConstraints<T>> OfType<T>();
	}

	public interface IClassConstraints<TValue> : IClassConstraints
	{
		TValue ValueOf { get; }
		TValue Value { get; }
	}
}