using System;
using System.Linq;
using System.Collections.Generic;

namespace NUnit.Framework.ExtensionsImpl
{
	public class EnumerableConstraints<T> : NegableConstraints<IEnumerable<T>, IEnumerableConstraints<T>>,
	                                        IEnumerableConstraints<T>
	{
		public EnumerableConstraints(IEnumerable<T> actual) : base(actual) {}
		public EnumerableConstraints(IEnumerable<T> actual, Func<string> messageBuilder) : base(actual, messageBuilder) {}

		public IEnumerableBeConstraints<T> Be
		{
			get { return new EnumerableBeConstraints<T>(this); }
		}

		public IEnumerableHaveConstraints<T> Have
		{
			get { return new EnumerableHaveConstraints<T>(this); }
		}

		public object Clone()
		{
			return new EnumerableConstraints<T>(AssertionInfo.Actual, () => AssertionInfo.FailureMessage);
		}
	}

	public class EnumerableBeConstraints<T> : ChildAndChainableConstraints<IEnumerable<T>, IEnumerableConstraints<T>>, IEnumerableBeConstraints<T>
	{
		public EnumerableBeConstraints(IEnumerableConstraints<T> parent) : base(parent) { }

		#region Implementation of IEnumerableConstraints<T>

		public IAndConstraints<IEnumerableConstraints<T>> Null()
		{
			AssertionInfo.AssertUsing(Is.Null);
			return AndChain;
		}

		public IAndConstraints<IEnumerableConstraints<T>> Empty()
		{
			AssertionInfo.AssertUsing(Is.Empty);
			return AndChain;
		}

		#endregion
	}

	public class EnumerableHaveConstraints<T> : ChildAndChainableConstraints<IEnumerable<T>, IEnumerableConstraints<T>>, IEnumerableHaveConstraints<T>
	{
		public EnumerableHaveConstraints(IEnumerableConstraints<T> parent) : base(parent) { }

		public IAndConstraints<IEnumerableConstraints<T>> SameSequenceAs(IEnumerable<T> expected)
		{
			AssertionInfo.AssertUsing(Is.EqualTo(expected));
			return AndChain;
		}

		public IComparableBeConstraints<int> Count
		{
			get
			{
				int count = AssertionInfo.Actual.Count();
				var cc = new ComparableConstraints<int>(count);
				if(AssertionInfo.IsNegated)
				{
					((INegable) cc.AssertionInfo).Nagate();
				}
				return new ComparableBeConstraints<int>(cc);
			}
		}
	}
}