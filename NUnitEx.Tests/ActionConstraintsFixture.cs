using System;
using NUnit.Framework;

namespace NUnitEx.Tests
{
	public class ActionConstraintsFixture
	{
		public class AClass
		{
			public AClass(object obj)
			{
				if (obj == null)
				{
					throw new ArgumentNullException("obj");
				}
			}
		}

		public class BClass
		{
			public BClass(object obj) { }
		}

		[Test]
		public void ShouldWork()
		{
			(new Action(() => new AClass(null)))
				.Should().Throw<ArgumentNullException>()
				.And.
				ValueOf.ParamName
					.Should().Be.EqualTo("obj");

			Assert.Throws<ArgumentNullException>(() => new AClass(null))
				.ParamName.Should().Be.EqualTo("obj");
		}

		[Test]
		public void ShouldWorkUsingCustomMessage()
		{
			const string title = "The ctor does not have parameter protection.";
			try
			{
				(new Action(() => new BClass(null))).Should(title).Throw<ArgumentNullException>();
			}
			catch (AssertionException ae)
			{
				Assert.That(ae.Message, Is.StringContaining(title));
			}
		}

		[Test]
		public void NotThrow()
		{
			(new Action(() => new object())).Should().NotThrow<ArgumentNullException>();
		}

		[Test]
		public void NotThrowShouldWorkUsingCustomMessage()
		{
			const string title = "The ctor has parameter protection.";
			try
			{
				(new Action(() => new AClass(null))).Should(title).NotThrow<ArgumentNullException>();
			}
			catch (AssertionException ae)
			{
				Assert.That(ae.Message, Is.StringContaining(title));
			}
		}
	}
}