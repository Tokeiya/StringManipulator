using System;
using System.Collections.Generic;
using System.Text;

namespace Tokeiya3.StringManipulator
{
	public static class StringExtensions
	{

		public static StringBuilder ToStringBuilder(this string source) => new StringBuilder(source);

		public static StringBuilder ToStringBuilder(this IEnumerable<char> source) =>
			new StringBuilder().Append(source);

		public static StringBuilder ToStringBuilder(this ReadOnlySpan<char> source) =>
			new StringBuilder().Append(source);

		public static StringBuilder ToStringBuilder(this ReadOnlyMemory<char> source) =>
			new StringBuilder().Append(source);

		public static StringBuilder ToStringBuilder(this ReadOnlyMemory<string> source, char separator)
		{
			var ret = new StringBuilder();

			foreach (var elem in source.Span)
			{
				ret.Append(elem).Append(separator);
			}

			return ret.Extract(..^1);
		}

		public static StringBuilder ToStringBuilder(this ReadOnlyMemory<string> source, string separator) =>
			new StringBuilder().AppendJoin(separator, source);

		public static StringBuilder ToStringBuilder(this ReadOnlySpan<string> source, char separator)
		{
			var ret = new StringBuilder();

			foreach (var s in source)
			{
				ret.Append(s).Append(separator);
			}

			return ret.Extract(..^1);
		}


		public static StringBuilder ToStringBuilder(this ReadOnlySpan<string> source, string separator)
		{
			var ret = new StringBuilder();

			foreach (var elem in separator)
			{
				ret.Append(elem).Append(separator);
			}

			return ret.Extract(..^1);
		}

		public static StringBuilder ToStringBuilder<T>(this IEnumerable<T> source, char separator) =>
			new StringBuilder().AppendJoin(separator, source);

		public static StringBuilder ToStringBuilder<T>(this IEnumerable<T> source, string separator) =>
			new StringBuilder().AppendJoin(separator, source);

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

		public static StringBuilder AppendToStringBuilder(this IEnumerable<string> source, StringBuilder stringBuilder,
			char separator) => stringBuilder.AppendJoin(separator, source);


		public static StringBuilder AppendToStringBuilder(this IEnumerable<string> source, StringBuilder stringBuilder,
			string separator) => stringBuilder.AppendJoin(separator, source);

		public static StringBuilder AppendToStringBuilder(this ReadOnlySpan<string> source, StringBuilder stringBuilder,
			char separator)
		{
#warning AppendToStringBuilder_Is_NotImpl
			throw new NotImplementedException("AppendToStringBuilder is not implemented");
		}

		public static StringBuilder AppendToStringBuilder(this ReadOnlySpan<string> source, StringBuilder stringBuilder,
			string separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");

		}

		public static StringBuilder AppendToStringBuilder(this ReadOnlyMemory<string> source,
			StringBuilder stringBuilder, char separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

		public static StringBuilder AppendToStringBuilder(this ReadOnlyMemory<string> source,
			StringBuilder stringBuilder, string separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

		public static StringBuilder AppendToStringBuilder(this IEnumerable<IEnumerable<char>> source,
			StringBuilder stringBuilder, char separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

		public static StringBuilder AppendToStringBuilder(this IEnumerable<IEnumerable<char>> source,
			StringBuilder stringBuilder, string separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

		public static StringBuilder AppendToStringBuilderAsLine(this IEnumerable<string> source,
			StringBuilder stringBuilder, char separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

		public static StringBuilder AppendToStringBuilderAsLine(this IEnumerable<string> source,
			StringBuilder stringBuilder, string separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

		public static StringBuilder AppendToStringBuilderAsLine(this ReadOnlySpan<string> source,
			StringBuilder stringBuilder, char separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

		public static StringBuilder AppendToStringBuilderAsLine(this ReadOnlySpan<string> source,
			StringBuilder stringBuilder, string separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");

		}

		public static StringBuilder AppendToStringBuilderAsLine(this ReadOnlyMemory<string> source,
			StringBuilder stringBuilder, char separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

		public static StringBuilder AppendToStringBuilderAsLine(this ReadOnlyMemory<string> source,
			StringBuilder stringBuilder, string separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

		public static StringBuilder AppendToStringBuilderAsLine(this IEnumerable<IEnumerable<char>> source,
			StringBuilder stringBuilder, char separator)
		{
#warning Append_Is_NotImpl
			throw new NotImplementedException("Append is not implemented");
		}

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
