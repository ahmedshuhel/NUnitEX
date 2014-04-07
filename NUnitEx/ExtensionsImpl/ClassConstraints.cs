using System;

namespace NUnit.Framework.ExtensionsImpl
{
	public class ClassConstraints : NegableConstraints<object, IClassConstraints>, IClassConstraints
	{
		public ClassConstraints(object actual) : base(actual) {}
		public ClassConstraints(object actual, Func<string> messageBuilder) : base(actual, messageBuilder) {}

		#region IClassConstraints Members

		public IClassBeConstraints Be
		{
			get { return new ClassBeConstraints(this); }
		}

		#endregion

		public object Clone()
		{
			return new ClassConstraints(AssertionInfo.Actual, () => AssertionInfo.FailureMessage);
		}
	}

	public class ClassConstraints<TValue> : ClassConstraints, IClassConstraints<TValue>
	{
		public ClassConstraints(object actual, Func<string> messageBuilder) : base(actual, messageBuilder) { }

		public TValue ValueOf
		{
			get { return (TValue)AssertionInfo.Actual; }
		}

		public TValue Value
		{
			get { return (TValue)AssertionInfo.Actual; }
		}
	}

	public class ClassBeConstraints : ChildAndChainableConstraints<object, IClassConstraints>, IClassBeConstraints
	{
		public ClassBeConstraints(IClassConstraints parent) : base(parent) {}

		#region Implementation of IClassConstraints

		public IAndConstraints<IClassConstraints> EqualTo(object expected)
		{
			AssertionInfo.AssertUsing(Is.EqualTo(expected));
			return AndChain;
		}

		public IAndConstraints<IClassConstraints> Null()
		{
			AssertionInfo.AssertUsing(Is.Null);
			return AndChain;
		}

		public IAndConstraints<IClassConstraints<T>> OfType<T>()
		{
			AssertionInfo.AssertUsing(Is.TypeOf<T>());
			return
				new AndConstraint<IClassConstraints<T>>(new ClassConstraints<T>((T) AssertionInfo.Actual,
				                                                                () => AssertionInfo.FailureMessage));
		}

		#endregion
	}
}