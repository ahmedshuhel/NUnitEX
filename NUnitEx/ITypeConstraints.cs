using System;

namespace NUnit.Framework
{
	public interface ITypeConstraints : IBeConstraints<ITypeBeConstraints>, IHaveConstraints<ITypeHaveConstraints>,
																			INegableConstraints<ITypeConstraints>, IConstraints<Type>, ICloneable { }

	public interface ITypeBeConstraints : IChildAndChainableConstraints<Type, ITypeConstraints>
	{
		IAndConstraints<ITypeConstraints> Null();
		IAndConstraints<ITypeConstraints> EqualTo<T>();
		IAndConstraints<ITypeConstraints> EqualTo(Type expected);
		IAndConstraints<ITypeConstraints> AssignableFrom(Type expected);
		IAndConstraints<ITypeConstraints> AssignableFrom<T>();
		IAndConstraints<ITypeConstraints> SubClassOf(Type expected);
		IAndConstraints<ITypeConstraints> SubClassOf<T>();
	}

	public interface ITypeHaveConstraints : IChildAndChainableConstraints<Type, ITypeConstraints>
	{
		IAndConstraints<ITypeConstraints> Attribute<T>();
	}
}