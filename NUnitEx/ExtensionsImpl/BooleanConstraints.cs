using System;

namespace NUnit.Framework.ExtensionsImpl
{
	public class BooleanConstraints : IBooleanConstraints
	{
		private readonly IBooleanBeConstraints concreteConstraint;

		public BooleanConstraints(IBooleanBeConstraints concreteConstraint)
		{
			this.concreteConstraint = concreteConstraint;
		}

		public IBooleanBeConstraints Be
		{
			get { return concreteConstraint; }
		}
	}

	public class BooleanBeConstraints : Constraint<bool>, IBooleanBeConstraints
	{
		public BooleanBeConstraints(bool actual) : base(actual) {}
		public BooleanBeConstraints(bool actual, Func<string> messageBuilder) : base(actual, messageBuilder) {}

		#region Implementation of IBoleanConstraints

		public void True()
		{
			AssertionInfo.AssertUsing(Is.True);
		}

		public void False()
		{
			AssertionInfo.AssertUsing(Is.False);
		}

		#endregion
	}
}