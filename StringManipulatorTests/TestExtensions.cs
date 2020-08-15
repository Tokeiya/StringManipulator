using System;
using System.Collections.Generic;
using System.Text;
using ChainingAssertion;
using Xunit;

namespace Tokeiya3.StringManipulatorTests
{
	static class TestExtensions
	{
		public static void Is(this StringBuilder actual, ReadOnlySpan<char> expected)
		{
			Assert.True(expected.Length==actual.Length,$"act:{actual} expected:{new string(expected)}");
			Assert.Equal(expected.Length,actual.Length);
			actual.Length.Is(expected.Length,actual.ToString());

			for (int i = 0; i < expected.Length; i++)
			{
				actual[i].Is(expected[i]);
			}
		}
	}
}
