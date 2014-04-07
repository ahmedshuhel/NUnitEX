using System;
using NUnit.Framework.Constraints;

namespace NUnit.Framework.ExtensionsImpl
{
	public class DelegatedConstraint<T>: Constraint
	{
		private readonly T expected;
		private readonly Func<T, bool> match;
		private readonly string predicate;
		private readonly Func<string> modifier;

		public DelegatedConstraint(T expected, Func<T, bool> match, string predicate)
			: this(expected,match,predicate,null)
		{
		}

		public DelegatedConstraint(T expected, Func<T, bool> match, string predicate, Func<string> modifier)
			: base(expected)
		{
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
			this.expected = expected;
			this.match = match;
			this.predicate = predicate;
			this.modifier = modifier;
		}

		#region Overrides of Constraint

		public override bool Matches(object actualValue)
		{
			actual = actualValue;
			return match((T)actualValue);
		}

		public override void WriteDescriptionTo(MessageWriter writer)
		{
			if (!string.IsNullOrEmpty(predicate))
			{
				writer.WritePredicate(predicate);
			}
			writer.WriteExpectedValue(expected);
			if(modifier != null)
			{
				writer.WriteModifier(modifier());
			}
		}

		#endregion
	}
}