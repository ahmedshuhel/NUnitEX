using System;
using System.Linq;

namespace NUnit.Framework.ExtensionsImpl
{
	public class TypeConstraints : NegableConstraints<Type, ITypeConstraints>, ITypeConstraints
	{
		public TypeConstraints(Type actual) : base(actual) {}
		public TypeConstraints(Type actual, Func<string> messageBuilder) : base(actual, messageBuilder) {}

		#region Implementation of IBeConstraints<ITypeBeConstraints>

		public ITypeBeConstraints Be
		{
			get { return new TypeBeConstraints(this); }
		}

		#endregion

		#region Implementation of IHaveConstraints<ITypeHaveConstraints>

		public ITypeHaveConstraints Have
		{
			get { return new TypeHaveConstraints(this); }
		}

		#endregion

		#region Implementation of ICloneable

		public object Clone()
		{
			return new TypeConstraints(AssertionInfo.Actual, () => AssertionInfo.FailureMessage);
		}

		#endregion
	}

	public class TypeBeConstraints : ChildAndChainableConstraints<Type, ITypeConstraints>, ITypeBeConstraints
	{
		public TypeBeConstraints(ITypeConstraints parent) : base(parent) {}

		#region Implementation of ITypeBeConstraints

		public IAndConstraints<ITypeConstraints> Null()
		{
			AssertionInfo.AssertUsing(Is.Null);
			return AndChain;
		}

		public IAndConstraints<ITypeConstraints> EqualTo<T>()
		{
			return EqualTo(typeof (T));
		}

		public IAndConstraints<ITypeConstraints> EqualTo(Type expected)
		{
			AssertionInfo.AssertUsing(Is.EqualTo(expected));
			return AndChain;
		}

		public IAndConstraints<ITypeConstraints> AssignableFrom(Type expected)
		{
			AssertionInfo.AssertUsing(new DelegatedConstraint<Type>(expected, t => t.IsAssignableFrom(expected), "AssignableFrom"));
			return AndChain;
		}

		public IAndConstraints<ITypeConstraints> AssignableFrom<T>()
		{
			return AssignableFrom(typeof (T));
		}

		public IAndConstraints<ITypeConstraints> SubClassOf(Type expected)
		{
			AssertionInfo.AssertUsing(new DelegatedConstraint<Type>(expected, t => t.IsSubclassOf(expected), "SubclassOf"));
			return AndChain;
		}

		public IAndConstraints<ITypeConstraints> SubClassOf<T>()
		{
			return SubClassOf(typeof (T));
		}

		#endregion
	}

	public class TypeHaveConstraints : ChildAndChainableConstraints<Type, ITypeConstraints>, ITypeHaveConstraints
	{
		public TypeHaveConstraints(ITypeConstraints parent) : base(parent) {}

		#region Implementation of ITypeHaveConstraints

		public IAndConstraints<ITypeConstraints> Attribute<T>()
		{
			AssertionInfo.AssertUsing(new DelegatedConstraint<Type>(typeof (T),
			                                                        t =>
			                                                        t.GetCustomAttributes(true).Select(a => a.GetType()).Contains
			                                                        	(typeof (T)), "declare attribute"));
			return AndChain;
		}

		#endregion
	}
}