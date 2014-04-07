using System.Text.RegularExpressions;
using NUnit.Framework.ExtensionsImpl;

namespace NUnit.Framework
{
	public static class StringConstraintsExtensions
	{
		public static IAndConstraints<IStringConstraints> SameInstanceAs(this IStringBeConstraints constraint, string expected)
		{
			constraint.AssertionInfo.AssertUsing(Is.SameAs(expected));
			return ConstraintsHelper.AndChain(constraint.AssertionParent);
		}

		public static IAndConstraints<IStringConstraints> Contain(this IStringConstraints constraint, string expected)
		{
			constraint.AssertionInfo.AssertUsing(Is.StringContaining(expected));
			return ConstraintsHelper.AndChain(constraint);
		}

		public static IAndConstraints<IStringConstraints> StartWith(this IStringConstraints constraint, string expected)
		{
			constraint.AssertionInfo.AssertUsing(Is.StringStarting(expected));
			return ConstraintsHelper.AndChain(constraint);
		}

		public static IAndConstraints<IStringConstraints> EndWith(this IStringConstraints constraint, string expected)
		{
			constraint.AssertionInfo.AssertUsing(Is.StringEnding(expected));
			return ConstraintsHelper.AndChain(constraint);
		}

		public static IAndConstraints<IStringConstraints> Match(this IStringConstraints constraint, string pattern)
		{
			constraint.AssertionInfo.AssertUsing(Is.StringMatching(pattern));
			return ConstraintsHelper.AndChain(constraint);
		}

		public static IAndConstraints<IStringConstraints> Match(this IStringConstraints constraint, Regex regex)
		{
			constraint.AssertionInfo.AssertUsing(new DelegatedConstraint<string>(regex.FieldValue<string>("pattern"),
			                                                                     regex.IsMatch, "String matching",
			                                                                     () => regex.Options.ToString()));
			return ConstraintsHelper.AndChain(constraint);
		}

		public static IAndConstraints<IStringConstraints> NullOrEmpty(this IStringBeConstraints constraint)
		{
			constraint.AssertionInfo.AssertUsing(Is.Null | Is.Empty);
			return ConstraintsHelper.AndChain(constraint.AssertionParent);
		}
	}
}