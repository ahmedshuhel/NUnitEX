using System;
using NUnit.Framework;

namespace NUnitEx.Tests
{
	[TestFixture]
	public class ObjectExtensionsFixture
	{
		public class A
		{
			private int oneField;

			public int OneField
			{
				get { return oneField; }
				set { oneField = value; }
			}
		}

		[Test]
		public void NotAllowNull()
		{
			Assert.Throws<ArgumentNullException>(() => ((string) null).FieldValue<int>("something"))
				.ParamName.Should().Be.EqualTo("source");
		}

		[Test]
		public void NotExsistentField()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => new A().FieldValue<int>("something"))
				.ParamName.Should().Be.EqualTo("fieldName");
		}

		[Test]
		public void InvalidCast()
		{
			Assert.Throws<InvalidCastException>(() => new A().FieldValue<string>("oneField"))
				.Message.Should().Contain("oneField").And.Contain("System.Int32").And.Contain("System.String");
		}

		[Test]
		public void Work()
		{
			var a = new A();
			a.FieldValue<int>("oneField").Should().Be.EqualTo(0);
			a.OneField = 5;
			a.FieldValue<int>("oneField").Should().Be.EqualTo(5);
		}
	}
}