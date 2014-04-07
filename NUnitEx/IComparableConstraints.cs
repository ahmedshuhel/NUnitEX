using System;

namespace NUnit.Framework
{
	public interface IComparableConstraints<T> : IBeConstraints<IComparableBeConstraints<T>>,
	                                             INegableConstraints<IComparableConstraints<T>>, IConstraints<T>,
	                                             ICloneable {}




	public interface IComparableBeConstraints<T> : IConstraints<T>
	{
		IAndConstraints<IComparableConstraints<T>> EqualTo(IComparable expected);
		IAndConstraints<IComparableConstraints<T>> GreaterThan(IComparable expected);
		IAndConstraints<IComparableConstraints<T>> LessThan(IComparable expected);
		IAndConstraints<IComparableConstraints<T>> GreaterThanOrEqualTo(IComparable expected);
		IAndConstraints<IComparableConstraints<T>> LessThanOrEqualTo(IComparable expected);
        IAndConstraints<IComparableConstraints<T>> IncludedIn<TP>(TP lowLimit, TP highLimit) where TP : IComparable<TP>;
	}
}