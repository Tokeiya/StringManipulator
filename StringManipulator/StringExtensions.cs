using System;
using System.Collections.Generic;
using System.Text;

namespace Tokeiya3.StringManipulator
{
	public static class StringBuiderExtensions
	{
		/// <summary>
		/// Create a StringBuilder from a string.
		/// </summary>
		/// <param name="source">A string to create a StringBuilder from.</param>
		/// <returns>A StringBuilder created from the specified source.</returns>
		public static StringBuilder ToStringBuilder(this string source) => new StringBuilder(source);


		/// <summary>
		/// Create a StringBuilder from an IEnumerable
		/// </summary>
		/// <param name="source">An IEnumerable to create a StringBuilder from.</param>
		/// <returns>A StringBuilder that contain the elements from the input sequence.</returns>
		public static StringBuilder ToStringBuilder(this IEnumerable<char> source) =>
			new StringBuilder().Append(source);

		/// <summary>
		/// Create a StringBuilder from an ReadOnlySpan
		/// </summary>
		/// <param name="source">A ReadOnlySpan to create a StringBuilder from.</param>
		/// <returns>A StringBuilder that contain the elements from the input ReadOnlySpan.</returns>
		public static StringBuilder ToStringBuilder(this ReadOnlySpan<char> source) =>
			new StringBuilder().Append(source);


		/// <summary>
		/// Create a StringBuilder from a ReadOnlyMemory.
		/// </summary>
		/// <param name="source">A ReadOnlyMemory to create a StringBuilder from.</param>
		/// <returns>A StringBuilder that contain the elements from the input ReadOnlyMemory.</returns>
		public static StringBuilder ToStringBuilder(this ReadOnlyMemory<char> source) =>
			new StringBuilder().Append(source);


		/// <summary>
		/// Concatenates the string of the provided ReadonlyMemory, using the specified separator between each string.
		/// Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">An ReadonlyMemory that contains the string.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A StringBuider that contain the concatenated the specified strings with specified separator.</returns>
		public static StringBuilder ToStringBuilder(this ReadOnlyMemory<string> source, char separator)
		{
			var ret = new StringBuilder();

			foreach (var elem in source.Span)
			{
				ret.Append(elem).Append(separator);
			}

			return ret.Extract(..^1);
		}


		/// <summary>
		/// Concatenates the string of the provided ReadonlyMemory, using the specified separator between each string.
		/// Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">An ReadonlyMemory that contains the string.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A StringBuider that contain the concatenated the specified strings with specified separator.</returns>

		public static StringBuilder ToStringBuilder(this ReadOnlyMemory<string> source, string separator) =>
			new StringBuilder().AppendJoin(separator, source);


		/// <summary>
		/// Concatenates the string of the provided ReadOnlySpan, using the specified separator between each string.
		/// Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">An ReadonlySpan that contains the string.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A StringBuider that contain the concatenated the specified strings with specified separator.</returns>

		public static StringBuilder ToStringBuilder(this ReadOnlySpan<string> source, char separator)
		{
			var ret = new StringBuilder();

			foreach (var s in source)
			{
				ret.Append(s).Append(separator);
			}

			return ret.Extract(..^1);
		}


		/// <summary>
		/// Concatenates the string of the provided ReadonlySpan, using the specified separator between each string.
		/// Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">An ReadonlyMemory that contains the string.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A StringBuider that contain the concatenated the specified strings with specified separator.</returns>

		public static StringBuilder ToStringBuilder(this ReadOnlySpan<string> source, string separator)
		{
			var ret = new StringBuilder();

			foreach (var elem in separator)
			{
				ret.Append(elem).Append(separator);
			}

			return ret.Extract(..^1);
		}


		/// <summary>
		/// Concatenates the string of the provided Sequence, using the specified separator between each string.
		/// Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">An object sequence for concatenates.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A StringBuider that contain the concatenated the specified object's string expression with specified separator.</returns>
		public static StringBuilder ToStringBuilder<T>(this IEnumerable<T> source, char separator) =>
			new StringBuilder().AppendJoin(separator, source);

		/// <summary>
		/// Concatenates the string of the provided Sequence, using the specified separator between each string.
		/// Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">An object sequence for concatenates.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A StringBuider that contain the concatenated the specified object's string expression with specified separator.</returns>
		public static StringBuilder ToStringBuilder<T>(this IEnumerable<T> source, string separator) =>
			new StringBuilder().AppendJoin(separator, source);


		/// <summary>
		/// Concatenates the string of the provided squence of the char sequence, using the specified separator between each string.
		/// Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">A sequence of the character sequence for concatenates.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A StringBuilder that contain the concatenated the specified character sequence with specified separator.</returns>
		public static StringBuilder ToStringBuilder(this IEnumerable<IEnumerable<char>> source, char separator)
		{
			var ret = new StringBuilder();

			foreach (var elem in source)
			{
				foreach (var c in elem)
				{
					ret.Append(c);
				}

				ret.Append(separator);
			}

			return ret.Extract(..^1);
		}

		/// <summary>
		/// Concatenates the string of the provided squence of the char sequence, using the specified separator between each string.
		/// Then create the StringBuilder from it.
		/// </summary>
		/// <param name="source">A sequence of the character sequence for concatenates.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A StringBuilder that contain the concatenated the specified character sequence with specified separator.</returns>
		public static StringBuilder ToStringBuilder(this IEnumerable<IEnumerable<char>> source, string separator)
		{
			var ret = new StringBuilder();

			foreach (var elem in source)
			{
				foreach (var c in elem)
				{
					ret.Append(c);
				}

				ret.Append(separator);
			}

			return ret.Extract(..^1);
		}

		/// <summary>
		/// Concatenates the string of the provided string sequence, using the specified separator between each string.
		/// Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <param name="source">A string sequence for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilder(this IEnumerable<string> source, StringBuilder stringBuilder,
			char separator) => stringBuilder.AppendJoin(separator, source);

		/// <summary>
		/// Concatenates the string of the provided string sequence, using the specified separator between each string.
		/// Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <param name="source">A string sequence for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilder(this IEnumerable<string> source, StringBuilder stringBuilder,
			string separator) => stringBuilder.AppendJoin(separator, source);

		/// <summary>
		/// Concatenates the string of the provided string ReadOnlySpan, using the specified separator between each string.
		/// Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <param name="source">A string ReadOnlySpan for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilder(this ReadOnlySpan<string> source, StringBuilder stringBuilder,
			char separator)
		{
#warning AppendToStringBuilder_Is_NotImpl
			throw new NotImplementedException("AppendToStringBuilder is not implemented");
		}


		/// <summary>
		/// Concatenates the string of the provided string ReadOnlySpan, using the specified separator between each string.
		/// Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <param name="source">A string ReadOnlySpan for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilder(this ReadOnlySpan<string> source, StringBuilder stringBuilder,
			string separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");

		}


		/// <summary>
		/// Concatenates the string of the provided string ReadOnlyMemory, using the specified separator between each string.
		/// Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <param name="source">A string ReadOnlyMemory for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilder(this ReadOnlyMemory<string> source,
			StringBuilder stringBuilder, char separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

		/// <summary>
		/// Concatenates the string of the provided string ReadOnlyMemory, using the specified separator between each string.
		/// Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <param name="source">A string ReadOnlyMemory for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilder(this ReadOnlyMemory<string> source,
			StringBuilder stringBuilder, string separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

		/// <summary>
		/// Concatenates the string of the provided a sequence of character sequences, using the specified separator between each string.
		/// Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <param name="source">A sequence of character sequences</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>		
		public static StringBuilder AppendToStringBuilder(this IEnumerable<IEnumerable<char>> source,
		StringBuilder stringBuilder, char separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}


		/// <summary>
		/// Concatenates the string of the provided a sequence of character sequences, using the specified separator between each string.
		/// Then appends the result to the designated instance of the StringBuilder.
		/// </summary>
		/// <param name="source">A sequence of character sequences</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>		
		public static StringBuilder AppendToStringBuilder(this IEnumerable<IEnumerable<char>> source,
			StringBuilder stringBuilder, string separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

		/// <summary>
		/// Concatenates the string of the provided string sequence, using the specified separator between each string.
		/// Then appends the result  and default line terminator to the specified StringBuilder.
		/// </summary>
		/// <param name="source">A string sequence for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine(this IEnumerable<string> source,
			StringBuilder stringBuilder, char separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

		/// <summary>
		/// Concatenates the string of the provided string sequence, using the specified separator between each string.
		/// Then appends the result  and default line terminator to the specified StringBuilder.
		/// </summary>
		/// <param name="source">A string sequence for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine(this IEnumerable<string> source,
			StringBuilder stringBuilder, string separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

		/// <summary>
		/// Concatenates the string of the provided string ReadOnlySpan, using the specified separator between each string.
		/// Then appends the result  and default line terminator to the specified StringBuilder.
		/// </summary>
		/// <param name="source">A string ReadOnlySpan for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine(this ReadOnlySpan<string> source,
			StringBuilder stringBuilder, char separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

		/// <summary>
		/// Concatenates the string of the provided string ReadOnlySpan, using the specified separator between each string.
		/// Then appends the result  and default line terminator to the specified StringBuilder.
		/// </summary>
		/// <param name="source">A string ReadOnlySpan for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine(this ReadOnlySpan<string> source,
			StringBuilder stringBuilder, string separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");

		}

		/// <summary>
		/// Concatenates the string of the provided string ReadOnlyMemory, using the specified separator between each string.
		/// Then appends the result  and default line terminator to the specified StringBuilder.
		/// </summary>
		/// <param name="source">A string ReadOnlyMemory for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine(this ReadOnlyMemory<string> source,
			StringBuilder stringBuilder, char separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

		/// <summary>
		/// Concatenates the string of the provided string ReadOnlyMemory, using the specified separator between each string.
		/// Then appends the result  and default line terminator to the specified StringBuilder.
		/// </summary>
		/// <param name="source">A string ReadOnlyMemory for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine(this ReadOnlyMemory<string> source,
			StringBuilder stringBuilder, string separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

		/// <summary>
		/// Concatenates the string of the provided character sequence, using the specified separator between each string.
		/// Then appends the result  and default line terminator to the specified StringBuilder.
		/// </summary>
		/// <param name="source">A string character sequence for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine(this IEnumerable<IEnumerable<char>> source,
			StringBuilder stringBuilder, char separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

		/// <summary>
		/// Concatenates the string of the provided character sequence, using the specified separator between each string.
		/// Then appends the result  and default line terminator to the specified StringBuilder.
		/// </summary>
		/// <param name="source">A string character sequence for concatenates.</param>
		/// <param name="stringBuilder">A StringBuilder to be appended.</param>
		/// <param name="separator">Specify the separator.</param>
		/// <returns>A reference to the designated instance after the append operation has completed.</returns>
		public static StringBuilder AppendToStringBuilderAsLine(this IEnumerable<IEnumerable<char>> source,
			StringBuilder stringBuilder, string separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

		public static StringBuilder Extract(this StringBuilder stringBuilder, Range range)
		{
			static uint calculate(Index idx, int length) =>
				idx.IsFromEnd ? (uint) (length - idx.Value) : (uint) idx.Value;

			var start = calculate(range.Start, stringBuilder.Length);
			if (start > stringBuilder.Length) throw new ArgumentOutOfRangeException(nameof(range));

			var end = calculate(range.End, stringBuilder.Length);
			if (end > stringBuilder.Length) throw new ArgumentOutOfRangeException(nameof(range));

			if (end - start > stringBuilder.Length) throw new ArgumentOutOfRangeException(nameof(range));

			stringBuilder.Remove(0, (int) start);

			end = calculate(range.End, stringBuilder.Length);
			stringBuilder.Remove((int) end, (int) (stringBuilder.Length - end));

			return stringBuilder;



		}

	}
}
