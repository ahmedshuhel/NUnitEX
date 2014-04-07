using System;
namespace NUnit.Framework
{
	public interface IActionConstraints: IConstraints<Action>
	{
		IAndConstraints<IThrowConstraints<TException>> Throw<TException>() where TException : Exception;
		void NotThrow<TException>() where TException : Exception;
	}

	public interface IThrowConstraints<TException>: ICloneable where TException : Exception
	{
		TException ValueOf { get; }
	}
}