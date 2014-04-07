using System;

namespace NUnit.Framework.ExtensionsImpl
{
	public class ActionConstraints : Constraint<Action>, IActionConstraints
	{
		public ActionConstraints(Action actual) : base(actual) {}
		public ActionConstraints(Action actual, Func<string> messageBuilder) : base(actual, messageBuilder) {}

		#region IActionConstraints Members

		public IAndConstraints<IThrowConstraints<TException>> Throw<TException>() where TException : Exception
		{
			return
				new AndConstraint<IThrowConstraints<TException>>(
					new ThrowConstraints<TException>(Assert.Throws<TException>(() => AssertionInfo.Actual(),
					                                                           AssertionInfo.FailureMessage)));
		}

		public void NotThrow<TException>() where TException : Exception
		{
			Assert.DoesNotThrow(() => AssertionInfo.Actual(), AssertionInfo.FailureMessage);
		}

		#endregion
	}

	public class ThrowConstraints<TException> : IThrowConstraints<TException> where TException : Exception
	{
		public ThrowConstraints(TException currentException)
		{
			ValueOf = currentException;
		}

		#region IThrowConstraints<TException> Members

		public TException ValueOf { get; private set; }

		#endregion

		public object Clone()
		{
			return new ThrowConstraints<TException>(ValueOf);
		}
	}
}