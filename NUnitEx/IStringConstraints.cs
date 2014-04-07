using System;

namespace NUnit.Framework
{
	public interface IStringConstraints : IBeConstraints<IStringBeConstraints>, INegableConstraints<IStringConstraints>,
	                                      IConstraints<string>, ICloneable {}

	public interface IStringBeConstraints : IChildAndChainableConstraints<string, IStringConstraints>
	{
		IAndConstraints<IStringConstraints> EqualTo(string expected);
		IAndConstraints<IStringConstraints> Null();
		IAndConstraints<IStringConstraints> Empty();
	}
}