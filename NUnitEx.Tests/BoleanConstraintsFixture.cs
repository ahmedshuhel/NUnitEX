using NUnit.Framework;

namespace NUnitEx.Tests
{
	public class BoleanConstraintsFixture
	{
		[Test]
		public void ShouldWork()
		{
			true.Should().Be.True();
			false.Should().Be.False();

			Assert.Throws<AssertionException>(() => false.Should().Be.True());
			Assert.Throws<AssertionException>(() => true.Should().Be.False());
		}

		[Test]
		public void ShouldWorkUsingCustomMessage()
		{
			const bool started = true;
			var title = "The UoW should be started";
			try
			{
				(!started).Should(title).Be.True();				
			}
			catch (AssertionException ae)
			{
				Assert.That(ae.Message, Is.StringContaining(title));
			}
		}
	}
}