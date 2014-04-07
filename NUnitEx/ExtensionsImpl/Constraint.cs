using System;
using System.Linq.Expressions;

namespace NUnit.Framework.ExtensionsImpl
{
	public class Constraint<T> : IConstraints<T>
	{
		protected Constraint(T actual) : this(new AssertionInfo<T>(actual)) {}

		protected Constraint(T actual, Func<string> messageBuilder) : this(new AssertionInfo<T>(actual, messageBuilder)) {}

		private Constraint(IAssertionInfo<T> assertionInfo)
		{
			AssertionInfo = assertionInfo;
		}

		#region Implementation of IConstraints<T>

		public IAssertionInfo<T> AssertionInfo { get; private set; }

		public void Satisfy(Expression<Func<T, bool>> assertion)
		{
			new ExpressionVisitor<T>(AssertionInfo.Actual).Visit(assertion);
		}

		public IConstraints<T> Parent
		{
			get { return null; }
		}

		#endregion
	}
}