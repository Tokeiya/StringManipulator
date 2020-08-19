using System;
using System.Collections.Generic;
using System.Text;

namespace Tokeiya3.StringManipulator
{
	public static partial class StringBuilderExtensions
	{
		/// <summary>
		///     Create a StringBuilder from a string.
		/// </summary>
		/// <param name="source">A string to create a StringBuilder from.</param>
		/// <returns>A StringBuilder created from the specified source.</returns>
		public static StringBuilder ToStringBuilder(this string source) => new StringBuilder(source);

		/// <summary>
		///     Create a StringBuilder from an IEnumerable
		/// </summary>
		/// <param name="source">An IEnumerable to create a StringBuilder from.</param>
		/// <returns>A StringBuilder that contain the elements from the input sequence.</returns>
		public static StringBuilder ToStringBuilder(this IEnumerable<char> source)
		{
			var ret = new StringBuilder();

			foreach (var c in source)
			{
				ret.Append(c);
			}

			return ret;
		}

		/// <summary>
		///     Create a StringBuilder from an ReadOnlySpan
		/// </summary>
		/// <param name="source">A ReadOnlySpan to create a StringBuilder from.</param>
		/// <returns>A StringBuilder that contain the elements from the input ReadOnlySpan.</returns>
		public static StringBuilder ToStringBuilder(this ReadOnlySpan<char> source) =>
			new StringBuilder().Append(source);

		/// <summary>
		///     Create a StringBuilder from a ReadOnlyMemory.
		/// </summary>
		/// <param name="source">A ReadOnlyMemory to create a StringBuilder from.</param>
		/// <returns>A StringBuilder that contain the elements from the input ReadOnlyMemory.</returns>
		public static StringBuilder ToStringBuilder(this ReadOnlyMemory<char> source) =>
			new StringBuilder().Append(source);

		/// <summary>
		///     Concatenates the string of the provided object array,
		///     using the specified separator between each string.
		///     Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">An object array that contains the string.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A StringBuilder that contain the concatenated the specified strings with specified separator.</returns>
		public static StringBuilder ToStringBuilder(this object[] source, char separator)
			=> source.AppendToStringBuilder(new StringBuilder(), separator);

		/// <summary>
		///     Concatenates the string of the provided object array,
		///     using the specified separator between each string.
		///     Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">An object array that contains the string.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A StringBuilder that contain the concatenated the specified strings with specified separator.</returns>
		public static StringBuilder ToStringBuilder(this object[] source, string separator)
			=> source.AppendToStringBuilder(new StringBuilder(), separator);

		/// <summary>
		///     Concatenates the string of the provided string array,
		///     using the specified separator between each string.
		///     Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">An string array that contains the string.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A StringBuilder that contain the concatenated the specified strings with specified separator.</returns>
		public static StringBuilder ToStringBuilder(this string[] source, char separator) =>
			source.AppendToStringBuilder(new StringBuilder(), separator);

		/// <summary>
		///     Concatenates the string of the provided string array,
		///     using the specified separator between each string.
		///     Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">An string array that contains the string.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A StringBuilder that contain the concatenated the specified strings with specified separator.</returns>
		public static StringBuilder ToStringBuilder(this string[] source, string separator) =>
			source.AppendToStringBuilder(new StringBuilder(), separator);

		/// <summary>
		///     Concatenates the string of the provided ReadonlyMemory,
		///     using the specified separator between each string.
		///     Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">An ReadonlyMemory that contains the string.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A StringBuilder that contain the concatenated the specified strings with specified separator.</returns>
		public static StringBuilder ToStringBuilder(this ReadOnlyMemory<string> source, char separator) =>
			source.AppendToStringBuilder(new StringBuilder(), separator);

		/// <summary>
		///     Concatenates the string of the provided ReadonlyMemory,
		///     using the specified separator between each string.
		///     Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">An ReadonlyMemory that contains the string.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A StringBuider that contain the concatenated the specified strings with specified separator.</returns>
		public static StringBuilder ToStringBuilder(this ReadOnlyMemory<string> source, string separator) =>
			source.AppendToStringBuilder(new StringBuilder(), separator);

		/// <summary>
		///     Concatenates the string of the provided ReadOnlySpan,
		///     using the specified separator between each string.
		///     Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">An ReadonlySpan that contains the string.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A StringBuilder that contain the concatenated the specified strings with specified separator.</returns>
		public static StringBuilder ToStringBuilder(this ReadOnlySpan<string> source, char separator) =>
			source.AppendToStringBuilder(new StringBuilder(), separator);

		/// <summary>
		///     Concatenates the string of the provided ReadonlySpan,
		///     using the specified separator between each string.
		///     Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">An ReadonlyMemory that contains the string.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A StringBuilder that contain the concatenated the specified strings with specified separator.</returns>
		public static StringBuilder ToStringBuilder(this ReadOnlySpan<string> source, string separator) =>
			source.AppendToStringBuilder(new StringBuilder(), separator);

		/// <summary>
		///     Concatenates the string of the provided Sequence,
		///     using the specified separator between each string.
		///     Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">An object sequence for concatenates.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>
		///     A StringBuilder that contain the concatenated the specified object's string expression with specified
		///     separator.
		/// </returns>
		public static StringBuilder ToStringBuilder<T>(this IEnumerable<T> source, char separator) =>
			source.AppendToStringBuilder(new StringBuilder(), separator);

		/// <summary>
		///     Concatenates the string of the provided Sequence,
		///     using the specified separator between each string.
		///     Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">An object sequence for concatenates.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>
		///     A StringBuilder that contain the concatenated the specified object's string expression with specified
		///     separator.
		/// </returns>
		public static StringBuilder ToStringBuilder<T>(this IEnumerable<T> source, string separator) =>
			source.AppendToStringBuilder(new StringBuilder(), separator);

		/// <summary>
		///     Concatenates the string of the provided sequence of the char sequence,
		///     using the specified separator between each
		///     string.
		///     Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">A sequence of the character sequence for concatenates.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A StringBuilder that contain the concatenated the specified character sequence with specified separator.</returns>
		public static StringBuilder ToStringBuilder(this IEnumerable<IEnumerable<char>> source, char separator)
			=> source.AppendToStringBuilder(new StringBuilder(), separator);

		/// <summary>
		///     Concatenates the string of the provided sequence of the char sequence,
		///     using the specified separator between each string.
		///     Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">A sequence of the character sequence for concatenates.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A StringBuilder that contain the concatenated the specified character sequence with specified separator.</returns>
		public static StringBuilder ToStringBuilder(this IEnumerable<IEnumerable<char>> source, string separator)
			=> source.AppendToStringBuilder(new StringBuilder(), separator);
	}
}