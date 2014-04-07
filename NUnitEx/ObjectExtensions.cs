using System;
using System.Reflection;

namespace NUnit.Framework
{
	/// <summary>
	/// Extensions for any System.Object.
	/// </summary>
	public static class ObjectExtensions
	{
		private const BindingFlags DefaultFlags =
			BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;

		private const string FieldNameMessageTemplate = "The class {0} does not contain a field named {1}.";

		private const string InvalidCastMessageTemplate =
			"The class {0} does contain a field named {1} but its type is {2} and not {3}.";

		/// <summary>
		/// Allow access to a private field of a class instance.
		/// </summary>
		/// <typeparam name="T">The <see cref="Type"/> of the field. </typeparam>
		/// <param name="source">The class instance.</param>
		/// <param name="fieldName">The field name.</param>
		/// <returns>The value of the field.</returns>
		public static T FieldValue<T>(this object source, string fieldName)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source", "Can't access to a field of a null value.");
			}
			Type sourceType = source.GetType();
			FieldInfo fieldInfo = sourceType.GetField(fieldName, DefaultFlags);
			if (ReferenceEquals(null, fieldInfo))
			{
				throw new ArgumentOutOfRangeException("fieldName",
				                                      string.Format(FieldNameMessageTemplate, sourceType.FullName, fieldName));
			}
			if (fieldInfo.FieldType != typeof (T))
			{
				throw new InvalidCastException(string.Format(InvalidCastMessageTemplate, sourceType.FullName, fieldName,
				                                             fieldInfo.FieldType.FullName, typeof (T).FullName));
			}

			return (T) fieldInfo.GetValue(source);
		}
	}
}