using System;
using NUnit.Framework.ExtensionsImpl;

namespace NUnit.Framework
{
	public static class TypeConstraintsExtensions
	{
		public static IAndConstraints<ITypeConstraints> AssignableTo(this ITypeBeConstraints constraint, Type expected)
		{
			constraint.AssertionInfo.AssertUsing(new DelegatedConstraint<Type>(expected, expected.IsAssignableFrom, "Assignable To"));
			return ConstraintsHelper.AndChain(constraint.AssertionParent);
		}

		public static IAndConstraints<ITypeConstraints> AssignableTo<T>(this ITypeBeConstraints constraint)
		{
			return AssignableTo(constraint, typeof(T));
		}
	}
}