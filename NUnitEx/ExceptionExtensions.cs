using System;
using System.Collections.Generic;

namespace NUnit.Framework
{
	public static class ExceptionExtensions
	{
		public static IEnumerable<Exception> InnerExceptions(this Exception source)
		{
			Exception current= source.InnerException;
			while (current != null)
			{
				yield return current;
				current = current.InnerException;
			}
		}

		public static IEnumerable<Exception> Exceptions(this Exception source)
		{
			Exception current = source;
			while (current != null)
			{
				yield return current;
				current = current.InnerException;
			}
		}
	}
}