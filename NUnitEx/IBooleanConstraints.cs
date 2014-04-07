namespace NUnit.Framework
{
	/// <summary>
	/// Constraint over boolean values.
	/// </summary>
	public interface IBooleanConstraints : IBeConstraints<IBooleanBeConstraints> {}

	public interface IBooleanBeConstraints : IConstraints<bool>
	{
		void True();
		void False();
	}
}