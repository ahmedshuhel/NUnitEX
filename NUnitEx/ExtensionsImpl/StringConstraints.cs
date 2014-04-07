using System;

namespace NUnit.Framework.ExtensionsImpl
{
	public class StringConstraints : NegableConstraints<string, IStringConstraints>, IStringConstraints
	{
		public StringConstraints(string actual) : base(actual) {}
		public StringConstraints(string actual, Func<string> messageBuilder) : base(actual, messageBuilder) {}

		public IStringBeConstraints Be
		{
			get { return new StringBeConstraints(this); }
		}

		public object Clone()
		{
			return new StringConstraints(AssertionInfo.Actual, () => AssertionInfo.FailureMessage);
		}
	}

	public class StringBeConstraints : ChildAndChainableConstraints<string, IStringConstraints>, IStringBeConstraints
	{
		public StringBeConstraints(IStringConstraints parent) : base(parent) { }

		#region Implementation of IStringConstraints

		public IAndConstraints<IStringConstraints> EqualTo(string expected)
		{
			AssertionInfo.AssertUsing(Is.EqualTo(expected));
			return AndChain;
		}

		public IAndConstraints<IStringConstraints> Null()
		{
			AssertionInfo.AssertUsing(Is.Null);
			return AndChain;
		}

		public IAndConstraints<IStringConstraints> Empty()
		{
			AssertionInfo.AssertUsing(Is.Empty);
			return AndChain;
		}

		#endregion
	}
}