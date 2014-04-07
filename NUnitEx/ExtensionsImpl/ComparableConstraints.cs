using System;

namespace NUnit.Framework.ExtensionsImpl
{
	public class ComparableConstraints<T> : NegableConstraints<T, IComparableConstraints<T>>, IComparableConstraints<T>
	{
		public ComparableConstraints(T actual) : base(actual) {}
		public ComparableConstraints(T actual, Func<string> messageBuilder) : base(actual, messageBuilder) {}

		public IComparableBeConstraints<T> Be
		{
			get { return new ComparableBeConstraints<T>(this); }
		}

		public object Clone()
		{
			return new ComparableConstraints<T>(AssertionInfo.Actual, () => AssertionInfo.FailureMessage);
		}
	}

	public class ComparableBeConstraints<T> : ChildAndChainableConstraints<T, IComparableConstraints<T>>, IComparableBeConstraints<T>
	{
		public ComparableBeConstraints(IComparableConstraints<T> parent) : base(parent) { }

		#region Implementation of IComparableConstraints<T>

		public IAndConstraints<IComparableConstraints<T>> EqualTo(IComparable expected)
		{
			AssertionInfo.AssertUsing(Is.EqualTo(expected));
			return AndChain;
		}

		public IAndConstraints<IComparableConstraints<T>> GreaterThan(IComparable expected)
		{
			AssertionInfo.AssertUsing(Is.GreaterThan(expected));
			return AndChain;
		}

		public IAndConstraints<IComparableConstraints<T>> LessThan(IComparable expected)
		{
			AssertionInfo.AssertUsing(Is.LessThan(expected));
			return AndChain;
		}

		public IAndConstraints<IComparableConstraints<T>> GreaterThanOrEqualTo(IComparable expected)
		{
			AssertionInfo.AssertUsing(Is.GreaterThanOrEqualTo(expected));
			return AndChain;
		}

		public IAndConstraints<IComparableConstraints<T>> LessThanOrEqualTo(IComparable expected)
		{
			AssertionInfo.AssertUsing(Is.LessThanOrEqualTo(expected));
			return AndChain;
		}

		public IAndConstraints<IComparableConstraints<T>> IncludedIn<TP>(TP lowLimit, TP highLimit) where TP: IComparable<TP>
		{
			AssertionInfo.AssertUsing(Is.InRange(lowLimit, highLimit));
			return AndChain;
		}

		#endregion
	}
}