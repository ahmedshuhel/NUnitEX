using System;

namespace NUnit.Framework.ExtensionsImpl
{
	public class NullableComparableConstraints<T> : NegableConstraints<T, INullableComparableConstraints<T>>,
		INullableComparableConstraints<T>, IComparableConstraints<T>
	{
		public NullableComparableConstraints(T actual) : base(actual) {}
		public NullableComparableConstraints(T actual, Func<string> messageBuilder) : base(actual, messageBuilder) {}

		#region Implementation of IBeConstraints<IComparableBeConstraints<T>>

		public IComparableBeConstraints<T> Be
		{
			get { return new ComparableBeConstraints<T>(this); }
		}

		#endregion

		#region Implementation of ICloneable

		public object Clone()
		{
			return new NullableComparableConstraints<T>(AssertionInfo.Actual, () => AssertionInfo.FailureMessage);
		}

		#endregion

		#region Implementation of IHaveConstraints<IHaveNullableComparableConstraints<T>>

		public IHaveNullableComparableConstraints<T> Have
		{
			get { return new HaveNullableComparableConstraints<T>(this); }
		}

		#endregion

		#region INegableConstraints<IComparableConstraints<T>> Members

		IComparableConstraints<T> INegableConstraints<IComparableConstraints<T>>.Not
		{
			get { return Not as IComparableConstraints<T>; }
		}

		#endregion
	}

	public class HaveNullableComparableConstraints<T>: ChildAndChainableConstraints<T, INullableComparableConstraints<T>>, IHaveNullableComparableConstraints<T>
	{
		public HaveNullableComparableConstraints(INullableComparableConstraints<T> parent) : base(parent) {}

		#region Implementation of IHaveNullableComparableConstraints<T>

		public void Value()
		{
			AssertionInfo.AssertUsing(Is.Not.Null);
		}

		#endregion
	}
}