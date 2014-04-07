using System;
using System.Linq;
using System.Linq.Expressions;
using NUnit.Framework.Constraints;

namespace NUnit.Framework.ExtensionsImpl
{
	public class ExpressionVisitor<T>
	{
		private const string InvalidBothSidesMessage = "Expression {0} invalid (both side not include the actual parameter)";
		private readonly T actualValue;
		private ParameterExpression actualParameter;
		private readonly ConstraintBuilder builder = new ConstraintBuilder();

		public ExpressionVisitor(T actualValue)
		{
			this.actualValue = actualValue;
		}

		public bool Visit(Expression<Func<T, bool>> expression)
		{
			actualParameter = expression.Parameters.Single();
			Visit(expression.Body);
			Assert.That(actualValue, builder.Resolve());
			return true;
		}

		private void Visit(Expression expression)
		{
			switch (expression.NodeType)
			{
				case ExpressionType.Equal:
				case ExpressionType.NotEqual:
				case ExpressionType.GreaterThan:
				case ExpressionType.LessThan:
				case ExpressionType.GreaterThanOrEqual:
				case ExpressionType.LessThanOrEqual:
				case ExpressionType.OrElse:
				case ExpressionType.AndAlso:
					Visit(expression as BinaryExpression);
					break;
				case ExpressionType.Call:
					Visit(expression as MethodCallExpression);
					break;
				case ExpressionType.Not:
					Visit(expression as UnaryExpression);
					break;
				default: throw new ExpressionNotHandledException<Expression>(expression.NodeType);
			}
		}

		private void Visit(UnaryExpression expression)
		{
			switch (expression.NodeType)
			{
				case ExpressionType.Not:
					builder.Append(new NotOperator());
					break;
				default: throw new ExpressionNotHandledException<UnaryExpression>(expression.NodeType);
			}

			Visit(expression.Operand);
		}

		private void Visit(MethodCallExpression expression)
		{
			builder.Append(new BooleanMethodCallExpressionConstraint<T>(expression, actualParameter));
		}

		private void Visit(BinaryExpression expression)
		{
			switch (expression.NodeType)
			{
				case ExpressionType.Equal:
					ValidateComparisonExpression(expression);

					VisitComparisonExpression<EqualConstraint>(expression);
					break;
				case ExpressionType.NotEqual:
					ValidateComparisonExpression(expression);

					VisitNotExpression();
					VisitComparisonExpression<EqualConstraint>(expression);
					break;
				case ExpressionType.GreaterThan:
					ValidateComparisonExpression(expression);
					if(expression.Left == actualParameter)
					{
						VisitComparisonExpression<GreaterThanConstraint>(expression);
					}
					else
					{
						VisitComparisonExpression<LessThanConstraint>(expression);
					}
					break;
				case ExpressionType.LessThan:
					ValidateComparisonExpression(expression);
					if (expression.Left == actualParameter)
					{
						VisitComparisonExpression<LessThanConstraint>(expression);
					}
					else
					{
						VisitComparisonExpression<GreaterThanConstraint>(expression);
					}
					break;
				case ExpressionType.GreaterThanOrEqual:
					ValidateComparisonExpression(expression);
					if (expression.Left == actualParameter)
					{
						VisitComparisonExpression<GreaterThanOrEqualConstraint>(expression);
					}
					else
					{
						VisitComparisonExpression<LessThanOrEqualConstraint>(expression);
					}
					break;
				case ExpressionType.LessThanOrEqual:
					ValidateComparisonExpression(expression);
					if (expression.Left == actualParameter)
					{
						VisitComparisonExpression<LessThanOrEqualConstraint>(expression);
					}
					else
					{
						VisitComparisonExpression<GreaterThanOrEqualConstraint>(expression);
					}
					break;
				case ExpressionType.OrElse:
					Visit(expression.Left);
					VisitOrExpression();
					Visit(expression.Right);
					break;
				case ExpressionType.AndAlso:
					Visit(expression.Left);
					VisitAndExpression();
					Visit(expression.Right);
					break;
				default: throw new ExpressionNotHandledException<BinaryExpression>(expression.NodeType);
			}
		}

		private void VisitComparisonExpression<TConstraint>(BinaryExpression expression) where TConstraint : Constraint
		{
			builder.Append(Activator.CreateInstance(typeof(TConstraint), EvaluateExpression(expression.Left == actualParameter ? expression.Right : expression.Left)) as TConstraint);
		}

		private void ValidateComparisonExpression(BinaryExpression expression)
		{
			if (expression.Left != actualParameter && expression.Right != actualParameter)
			{
				throw new InvalidOperationException(string.Format(InvalidBothSidesMessage, expression));				
			}
		}

		private object EvaluateExpression(Expression expression)
		{
			switch (expression.NodeType)
			{
				case ExpressionType.Constant:
					return ((ConstantExpression)expression).Value;
				case ExpressionType.Call:
				case ExpressionType.MemberAccess:
				case ExpressionType.ArrayIndex:
				case ExpressionType.Multiply:
				case ExpressionType.Divide:
				case ExpressionType.Add:
				case ExpressionType.Subtract:
					return Expression.Lambda<Func<T, object>>(Expression.Convert(expression, typeof(object)),
																										actualParameter).Compile().Invoke(actualValue);
				case ExpressionType.Parameter:
					return actualValue;
				default: throw new ExpressionNotHandledException<Expression>(expression.NodeType);
			}
		}

		private void VisitAndExpression()
		{
			builder.Append(new AndOperator());
		}

		private void VisitOrExpression()
		{
			builder.Append(new OrOperator());
		}

		private void VisitNotExpression()
		{
			builder.Append(new NotOperator());
		}
	}
}