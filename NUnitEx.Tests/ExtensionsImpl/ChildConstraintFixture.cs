using NUnit.Framework;
using NUnit.Framework.ExtensionsImpl;

namespace NUnitEx.Tests.ExtensionsImpl
{
	public class ChildConstraintFixture
	{
		private class ConstraintStub<T> : Constraint<T>
		{
			public ConstraintStub(T actual) : base(actual) { }
		}

		private class ChildConstraintStub<T> : ChildConstraint<T, IConstraints<T>>
		{
			public ChildConstraintStub(IConstraints<T> parent) : base(parent) {}
		}

		[Test]
		public void CTor()
		{
			var c = new ConstraintStub<int>(5);
			var cc = new ChildConstraintStub<int>(c);

			Assert.That(cc.AssertionInfo, Is.Not.Null);
			Assert.That(cc.AssertionInfo.Actual, Is.EqualTo(5));
			Assert.That(cc.AssertionParent, Is.SameAs(c));
		}
	}
}