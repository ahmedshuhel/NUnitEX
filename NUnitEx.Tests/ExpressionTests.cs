using System;
using System.Linq;
using NUnit.Framework;

namespace NUnitEx.Tests
{
	[TestFixture]
	public class ExpressionTests
	{
		private const string InvalidBothSidesMessagePart = "both side not include the actual parameter";

		[Test]
		public void Equal()
		{
			1.Should().Satisfy(x => x == 1);
		}

		[Test]
		public void Equal_fails()
		{
			Assert.Throws<AssertionException>(() => 1.Should().Satisfy(x => x == 2))
				.Message.Should().Contain(string.Format("2{0}  But was:  1",Environment.NewLine));
		}

		[Test]
		public void Not_equal()
		{
			1.Should().Satisfy(x => x != 2);
			1.Should().Satisfy(x => 2 != x);
		}

		[Test]
		public void Not_equal_fails()
		{
			Assert.Throws<AssertionException>(() => 1.Should().Satisfy(x => x != 1))
				.Message.Should().Contain(string.Format("not 1{0}  But was:  1", Environment.NewLine));
		}

		[Test]
		public void And()
		{
			1.Should().Satisfy(x => x == 1 && x != 2);
		}


		[Test]
		public void And_fails()
		{
			Assert.Throws<AssertionException>(() => 1.Should().Satisfy(x => x == 1 && x == 2))
				.Message.Should().Contain(string.Format("1 and 2{0}  But was:  1", Environment.NewLine));
		}

		[Test]
		public void Or()
		{
			1.Should().Satisfy(x => x == 1 || x == 2);
		}

		[Test]
		public void Or_fails()
		{
			Assert.Throws<AssertionException>(() => 1.Should().Satisfy(x => x == 2 || x == 3))
				.Message.Should().Contain(string.Format("2 or 3{0}  But was:  1", Environment.NewLine));
		}

		[Test]
		public void Greater()
		{
			1.Should().Satisfy(x => x > 0);
			1.Should().Satisfy(x => 2 > x);
		}

		[Test]
		public void Greater_fails()
		{
			Assert.Throws<AssertionException>(() => 1.Should().Satisfy(x => x > 2))
				.Message.Should().Contain(string.Format("greater than 2{0}  But was:  1",Environment.NewLine));
			Assert.Throws<AssertionException>(() => 1.Should().Satisfy(x => 0 > x))
				.Message.Should().Contain(string.Format("less than 0{0}  But was:  1", Environment.NewLine));
		}

		[Test]
		public void Greater_or_equal()
		{
			1.Should().Satisfy(x => x >= 1);
			1.Should().Satisfy(x => 1 >= x);
			1.Should().Satisfy(x => 2 >= x);
		}

		[Test]
		public void Greater_or_equal_fails()
		{
			Assert.Throws<AssertionException>(() => 1.Should().Satisfy(x => x >= 2))
				.Message.Should().Contain(string.Format("greater than or equal to 2{0}  But was:  1",Environment.NewLine));
			Assert.Throws<AssertionException>(() => 1.Should().Satisfy(x => 0 >= x))
				.Message.Should().Contain(string.Format("less than or equal to 0{0}  But was:  1", Environment.NewLine));
		}

		[Test]
		public void Less()
		{
			1.Should().Satisfy(x => x < 2);
			1.Should().Satisfy(x => 0 < x);
		}

		[Test]
		public void Less_fails()
		{
			Assert.Throws<AssertionException>(() => 1.Should().Satisfy(x => x < 1))
				.Message.Should().Contain(string.Format("less than 1{0}  But was:  1",Environment.NewLine));
			Assert.Throws<AssertionException>(() => 1.Should().Satisfy(x => 2 < x))
				.Message.Should().Contain(string.Format("greater than 2{0}  But was:  1", Environment.NewLine));
		}

		[Test]
		public void Less_or_equal()
		{
			1.Should().Satisfy(x => x <= 1);
			1.Should().Satisfy(x => 1 <= x);
			1.Should().Satisfy(x => 0 <= x);
		}

		[Test]
		public void Less_or_equal_fails()
		{
			Assert.Throws<AssertionException>(() => 1.Should().Satisfy(x => x <= 0))
				.Message.Should().Contain(string.Format("less than or equal to 0{0}  But was:  1",Environment.NewLine));
			Assert.Throws<AssertionException>(() => 1.Should().Satisfy(x => 2 <= x))
				.Message.Should().Contain(string.Format("greater than or equal to 2{0}  But was:  1", Environment.NewLine));
		}

		[Test]
		public void Not()
		{
			"abc".Should().Satisfy(x => !x.Contains("d"));
		}

		[Test]
		public void Notfails()
		{
			Assert.Throws<AssertionException>(() => "abc".Should().Satisfy(x => !x.Contains("a")))
				.Message.Should().Contain(" not ").And.Contain(string.Format("Contains(\"a\")\"{0}  But was:  \"abc\"", Environment.NewLine));
		}

		[Test]
		public void Operations_on_right_side()
		{
			var y = 2;
			var z = 4;

			4.Should().Satisfy(x => x == y * y);
			2.Should().Satisfy(x => x == z / y);
			4.Should().Satisfy(x => x == y + y);
			2.Should().Satisfy(x => x == z - y);
		}

		[Test]
		public void Static_method_called_on_parameter_with_no_arguments()
		{
			"a".Should().Satisfy(x => x.Any());
		}

		[Test]
		public void Static_method_called_on_parameter_with_no_arguments_fails()
		{
			Assert.Throws<AssertionException>(() => "".Should().Satisfy(x => x.Any()))
				.Message.Should().Contain(string.Format("Any()\"{0}  But was:  <string.Empty>", Environment.NewLine));
		}

		[Test]
		public void Static_method_called_on_parameter_with_simple_arguments()
		{
			new[] { 1, 2 }.Should().Satisfy(x => x.Contains(1));
		}

		[Test]
		public void Static_method_called_on_parameter_with_simple_arguments_fails()
		{
			Assert.Throws<AssertionException>(() => new[] { 1, 2 }.Should().Satisfy(x => x.Contains(3)))
				.Message.Should().Contain(string.Format("Contains(3)\"{0}  But was:  < 1, 2 >", Environment.NewLine));
		}

		[Test]
		public void Static_method_called_on_parameter_with_lambda_argument()
		{
			new[] { 1, 2, 3 }.Should().Satisfy(x => x.All(y => y > 0));
		}

		[Test]
		public void Static_method_called_on_parameter_with_lambda_argument_fails()
		{
			Assert.Throws<AssertionException>(() => new[] { 1, 2, 3 }.Should().Satisfy(x => x.All(y => y > 1)))
				.Message.Should().Contain(string.Format("All(y => (y > 1))\"{0}  But was:  < 1, 2, 3 >", Environment.NewLine));
		}

		[Test]
		public void Instance_method_called_on_parameter_with_simple_arguments()
		{
			"abc".Should().Satisfy(x => x.Contains("a"));
		}

		[Test]
		public void Instance_method_called_on_parameter_with_simple_arguments_fails()
		{
			Assert.Throws<AssertionException>(() => "abc".Should().Satisfy(x => x.Contains("d")))
				.Message.Should().Contain(string.Format("Contains(\"d\")\"{0}  But was:  \"abc\"", Environment.NewLine));
		}

		[Test]
		public void Static_method_call_on_right_side()
		{
			1.Should().Satisfy(x => x == int.Parse("1"));
		}

		[Test]
		public void Static_method_call_on_right_side_fails()
		{
			Assert.Throws<AssertionException>(() => 1.Should().Satisfy(x => x == int.Parse("2")))
				.Message.Should().Contain(string.Format("2{0}  But was:  1", Environment.NewLine));
		}

		[Test]
		public void Instance_method_call_on_right_side()
		{
			"1".Should().Satisfy(x => x == 1.ToString());
		}

		[Test]
		public void Instance_method_call_on_right_side_fails()
		{
			Assert.Throws<AssertionException>(() => "1".Should().Satisfy(x => x == 2.ToString()))
				.Message.Should().Contain(string.Format("\"2\"{0}  But was:  \"1\"", Environment.NewLine));
		}

		[Test]
		public void Parameter_on_right_side()
		{
			1.Should().Satisfy(x => x == x);
		}

		[Test]
		public void Parameter_on_right_side_fails()
		{
			Assert.Throws<AssertionException>(() => 1.Should().Satisfy(x => x != x))
				.Message.Should().Contain(string.Format("not 1{0}  But was:  1", Environment.NewLine));
		}

		[Test]
		public void Method_call_on_parameter_on_right_side()
		{
			1.Should().Satisfy(x => x == int.Parse(x.ToString()));
		}

		[Test]
		public void Method_call_on_parameter_on_right_side_fails()
		{
			Assert.Throws<AssertionException>(() => 1.Should().Satisfy(x => x == int.Parse(x.ToString() + 1)))
				.Message.Should().Contain(string.Format("11{0}  But was:  1", Environment.NewLine));
		}

		[Test]
		public void Invalid_operands()
		{
			Assert.Throws<InvalidOperationException>(() => 1.Should().Satisfy(x => x.ToString() == "1"))
				.Message.Should().Contain(InvalidBothSidesMessagePart);
		}

		[Test]
		public void Valid_left_side_operand()
		{
			var y = 1;
			1.Should().Satisfy(x => y == x);
		}

		[Test]
		public void Invalid_left_side_operand_4()
		{
			Assert.Throws<InvalidOperationException>(() => "".Should().Satisfy(x => x.Length == 0))
				.Message.Should().Contain(InvalidBothSidesMessagePart);
		}

		[Test]
		public void Invalid_left_side_operand_5()
		{
			Assert.Throws<InvalidOperationException>(() => "".Should().Satisfy(x => x[0] == 0))
				.Message.Should().Contain(InvalidBothSidesMessagePart);
		}

		[Test]
		public void CaptureExternalVariable()
		{
			const int y = 1;
			1.Should().Satisfy(x => x == y);
		}

		[Test]
		public void CaptureExternalVariableFails()
		{
			const int y = 2;
			Assert.Throws<AssertionException>(() => 1.Should().Satisfy(x => x == y))
				.Message.Should().Contain(string.Format("2{0}  But was:  1", Environment.NewLine));
		}

		[Test]
		public void CaptureExternalVariableArray()
		{
			var y = new[] { 1, 2 };
			var z = new[] { 2, 1 };

			1.Should().Satisfy(x => x == y[0] && x == z[1]);
		}

		[Test]
		public void CaptureExternalVariableArrayFails()
		{
			var y = new[] { 1, 2 };
			var z = new[] { 2, 1 };

			Assert.Throws<AssertionException>(() => 1.Should().Satisfy(x => x == y[0] && x == z[0]))
				.Message.Should().Contain(string.Format("1 and 2{0}  But was:  1", Environment.NewLine));
		}

		[Test]
		public void MethodCallWithCapturedVariableArgument()
		{
			var y = 2;
			new[] { 1, 2 }.Should().Satisfy(x => x.Contains(y));
		}

		[Test]
		public void MethodCallWithCapturedVariableArgumentFails()
		{
			var y = 3;
			Assert.Throws<AssertionException>(() => new[] { 1, 2 }.Should().Satisfy(x => x.Contains(y)))
				.Message.Should().Contain(string.Format("y)\"{0}  But was:  < 1, 2 >", Environment.NewLine));
		}
	}
}