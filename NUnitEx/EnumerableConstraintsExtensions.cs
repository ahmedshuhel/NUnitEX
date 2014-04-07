using System.Collections.Generic;
using NUnit.Framework.ExtensionsImpl;

namespace NUnit.Framework
{
	public static class EnumerableConstraintsExtensions
	{
		public static IAndConstraints<IEnumerableConstraints<T>> SameInstanceAs<T>(this IEnumerableBeConstraints<T> constraint, IEnumerable<T> expected)
		{
			constraint.AssertionInfo.AssertUsing(Is.SameAs(expected));
			return ConstraintsHelper.AndChain(constraint.AssertionParent);
		}

		public static IAndConstraints<IEnumerableConstraints<T>> Contain<T>(this IEnumerableConstraints<T> constraint, T expected)
		{
			constraint.AssertionInfo.AssertUsing(Has.Member(expected));
			return ConstraintsHelper.AndChain(constraint);
		}

		public static IAndConstraints<IEnumerableConstraints<T>> SameValuesAs<T>(this IEnumerableHaveConstraints<T> constraint, IEnumerable<T> expected)
		{
			constraint.AssertionInfo.AssertUsing(Is.EquivalentTo(expected));
			return ConstraintsHelper.AndChain(constraint.AssertionParent);
		}

		public static IAndConstraints<IEnumerableConstraints<T>> UniqueValues<T>(this IEnumerableHaveConstraints<T> constraint)
		{
			constraint.AssertionInfo.AssertUsing(Is.Unique);
			return ConstraintsHelper.AndChain(constraint.AssertionParent);
		}

		public static IAndConstraints<IEnumerableConstraints<T>> SubsetOf<T>(this IEnumerableBeConstraints<T> constraint, IEnumerable<T> expected)
		{
			constraint.AssertionInfo.AssertUsing(Is.SubsetOf(expected));
			return ConstraintsHelper.AndChain(constraint.AssertionParent);
		}

		public static IAndConstraints<IEnumerableConstraints<T>> Ordered<T>(this IEnumerableBeConstraints<T> constraint)
		{
			constraint.AssertionInfo.AssertUsing(Is.Ordered | Is.Ordered.Descending);
			return ConstraintsHelper.AndChain(constraint.AssertionParent);
		}

		public static IAndConstraints<IEnumerableConstraints<T>> OrderedAscending<T>(this IEnumerableBeConstraints<T> constraint)
		{
			constraint.AssertionInfo.AssertUsing(Is.Ordered);
			return ConstraintsHelper.AndChain(constraint.AssertionParent);
		}

		public static IAndConstraints<IEnumerableConstraints<T>> OrderedDescending<T>(this IEnumerableBeConstraints<T> constraint)
		{
			constraint.AssertionInfo.AssertUsing(Is.Ordered.Descending);
			return ConstraintsHelper.AndChain(constraint.AssertionParent);
		}

		public static IAndConstraints<IEnumerableConstraints<T>> SameSequenceAs<T>(this IEnumerableHaveConstraints<T> constraint, params T[] expected)
		{
			constraint.AssertionInfo.AssertUsing(Is.EqualTo(expected));
			return ConstraintsHelper.AndChain(constraint.AssertionParent);
		}

		public static IAndConstraints<IEnumerableConstraints<T>> SubsetOf<T>(this IEnumerableBeConstraints<T> constraint, params T[] expected)
		{
			constraint.AssertionInfo.AssertUsing(Is.SubsetOf(expected));
			return ConstraintsHelper.AndChain(constraint.AssertionParent);
		}

		public static IAndConstraints<IEnumerableConstraints<T>> SameValuesAs<T>(this IEnumerableHaveConstraints<T> constraint, params T[] expected)
		{
			constraint.AssertionInfo.AssertUsing(Is.EquivalentTo(expected));
			return ConstraintsHelper.AndChain(constraint.AssertionParent);
		}
	}
}