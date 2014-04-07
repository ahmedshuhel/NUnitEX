using System;

namespace NUnit.Framework
{
	public interface INullableComparableConstraints<T> : IBeConstraints<IComparableBeConstraints<T>>,
	                                                     INegableConstraints<INullableComparableConstraints<T>>,
	                                                     IConstraints<T>, ICloneable,
	                                                     IHaveConstraints<IHaveNullableComparableConstraints<T>> {}

	public interface IHaveNullableComparableConstraints<T> : IConstraints<T>
	{
		void Value();
	}
}