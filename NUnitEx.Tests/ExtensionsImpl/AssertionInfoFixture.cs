using NUnit.Framework;
using NUnit.Framework.ExtensionsImpl;

namespace NUnitEx.Tests.ExtensionsImpl
{
	public class AssertionInfoFixture
	{
		[Test]
		public void NegationShouldWorkFine()
		{
			var ai = new AssertionInfo<int>(5);
			var nai = (INegable) ai;
			nai.Nagate();
			Assert.That(ai.IsNegated);
			nai.Nagate();
			Assert.That(!ai.IsNegated);
			nai.Nagate();
			Assert.That(ai.IsNegated);
		}

		[Test]
		public void ShouldAcceptNullAsActual()
		{
			var ai = new AssertionInfo<object>(null);
			Assert.That(ai.Actual, Is.Null);
		}

		[Test]
		public void MessageProviderShouldWork()
		{
			var fixedMessage = "My message";
			var ai = new AssertionInfo<object>(null, ()=> fixedMessage);
			Assert.That(ai.FailureMessage, Is.EqualTo(fixedMessage));

			ai = new AssertionInfo<object>(null, () => string.Format("M{0}{1}{2}",1,2,3));
			Assert.That(ai.FailureMessage, Is.EqualTo("M123"));

			ai = new AssertionInfo<object>(null);
			Assert.That(ai.FailureMessage, Is.Null);
		}
	}
}