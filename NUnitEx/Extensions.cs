using System;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using NUnit.Framework.ExtensionsImpl;

namespace NUnit.Framework
{
	public static class Assertion
	{
		public static void AssertUsing<T>(this IAssertionInfo<T> assertionInfo, Constraint constraint)
		{
			IResolveConstraint cr = assertionInfo.IsNegated ? !constraint : constraint;
			Assert.That(assertionInfo.Actual, cr, assertionInfo.FailureMessage);
		}

		public static IBooleanConstraints Should(this bool actual)
		{
			return new BooleanConstraints(new BooleanBeConstraints(actual));
		}

		public static IBooleanConstraints Should(this bool actual, string title)
		{
			return new BooleanConstraints(new BooleanBeConstraints(actual, () => title));
		}

		public static IClassConstraints Should(this object actual)
		{
			return new ClassConstraints(actual);
		}

		public static IClassConstraints Should(this object actual, string title)
		{
			return new ClassConstraints(actual, () => title);
		}

		public static IComparableConstraints<short> Should(this short actual)
		{
			return new ComparableConstraints<short>(actual);
		}

		public static IComparableConstraints<int> Should(this int actual)
		{
			return new ComparableConstraints<int>(actual);
		}

		public static IComparableConstraints<long> Should(this long actual)
		{
			return new ComparableConstraints<long>(actual);
		}

		public static IComparableConstraints<ushort> Should(this ushort actual)
		{
			return new ComparableConstraints<ushort>(actual);
		}

		public static IComparableConstraints<uint> Should(this uint actual)
		{
			return new ComparableConstraints<uint>(actual);
		}

		public static IComparableConstraints<ulong> Should(this ulong actual)
		{
			return new ComparableConstraints<ulong>(actual);
		}

		public static IComparableConstraints<float> Should(this float actual)
		{
			return new ComparableConstraints<float>(actual);
		}

		public static IComparableConstraints<double> Should(this double actual)
		{
			return new ComparableConstraints<double>(actual);
		}

		public static IComparableConstraints<decimal> Should(this decimal actual)
		{
			return new ComparableConstraints<decimal>(actual);
		}

		public static IComparableConstraints<DateTime> Should(this DateTime actual)
		{
			return new ComparableConstraints<DateTime>(actual);
		}

		public static IComparableConstraints<short> Should(this short actual, string title)
		{
			return new ComparableConstraints<short>(actual, () => title);
		}

		public static IComparableConstraints<int> Should(this int actual, string title)
		{
			return new ComparableConstraints<int>(actual, () => title);
		}

		public static IComparableConstraints<long> Should(this long actual, string title)
		{
			return new ComparableConstraints<long>(actual, () => title);
		}

		public static IComparableConstraints<ushort> Should(this ushort actual, string title)
		{
			return new ComparableConstraints<ushort>(actual, () => title);
		}

		public static IComparableConstraints<uint> Should(this uint actual, string title)
		{
			return new ComparableConstraints<uint>(actual, () => title);
		}

		public static IComparableConstraints<ulong> Should(this ulong actual, string title)
		{
			return new ComparableConstraints<ulong>(actual, () => title);
		}

		public static IComparableConstraints<float> Should(this float actual, string title)
		{
			return new ComparableConstraints<float>(actual, () => title);
		}

		public static IComparableConstraints<double> Should(this double actual, string title)
		{
			return new ComparableConstraints<double>(actual, () => title);
		}

		public static IComparableConstraints<decimal> Should(this decimal actual, string title)
		{
			return new ComparableConstraints<decimal>(actual, () => title);
		}

		public static IComparableConstraints<DateTime> Should(this DateTime actual, string title)
		{
			return new ComparableConstraints<DateTime>(actual, () => title);
		}

		public static INullableComparableConstraints<T?> Should<T>(this T? actual) where T : struct, IComparable
		{
			return new NullableComparableConstraints<T?>(actual);
		}

		public static INullableComparableConstraints<T?> Should<T>(this T? actual, string title) where T : struct, IComparable
		{
			return new NullableComparableConstraints<T?>(actual, () => title);
		}

		public static IStringConstraints Should(this string actual)
		{
			return new StringConstraints(actual);
		}

		public static IStringConstraints Should(this string actual, string title)
		{
			return new StringConstraints(actual, () => title);
		}

		public static IEnumerableConstraints<T> Should<T>(this IEnumerable<T> actual)
		{
			return new EnumerableConstraints<T>(actual);
		}

		public static IEnumerableConstraints<T> Should<T>(this IEnumerable<T> actual, string title)
		{
			return new EnumerableConstraints<T>(actual, () => title);
		}

		public static IActionConstraints Should(this Action toExecute)
		{
			return new ActionConstraints(toExecute);
		}

		public static IActionConstraints Should(this Action toExecute, string title)
		{
			return new ActionConstraints(toExecute, () => title);
		}

		public static ITypeConstraints Should(this Type actual)
		{
			return new TypeConstraints(actual);
		}

		public static ITypeConstraints Should(this Type actual, string title)
		{
			return new TypeConstraints(actual, () => title);
		}
	}
}