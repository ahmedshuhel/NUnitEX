using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NUnitEx.Tests
{
	[TestFixture]
	public class ClassConstraintsFixture
	{
		[Test]
		public void ShouldWork()
		{
			object something = null;
			something.Should().Not.Be.EqualTo(new object());
			something.Should().Be.Null();
			something = new object();
			something.Should().Be.EqualTo(something);
			something.Should().Not.Be.Null();
		}

		[Test]
		public void ShouldWorkUsingCustomMessage()
		{
			string title = "An instance can't be null";
			try
			{
				(new object()).Should(title).Be.Null();
			}
			catch (AssertionException ae)
			{
				Assert.That(ae.Message, Is.StringContaining(title));
			}
		}

		[Test]
		public void ShouldWorkUsingCustomTitleWithConstraintChain()
		{
			string title = "An instance can't be null";
			try
			{
				(new object()).Should(title).Not.Be.Null().And.Be.OfType<object>().And.Be.Null();
			}
			catch (AssertionException ae)
			{
				Assert.That(ae.Message, Is.StringContaining(title));
			}
		}

		[Test]
		public void SameAs_ConstraintShouldWork()
		{
			var something = new object();
			something.Should().Be.SameInstanceAs(something);
			something.Should().Not.Be.SameInstanceAs(new object());
		}

		private class B {}

		private class D1 : B {}

		private class D2 : D1
		{
			public string StringProperty;
		}

		[Test]
		public void InstanceOfShouldWork()
		{
			(new D2()).Should().Be.InstanceOf<B>();
			(new B()).Should().Not.Be.InstanceOf<D2>();
		}

		[Test]
		public void TypeOfShouldWork()
		{
			(new D2()).Should().Be.OfType<D2>();
			(new D2()).Should().Not.Be.OfType<D1>();
		}

		[Test]
		public void AssignableFromShouldWork()
		{
			(new D1()).Should().Be.AssignableFrom<D1>();
			(new D1()).Should().Be.AssignableFrom<D2>();
			(new D1()).Should().Not.Be.AssignableFrom<B>();
		}

		[Test]
		public void AssignableToShouldWork()
		{
			(new D2()).Should().Be.AssignableTo<D1>();
			(new D2()).Should().Be.AssignableTo<B>();
			(new D1()).Should().Not.Be.AssignableTo<D2>();
		}

		[Serializable]
		public class Seri {}

		[Test]
		public void SerializableShouldWork()
		{
			(new Seri()).Should().Be.BinarySerializable();
			(new Seri()).Should().Be.XmlSerializable();
			(new B()).Should().Not.Be.BinarySerializable();
			(new B()).Should().Not.Be.XmlSerializable();
		}

		[Test]
		public void AndChainShouldWork()
		{
			(new D1()).Should().Be.AssignableFrom<D1>().And.Be.AssignableFrom<D2>();
		}

		[Test]
		public void AndChainShouldWorkWithDoubleNegation()
		{
			var something = new object();
			something.Should().Not.Be.Null().And.Not.Be.EqualTo(new object());			
		}

		[Test]
		public void TypeOfChainShouldWork()
		{
			var instanceOfClass = new D2();

			instanceOfClass.Should()
				.Be.AssignableTo<D1>()
				.And.Be.OfType<D2>()
				.And.ValueOf.StringProperty
					.Should().Be.Null();
		}

		[Test]
		public void TypeOfAndValueChainShouldWork()
		{
			object instanceOfClass = new HashSet<int> {1, 2, 3};

			instanceOfClass.Should()
				.Be.OfType<HashSet<int>>()
				.And.Value.Should().Have.SameSequenceAs(new[]{1,2,3});
		}
	}
}