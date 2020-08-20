using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tokeiya3.StringManipulator
{
	public static partial class StringBuilderExtensions
	{
		/// <summary>
		///     Concatenates the string of the provided string array,
		///     using the specified separator between each string.
		///     Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <param name="source">A string array for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilder(this string[] source, StringBuilder stringBuilder,
			char separator) => stringBuilder.AppendJoin(separator, source);

		/// <summary>
		///     Concatenates the string of the provided string array,
		///     using the specified separator between each string.
		///     Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <param name="source">A string array for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilder(this string[] source, StringBuilder stringBuilder,
			string separator) => stringBuilder.AppendJoin(separator, source);


		/// <summary>
		///     Concatenates the string of the provided object array,
		///     using the specified separator between each string.
		///     Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <param name="source">A object array for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilder(this object[] source, StringBuilder stringBuilder,
			char separator) => stringBuilder.AppendJoin(separator, source);


		/// <summary>
		///     Concatenates the string of the provided object array,
		///     using the specified separator between each string.
		///     Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <param name="source">A object array for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilder(this object[] source, StringBuilder stringBuilder,
			string separator) => stringBuilder.AppendJoin(separator, source);


		/// <summary>
		///     Concatenates the string of the provided string ReadOnlySpan,
		///     using the specified separator between each string.
		///     Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <param name="source">A string ReadOnlySpan for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilder(this ReadOnlySpan<string> source, StringBuilder stringBuilder,
			char separator)
		{
			if (source.IsEmpty) return stringBuilder;

			foreach (var elem in source) stringBuilder.Append(elem).Append(separator);

			return stringBuilder.Extract(..^1);
		}


		/// <summary>
		///     Concatenates the string of the provided string ReadOnlySpan,
		///     using the specified separator between each string.
		///     Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <param name="source">A string ReadOnlySpan for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilder(this ReadOnlySpan<string> source, StringBuilder stringBuilder,
			string separator)
		{
			if (source.IsEmpty) return stringBuilder;

			foreach (var elem in source) stringBuilder.Append(elem).Append(separator);

			return stringBuilder.Extract(..^separator.Length);
		}


		/// <summary>
		///     Concatenates the string of the provided string ReadOnlyMemory,
		///     using the specified separator between each string.
		///     Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <param name="source">A string ReadOnlyMemory for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilder(this ReadOnlyMemory<string> source,
			StringBuilder stringBuilder, char separator)
		{
			if (source.IsEmpty) return stringBuilder;

			foreach (var elem in source.Span) stringBuilder.Append(elem).Append(separator);

			return stringBuilder.Extract(..^1);
		}

		/// <summary>
		///     Concatenates the string of the provided string ReadOnlyMemory,
		///     using the specified separator between each string.
		///     Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <param name="source">A string ReadOnlyMemory for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilder(this ReadOnlyMemory<string> source,
			StringBuilder stringBuilder, string separator)
		{
			if (source.IsEmpty) return stringBuilder;

			foreach (var elem in source.Span) stringBuilder.Append(elem).Append(separator);

			return stringBuilder.Extract(..^separator.Length);
		}

		/// <summary>
		///     Concatenates the string of the provided a sequence of character sequences,
		///     using the specified separator between each string.
		///     Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <param name="source">A sequence of character sequences</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilder(this IEnumerable<IEnumerable<char>> source,
			StringBuilder stringBuilder, char separator)
		{

			// ReSharper disable once PossibleMultipleEnumeration
			if (!source.Any()) return stringBuilder;

			// ReSharper disable once PossibleMultipleEnumeration
			foreach (var elem in source)
			{
				foreach (var c in elem) stringBuilder.Append(c);

				stringBuilder.Append(separator);
			}

			return stringBuilder.Extract(..^1);
		}


		/// <summary>
		///     Concatenates the string of the provided a sequence of character sequences,
		///     using the specified separator between each string.
		///     Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <param name="source">A sequence of character sequences</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilder(this IEnumerable<IEnumerable<char>> source,
			StringBuilder stringBuilder, string separator)
		{
			// ReSharper disable once PossibleMultipleEnumeration
			if (!source.Any()) return stringBuilder;

			// ReSharper disable once PossibleMultipleEnumeration
			foreach (var elem in source)
			{
				foreach (var c in elem) stringBuilder.Append(c);

				stringBuilder.Append(separator);
			}

			return stringBuilder.Extract(..^separator.Length);
		}


		/// <summary>
		///     Concatenates the string representation of an specified objects,
		///     using the specified separator between each string.
		///     Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <typeparam name="T">A object type.</typeparam>
		/// <param name="source">A sequence of object</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilder<T>(this IEnumerable<T> source, StringBuilder stringBuilder,
			char separator) => stringBuilder.AppendJoin(separator, source);

		/// <summary>
		///     Concatenates the string representation of an specified objects,
		///     using the specified separator between each string.
		///     Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <typeparam name="T">A object type.</typeparam>
		/// <param name="source">A sequence of object</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilder<T>(this IEnumerable<T> source, StringBuilder stringBuilder,
			string separator) => stringBuilder.AppendJoin(separator, source);


		/// <summary>
		///     Concatenates the string of the provided string array, using the specified separator between each string.
		///     Then appends the result and finally default line terminator to the designated StringBuilder.
		/// </summary>
		/// <param name="source">A string array for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine(this string[] source, StringBuilder stringBuilder,
			char separator) => source.AppendToStringBuilder(stringBuilder, separator).AppendLine();


		/// <summary>
		///     Concatenates the string of the provided string array, using the specified separator between each string.
		///     Then appends the result and finally default line terminator to the designated StringBuilder.
		/// </summary>
		/// <param name="source">A string array for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine(this string[] source, StringBuilder stringBuilder,
			string separator) => source.AppendToStringBuilder(stringBuilder, separator).AppendLine();

		/// <summary>
		///     Concatenates the string of the provided object array, using the specified separator between each string.
		///     Then appends the result and finally default line terminator to the designated StringBuilder.
		/// </summary>
		/// <param name="source">A object array for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine(this object[] source, StringBuilder stringBuilder,
			char separator) => source.AppendToStringBuilder(stringBuilder, separator).AppendLine();

		/// <summary>
		///     Concatenates the string of the provided object array, using the specified separator between each string.
		///     Then appends the result and finally default line terminator to the designated StringBuilder.
		/// </summary>
		/// <param name="source">A object array for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine(this object[] source, StringBuilder stringBuilder,
			string separator) => source.AppendToStringBuilder(stringBuilder, separator).AppendLine();


		/// <summary>
		///     Concatenates the string of the provided string ReadOnlySpan,
		///     using the specified separator between each string.
		///     Then appends the result and finally default line terminator to the designated StringBuilder.
		/// </summary>
		/// <param name="source">A string ReadOnlySpan for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine(this ReadOnlySpan<string> source,
			StringBuilder stringBuilder, char separator) =>
			source.AppendToStringBuilder(stringBuilder, separator).AppendLine();

		/// <summary>
		///     Concatenates the string of the provided string ReadOnlySpan,
		///     using the specified separator between each string.
		///     Then appends the result and finally default line terminator to the designated StringBuilder.
		/// </summary>
		/// <param name="source">A string ReadOnlySpan for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine(this ReadOnlySpan<string> source,
			StringBuilder stringBuilder, string separator) =>
			source.AppendToStringBuilder(stringBuilder, separator).AppendLine();

		/// <summary>
		///     Concatenates the string of the provided string ReadOnlyMemory,
		///     using the specified separator between each string.
		///     Then appends the result and finally default line terminator to the designated StringBuilder.
		/// </summary>
		/// <param name="source">A string ReadOnlyMemory for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine(this ReadOnlyMemory<string> source,
			StringBuilder stringBuilder, char separator) =>
			source.AppendToStringBuilder(stringBuilder, separator).AppendLine();

		/// <summary>
		///     Concatenates the string of the provided string ReadOnlyMemory,
		///     using the specified separator between each string.
		///     Then appends the result and finally default line terminator to the designated StringBuilder.
		/// </summary>
		/// <param name="source">A string ReadOnlyMemory for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine(this ReadOnlyMemory<string> source,
			StringBuilder stringBuilder, string separator) =>
			source.AppendToStringBuilder(stringBuilder, separator).AppendLine();

		/// <summary>
		///     Concatenates the string of the provided character sequence,
		///     using the specified separator between each string.
		///     Then appends the result and finally default line terminator to the designated StringBuilder.
		/// </summary>
		/// <param name="source">A string character sequence for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine(this IEnumerable<IEnumerable<char>> source,
			StringBuilder stringBuilder, char separator) =>
			source.AppendToStringBuilder(stringBuilder, separator).AppendLine();

		/// <summary>
		///     Concatenates the string of the provided character sequence,
		///     using the specified separator between each string.
		///     Then appends the result and finally default line terminator to the designated StringBuilder.
		/// </summary>
		/// <param name="source">A string character sequence for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine(this IEnumerable<IEnumerable<char>> source,
			StringBuilder stringBuilder, string separator) =>
			source.AppendToStringBuilder(stringBuilder, separator).AppendLine();


		/// <summary>
		///     Concatenates the string representation of an specified objects,
		///     using the specified separator between each string.
		///     Then appends the result and finally default line terminator to the designated StringBuilder.
		/// </summary>
		/// <typeparam name="T">A object type.</typeparam>
		/// <param name="source">A sequence of object</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine<T>(this IEnumerable<T> source,
			StringBuilder stringBuilder, char separator) =>
			source.AppendToStringBuilder(stringBuilder, separator).AppendLine();

		/// <summary>
		///     Concatenates the string representation of an specified objects,
		///     using the specified separator between each string.
		///     Then appends the result and finally default line terminator to the designated StringBuilder.
		/// </summary>
		/// <typeparam name="T">A object type.</typeparam>
		/// <param name="source">A sequence of object</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine<T>(this IEnumerable<T> source,
			StringBuilder stringBuilder, string separator) =>
			source.AppendToStringBuilder(stringBuilder, separator).AppendLine();


		/// <summary>
		///     Extracts the StringBuilder according to the specified range.
		/// </summary>
		/// <param name="stringBuilder">A StringBuilder that extract the contents.</param>
		/// <param name="range">Specify the extract range.</param>
		/// <returns>A reference to the StringBuilder instance after the extracted operation has completed.</returns>
		public static StringBuilder Extract(this StringBuilder stringBuilder, Range range)
		{
			static uint calculate(Index idx, int length) =>
				idx.IsFromEnd ? (uint) (length - idx.Value) : (uint) idx.Value;

			var start = calculate(range.Start, stringBuilder.Length);
			if (start > stringBuilder.Length) throw new ArgumentOutOfRangeException(nameof(range));

			var end = calculate(range.End, stringBuilder.Length)-start;
			if (end > stringBuilder.Length) throw new ArgumentOutOfRangeException(nameof(range));

			stringBuilder.Remove(0, (int) start);
			stringBuilder.Remove((int) end, (int) (stringBuilder.Length - end));

			return stringBuilder;
		}
	}
}