using System;
using System.Text;
using ChainingAssertion;
using Xunit;

namespace Tokeiya3.StringManipulatorTests
{
	internal static class TestExtensions
	{
		public static void Is(this StringBuilder actual, ReadOnlySpan<char> expected)
		{
			Assert.True(expected.Length == actual.Length, $"act:{actual} expected:{new string(expected)}");
			Assert.Equal(expected.Length, actual.Length);
			actual.Length.Is(expected.Length, actual.ToString());

			for (int i = 0; i < expected.Length; i++) actual[i].Is(expected[i]);
		}

		public static void Is(this StringBuilder actual, string expected, string delimiter, string separator)
		{
			var tmp = expected.Replace(delimiter, separator);
			Assert.True(actual.Length==tmp.Length,$"act:{actual}\nexp:{expected}");

			for (int i = 0; i < expected.Length; i++)
			{
				actual[i].Is(tmp[i]);
			}
		}

		public static void Is(this StringBuilder actual, string expected, string delimiter, char separator)
			=> actual.Is(expected, delimiter, separator.ToString());

		public static void Is(this StringBuilder actual, string pre, string expected, string delimiter,
			string separator)
		{
			var tmp = pre + expected.Replace(delimiter, separator);
			actual.Length.Is(tmp.Length);

			for (int i = 0; i < expected.Length; i++)
			{
				actual[i].Is(tmp[i]);
			}
		}

		public static void Is(this StringBuilder actual, string pre, string expected, string delimiter, char separator) =>
			actual.Is(pre, expected, delimiter, separator.ToString());

	}
}