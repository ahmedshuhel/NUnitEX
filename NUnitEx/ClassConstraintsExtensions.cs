using NUnit.Framework.ExtensionsImpl;

namespace NUnit.Framework
{
	public static class ClassConstraintsExtensions
	{
		public static IAndConstraints<IClassConstraints> SameInstanceAs(this IClassBeConstraints constraint, object expected)
		{
			constraint.AssertionInfo.AssertUsing(Is.SameAs(expected));
			return ConstraintsHelper.AndChain(constraint.AssertionParent);
		}

		public static IAndConstraints<IClassConstraints> InstanceOf<T>(this IClassBeConstraints constraint)
		{
			constraint.AssertionInfo.AssertUsing(Is.InstanceOf<T>());
			return ConstraintsHelper.AndChain(constraint.AssertionParent);
		}

		public static IAndConstraints<IClassConstraints> AssignableFrom<T>(this IClassBeConstraints constraint)
		{
			constraint.AssertionInfo.AssertUsing(Is.AssignableFrom<T>());
			return ConstraintsHelper.AndChain(constraint.AssertionParent);
		}

		public static IAndConstraints<IClassConstraints> AssignableTo<T>(this IClassBeConstraints constraint)
		{
			constraint.AssertionInfo.AssertUsing(Is.AssignableTo<T>());
			return ConstraintsHelper.AndChain(constraint.AssertionParent);
		}

		public static IAndConstraints<IClassConstraints> BinarySerializable(this IClassBeConstraints constraint)
		{
			constraint.AssertionInfo.AssertUsing(Is.BinarySerializable);
			return ConstraintsHelper.AndChain(constraint.AssertionParent);
		}

		public static IAndConstraints<IClassConstraints> XmlSerializable(this IClassBeConstraints constraint)
		{
			constraint.AssertionInfo.AssertUsing(Is.XmlSerializable);
			return ConstraintsHelper.AndChain(constraint.AssertionParent);
		}
	}
}