using System;
using System.Collections.Generic;
using System.Text;
using ChainingAssertion;

namespace Tokeiya3.StringManipulatorTests
{
	static class TestExtensions
	{
		public static void Is(this StringBuilder actual, ReadOnlySpan<char> expected)
		{
			actual.Length.Is(expected.Length);

			for (int i = 0; i < expected.Length; i++)
			{
				actual[i].Is(expected[i]);
			}
		}
	}
}
