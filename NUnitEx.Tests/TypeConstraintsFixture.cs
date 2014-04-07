using System;
using NUnit.Framework;

namespace NUnitEx.Tests
{
	[TestFixture]
	public class TypeConstraintsFixture
	{
		private class B {}

		[Serializable]
		private class D1 : B { }

		private interface ID2 { }
		private class D2 : D1, ID2 { }

		[Test]
		public void SubClassOf()
		{
			typeof (D1).Should().Be.SubClassOf<B>();
			typeof(D1).Should().Not.Be.SubClassOf<D2>();
		}

		[Test]
		public void ShouldWorkUsingCustomMessage()
		{
			var title = "My message";
			try
			{
				typeof(D1).Should(title).Be.SubClassOf<D2>();
			}
			catch (AssertionException ae)
			{
				Assert.That(ae.Message, Is.StringContaining(title));
			}
		}

		[Test]
		public void AssignableFrom()
		{
			typeof(D1).Should().Be.AssignableFrom<D2>();
			typeof(D1).Should().Not.Be.AssignableFrom<B>();
		}

		[Test]
		public void EqualTo()
		{
			typeof(D1).Should().Be.EqualTo<D1>();
			typeof(D1).Should().Not.Be.EqualTo<B>();
		}

		[Test]
		public void Null()
		{
			Type t = null;
			t.Should().Be.Null();
			typeof(D1).Should().Not.Be.Null();
		}

		[Test]
		public void Attribute()
		{
			typeof(D1).Should().Have.Attribute<SerializableAttribute>();
			typeof(B).Should().Not.Have.Attribute<SerializableAttribute>();
		}

		[Test]
		public void AssignableTo()
		{
			typeof(D2).Should().Be.AssignableTo<ID2>();

			Assert.Throws<AssertionException>(() => typeof (D1).Should().Be.AssignableTo<ID2>())
				.Message.Should().Contain("Assignable To");

			typeof(D1).Should().Not.Be.AssignableTo<ID2>();
		}
	}
}