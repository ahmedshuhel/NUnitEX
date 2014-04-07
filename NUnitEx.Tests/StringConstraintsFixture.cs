using System.Text.RegularExpressions;
using NUnit.Framework;

namespace NUnitEx.Tests
{
	[TestFixture]
	public class StringConstraintsFixture
	{
		[Test]
		public void ShouldWork()
		{
			"a".Should().Be.EqualTo("a");
			"a".Should().Not.Be.Empty();
			"a".Should().Not.Be.Null();
			"".Should().Be.Empty();
			"".Should().Not.Be.EqualTo("a");
			((string)null).Should().Be.Null();
		}

		[Test]
		public void ShouldWorkUsingCustomMessage()
		{
			var title = "My message";
			try
			{
				"a".Should(title).Be.EqualTo("b");
			}
			catch (AssertionException ae)
			{
				Assert.That(ae.Message, Is.StringContaining(title));
			}
		}

		[Test]
		public void SameAs_ConstraintShouldWork()
		{
			const string something = "something";
			something.Should().Be.SameInstanceAs(something);
			something.Should().Not.Be.SameInstanceAs("some");
		}

		[Test]
		public void ContainShouldWork()
		{
			const string something = "something";
			something.Should().Contain("some");
			something.ToUpperInvariant().Should().Contain("some".ToUpperInvariant());
			something.Should().Not.Contain("also");
			something.ToUpperInvariant().Should().Not.Contain("some");
		}

		[Test]
		public void StartsWithShouldWork()
		{
			const string something = "something";
			something.Should().StartWith("some");
			something.ToUpperInvariant().Should().StartWith("some".ToUpperInvariant());
			something.Should().Not.StartWith("ome");
		}

		[Test]
		public void EndsWithShouldWork()
		{
			const string something = "something";
			something.Should().EndWith("ing");
			something.ToUpperInvariant().Should().EndWith("ing".ToUpperInvariant());
			something.Should().Not.EndWith("some");
		}

		[Test]
		public void MatchShouldWork()
		{
			const string something = "something";
			something.Should().Match("ome[tT]h");
			something.ToUpperInvariant().Should().Match("ome[tT]h".ToUpperInvariant());
			something.Should().Not.Match("omeTh");
		}

		[Test]
		public void AndChainShouldWork()
		{
			"a".Should().Be.EqualTo("a").And.Not.Be.Empty();
			"a".Should().Not.Be.Empty().And.Not.Be.Null();
			"a".Should().Not.Be.EqualTo("b").And.Not.Be.Empty();
		}

		[Test]
		public void AndChainExtensionsShouldWork()
		{
			const string something = "something";

			something.Should()
				.StartWith("so")
				.And
				.EndWith("ing")
				.And
				.Contain("meth");

			something.Should()
				.StartWith("so")
				.And
				.EndWith("ing")
				.And
				.Not.Contain("body");

			something.Should()
				.Not.StartWith("ing")
				.And
				.Not.EndWith("so")
				.And
				.Not.Contain("body");
		}

		[Test]
		public void NullOrEmpty()
		{
			string something = null;
			something.Should().Be.NullOrEmpty();
			string.Empty.Should().Be.NullOrEmpty();
			something = "something";
			something.Should().Not.Be.NullOrEmpty();
		}

		[Test]
		public void RegEx()
		{
			const RegexOptions ro = RegexOptions.Singleline | RegexOptions.IgnoreCase;
			var re = new Regex("a.b", ro);
			"a\nb".Should().Match(re);
			Assert.Throws<AssertionException>(() => "zzz".Should().Match(re)).Message.Should().Contain("String matching").And.
				Contain("a.b").And.Contain(ro.ToString());
		}
	}
}