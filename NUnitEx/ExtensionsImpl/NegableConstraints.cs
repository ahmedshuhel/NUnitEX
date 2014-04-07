using System;

namespace NUnit.Framework.ExtensionsImpl
{
	public class NegableConstraints<T, TConstraints> : Constraint<T>, INegableConstraints<TConstraints> where TConstraints : class
	{
		protected NegableConstraints(T actual) : base(actual) {}
		protected NegableConstraints(T actual, Func<string> messageBuilder) : base(actual, messageBuilder) {}

		#region Implementation of INegableConstraints<TConstraints>

		public TConstraints Not
		{
			get
			{
				((INegable)AssertionInfo).Nagate();
				return this as TConstraints;
			}
		}

		#endregion
	}
}