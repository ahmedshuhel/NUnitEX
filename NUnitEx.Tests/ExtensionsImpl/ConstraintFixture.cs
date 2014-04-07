using System;
using NUnit.Framework;
using NUnit.Framework.ExtensionsImpl;

namespace NUnitEx.Tests.ExtensionsImpl
{
	public class ConstraintFixture
	{
		private class ConstraintStub<T> : Constraint<T>
		{
			public ConstraintStub(T actual) : base(actual) { }
			public ConstraintStub(T actual, Func<string> messageBuilder) : base(actual, messageBuilder) {}
		}

		[Test]
		public void CTor()
		{
			var c = new ConstraintStub<int>(5);
			Assert.That(c.AssertionInfo, Is.Not.Null);
			Assert.That(c.AssertionInfo.Actual, Is.EqualTo(5));
			Assert.That(c.Parent, Is.Null);
		}

		[Test]
		public void AssertUsingShouldWorkWithActual()
		{
			var c = new ConstraintStub<int>(5);
			c.AssertionInfo.AssertUsing(Is.EqualTo(5));
			Assert.Throws<AssertionException>(() => c.AssertionInfo.AssertUsing(Is.Null));
		}

		[Test]
		public void AssertUsingShouldUseCustomMessage()
		{
			var assertionTitle = "An integer can't be null";
			var cm = new ConstraintStub<int>(5, () => assertionTitle);
			try
			{
				cm.AssertionInfo.AssertUsing(Is.Null);
			}
			catch (AssertionException ae)
			{
				Assert.That(ae.Message, Is.StringContaining(assertionTitle));
			}
		}
	}
}