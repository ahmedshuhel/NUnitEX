using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitEx.Tests
{
	[TestFixture]
	public class EnumerableConstraintsFixture
	{
		[Test]
		public void ShouldWork()
		{
			var ints = new[] { 1, 2, 3 };
			ints.Should().Have.SameSequenceAs(new[] { 1, 2, 3 });
			ints.Should().Not.Have.SameSequenceAs(new[] { 3, 2, 1 });
			ints.Should().Not.Be.Null();
			ints.Should().Not.Be.Empty();
			(new int[0]).Should().Be.Empty();
			((IEnumerable<int>)null).Should().Be.Null();
		}

		[Test]
		public void SameSequenceAsWithParams()
		{
			var ints = new[] { 1, 2, 3 };
			ints.Should().Have.SameSequenceAs(1, 2, 3);
		}

		[Test]
		public void ShouldWorkUsingCustomMessage()
		{
			var title = "A title";
			try
			{
				(new int[0]).Should(title).Be.Null();
			}
			catch (AssertionException ae)
			{
				Assert.That(ae.Message, Is.StringContaining(title));
			}
		}

		[Test]
		public void SameAsShouldWork()
		{
			var ints = new int[0];
			ints.Should().Be.SameInstanceAs(ints);
			ints.Should().Not.Be.SameInstanceAs(new int[0]);
		}

		[Test]
		public void ContainsShouldWork()
		{
			var ints = new[] { 1, 2, 3 };
			ints.Should().Contain(2);
			ints.Should().Not.Contain(4);
		}

		[Test]
		public void EquivalentsShouldWork()
		{
			var ints = new[] { 1, 2, 3 };
			ints.Should().Have.SameValuesAs(new[] { 3, 2, 1 });
			ints.Should().Have.SameValuesAs(3, 2, 1);
			ints.Should().Not.Have.SameValuesAs(new[] { 4, 2, 1 });
		}

		[Test]
		public void UniqueShouldWork()
		{
			(new[] { 1, 2, 3 }).Should().Have.UniqueValues();
			(new[] { 1, 2, 1 }).Should().Not.Have.UniqueValues();
		}

		[Test]
		public void SubsetOfShouldWork()
		{
			(new[] { 1, 2, 3 }).Should().Be.SubsetOf(new[] { 1, 2, 3, 4 });
			(new[] { 1, 2, 3 }).Should().Be.SubsetOf(1, 2, 3, 4);
			(new[] { 1, 2, 3 }).Should().Not.Be.SubsetOf(new[] { 1, 4, 5, 6 });
		}

		[Test]
		public void OrderedShouldWork()
		{
			(new[] { 1, 2, 3 }).Should().Be.Ordered();
			(new[] { 3, 2, 1 }).Should().Be.Ordered();
			(new[] { 4, 2, 5 }).Should().Not.Be.Ordered();
		}

		[Test]
		public void AndChainShouldWork()
		{
			var ints = new[] { 1, 2, 3 };
			ints.Should()
				.Have.SameSequenceAs(new[] { 1, 2, 3 })
				.And
				.Not.Have.SameSequenceAs(new[] { 3, 2, 1 })
				.And
				.Not.Be.Null()
				.And
				.Not.Be.Empty();
		}

		[Test]
		public void AndChainExtensionsShouldWork()
		{
			var ints = new[] { 1, 2, 3 };
			ints.Should().Contain(2).And.Not.Contain(4);
		}

		[Test]
		public void Count()
		{
			var ints = new[] { 1, 2, 3 };
			ints.Should().Have.Count.EqualTo(3);
			ints.Should().Not.Have.Count.EqualTo(2);
			ints.Should("chain not negated and negated").Contain(3).And.Not.Have.Count.LessThan(2);
		}

		[Test]
		public void OrderedAscendingShouldWork()
		{
			(new[] { 1, 2, 3 }).Should().Be.OrderedAscending();
			(new[] { 3, 2, 1 }).Should().Not.Be.OrderedAscending();
			(new[] { 4, 2, 5 }).Should().Not.Be.OrderedAscending();
		}

		[Test]
		public void OrderedDescendingShouldWork()
		{
			(new[] { 3, 2, 1 }).Should().Be.OrderedDescending();
			(new[] { 1, 2, 3 }).Should().Not.Be.OrderedDescending();
			(new[] { 4, 2, 5 }).Should().Not.Be.OrderedDescending();
		}
	}
}