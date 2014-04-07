using NUnit.Framework;

namespace NUnitEx.Tests
{
	public class NullableComparableConstraintsFixture
	{
		[Test]
		public void ShouldWork()
		{
			int? nullable= null;
			nullable.Should().Not.Have.Value();

			nullable = 5;
			nullable.Should().Have.Value();
		}

		[Test]
		public void NegationOfDefaultBehaviuor()
		{
			int? nullable = 5;
			nullable.Should().Not.Be.GreaterThan(6);
		}
	}
}