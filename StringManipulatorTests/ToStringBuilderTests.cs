using System;
using System.Linq;
using System.Text;
using Tokeiya3.StringManipulator;
using Xunit;

namespace Tokeiya3.StringManipulatorTests
{
	public class ToStringBuilderTests
	{
		private const string ExpectedString = "When seek the lazyness then arrive at diligence";


		[Fact]
		public void StringTest()
		{
			var actual = ExpectedString.ToStringBuilder();
			actual.Is(ExpectedString);

		}


		[Fact]
		// ReSharper disable once InconsistentNaming
		public void IEnumerableTest()
		{
			var source = ExpectedString.ToCharArray().Hide();
			var actual = source.ToStringBuilder();

			actual.Is(ExpectedString);
		}

		[Fact]
		public void ReadOnlySpanTest()
		{
			ReadOnlySpan<char> source = ExpectedString;
			var actual = source.ToStringBuilder();

			actual.Is(ExpectedString);

		}

		[Fact]
		public void ReadOnlyMemoryTest()
		{
			ReadOnlyMemory<char> source = ExpectedString.ToCharArray();
			var actual = source.ToStringBuilder();

			actual.Is(ExpectedString);

		}


		[Fact]
		public void StringArrayTest()
		{
			var source = ExpectedString.Split(' ');
			var actual = source.ToStringBuilder('\t');
			actual.Is(ExpectedString, " ", "\t");

			actual = source.ToStringBuilder("ばらし");
			actual.Is(ExpectedString, " ", "ばらし");
		}


		[Fact]
		public void ObjectArrayTest()
		{
			var source = new object[] { 'a', "テキスト", 42 };
			var actual = source.ToStringBuilder('\t');
			actual.Is(string.Join('\t', source));

			actual = source.ToStringBuilder("ばらし");
			actual.Is(string.Join("ばらし", source));
		}

		[Fact]
		public void ReadonlyMemoryTest()
		{
			ReadOnlyMemory<string> source = ExpectedString.Split(' ');

			var actual = source.ToStringBuilder('\t');
			actual.Is(ExpectedString, " ", "\t");

			actual = source.ToStringBuilder("ばらし");
			actual.Is(ExpectedString, " ", "ばらし");
		}

		[Fact]
		public void ReadonlySpanTest()
		{
			ReadOnlySpan<string> source = ExpectedString.Split(' ');

			var actual = source.ToStringBuilder('\t');
			actual.Is(ExpectedString, " ", "\t");

			actual = source.ToStringBuilder("ばらし");
			actual.Is(ExpectedString, " ", "ばらし");
		}

		[Fact]
		public void GenericIEnumerableTest()
		{
			// ReSharper disable PossibleMultipleEnumeration

			var source = Enumerable.Range(0, 42);
			var actual = source.ToStringBuilder('\t');

			actual.Is(string.Join('\t', source));

			actual = source.ToStringBuilder("ばらし");
			actual.Is(string.Join("ばらし", source));
			// ReSharper restore PossibleMultipleEnumeration

		}

		[Fact]
		// ReSharper disable once InconsistentNaming
		public void IEnumerableIEnumerableCharTest()
		{
			// ReSharper disable PossibleMultipleEnumeration

			var source = ExpectedString.Split(' ').Select(s => s.ToCharArray().Hide());
			var actual = source.ToStringBuilder('\t');
			actual.Is(ExpectedString, " ", "\t");

			actual = source.ToStringBuilder("ばらし");
			actual.Is(ExpectedString, " ", "ばらし");

			// ReSharper restore PossibleMultipleEnumeration


		}







		[Fact]
		public void ExtractTest()
		{
			var bld = new StringBuilder();

			StringBuilder reset()
			{
				return bld.Clear().Append("0123456789");
			}

			reset().Extract(1..).Is("123456789");
			reset().Extract(..^1).Is("012345678");

			reset().Extract(..).Is("0123456789");
			reset().Extract(^3..).Is("789");

			reset().Extract(1..^1).Is("12345678");
			reset().Extract(..^10).Is("");
			reset().Extract(10..).Is("");

			Assert.Throws<ArgumentOutOfRangeException>(() => reset().Extract(-1..));
			Assert.Throws<ArgumentOutOfRangeException>(() => reset().Extract(..-1));
			Assert.Throws<ArgumentOutOfRangeException>(() => reset().Extract(..^11));
			Assert.Throws<ArgumentOutOfRangeException>(() => reset().Extract(1..^10));
			Assert.Throws<ArgumentOutOfRangeException>(() => reset().Extract(11..));
		}
	}
}