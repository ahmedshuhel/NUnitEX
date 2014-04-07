using System.Linq.Expressions;
using System;

namespace NUnit.Framework.ExtensionsImpl
{
	public class ExpressionNotHandledException<TExpression> : Exception
	{
		public ExpressionNotHandledException(ExpressionType nodeType) :
			base(string.Format("{0} of type \"{1}\" not handled", typeof(TExpression).Name, nodeType))
		{ }
	}
}