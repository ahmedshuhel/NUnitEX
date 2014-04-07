using System;
using NUnit.Framework;
using NUnit.Framework.ExtensionsImpl;

namespace NUnitEx.Tests.ExtensionsImpl
{
	[TestFixture]
	public class DelegatedConstraintFixture
	{
		[Test]
		public void Ctor()
		{
			Assert.Throws<ArgumentNullException>(() => new DelegatedConstraint<int>(0, null, null))
				.ParamName.Should().Be.EqualTo("match");
			Assert.DoesNotThrow(() => new DelegatedConstraint<int>(0, v=>true, null));
			Assert.DoesNotThrow(() => new DelegatedConstraint<int>(0, v => true, null, null));
		}

		[Test]
		public void Match()
		{
			var cTrue = new DelegatedConstraint<int>(0, v => true, null);
			var cFalse = new DelegatedConstraint<int>(0, v => false, null);
			Assert.That(cTrue.Matches(0));
			Assert.That(!cFalse.Matches(0));
		}

		[Test]
		public void Predicate()
		{
			const string predicate = "my Predicate";
			var c = new DelegatedConstraint<int>(5, v => v == 5, predicate);
			Assert.Throws<AssertionException>(() => Assert.That(6, c))
				.Message.Should().Contain(predicate);

			var c1 = new DelegatedConstraint<int>(5, v => v == 5, null);
			Assert.Throws<AssertionException>(() => Assert.That(6, c1))
				.Message.Should().Not.Contain(predicate).And.Contain("6");
		}

		[Test]
		public void Modifier()
		{
			const string modifier = "my modifier";
			var c = new DelegatedConstraint<int>(5, v => v == 5, null, ()=>modifier);
			Assert.Throws<AssertionException>(() => Assert.That(6, c))
				.Message.Should().Contain(modifier).And.Contain("6");

			var c1 = new DelegatedConstraint<int>(5, v => v == 5, null, null);
			Assert.Throws<AssertionException>(() => Assert.That(6, c1))
				.Message.Should().Not.Contain(modifier).And.Contain("6");
		}

		[Test]
		public void PredicateModifier()
		{
			const string predicate = "my Predicate";
			const string modifier = "my modifier";
			var c = new DelegatedConstraint<int>(5, v => v == 5, predicate, ()=> modifier);
			Assert.Throws<AssertionException>(() => Assert.That(6, c))
				.Message.Should().Contain(predicate).And.Contain(modifier).And.Contain("6");

			var c1 = new DelegatedConstraint<int>(5, v => v == 5, null);
			Assert.Throws<AssertionException>(() => Assert.That(6, c1))
				.Message.Should().Not.Contain(predicate).And.Not.Contain(modifier).And.Contain("6");
		}
	}
}