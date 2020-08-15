using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml;
using ChainingAssertion;
using Tokeiya3.StringManipulator;
using Xunit;

namespace Tokeiya3.StringManipulatorTests
{
	public class ToStringBuilderTests
	{
		private const string ExpectedString = "When seek the lazyness then arrive at diligence";

		private const string PreInputed =
			"Machines would never tumbe fall to evil, if human being didn't make mistakes.";


		[Fact]
		public void ScalarToStringBuilderTest()
		{
			ExpectedString.ToStringBuilder().Is(ExpectedString);

			ReadOnlySpan<char> span = ExpectedString;
			span.ToStringBuilder().Is(ExpectedString);

			ReadOnlyMemory<char> mem = new ReadOnlyMemory<char>(ExpectedString.ToCharArray());
			mem.ToStringBuilder().Is(ExpectedString);

			"".ToStringBuilder().Is("");

			span = new ReadOnlySpan<char>(Array.Empty<char>());
			span.ToStringBuilder().Is("");

			mem = new ReadOnlyMemory<char>(Array.Empty<char>());
			mem.ToStringBuilder().Is("");


		}

		[Fact]
		public void JoinToStringBuilderTest()
		{
			string expected = ExpectedString.Replace(' ', '\t');
			var array = ExpectedString.Split(' ');

			array.ToStringBuilder('\t').Is(expected);
			array.ToStringBuilder("\t").Is(expected);

			array.Select(x => x).ToStringBuilder('\t').Is(expected);
			array.Select(x => x).ToStringBuilder("\t").Is(expected);

			var mem = new ReadOnlyMemory<string>(array);
			mem.ToStringBuilder('\t').Is(expected);
			mem.ToStringBuilder("\t").Is(expected);

			var span = new ReadOnlySpan<string>(array);
			span.ToStringBuilder('\t').Is(expected);
			span.ToStringBuilder("\t").Is(expected);

			var seq = array.Select(x => x.ToCharArray().Select(y => y));
			seq.ToStringBuilder('\t').Is(expected);
			seq.ToStringBuilder("\t").Is(expected);
		}

		[Fact]
		public void JoinedAppendTest()
		{
			var expected = PreInputed + ExpectedString.Replace(' ', '\t');
			var bld = PreInputed.ToStringBuilder();

			StringBuilder reset() => bld.Clear().Append(PreInputed);


			var array = ExpectedString.Split(' ');
			array.AppendToStringBuilder(bld,'\t').Is(expected);
			array.Append("\t").Is(expected);


			array.Select(s => s).AppendToStringBuilder(reset(), '\t').Is(expected);
			array.Select(s=>s).AppendToStringBuilder(reset(),"\t").Is(expected);

			new ReadOnlySpan<string>(array).AppendToStringBuilder(reset(),'\t').Is(expected);

			new ReadOnlySpan<string>(array).AppendToStringBuilder(reset(), "\t").Is(expected);

			new ReadOnlyMemory<string>(array).AppendToStringBuilder(reset(), '\t').Is(expected);

			new ReadOnlyMemory<string>(array).AppendToStringBuilder(reset(), "\t").Is(expected);

			var seq = array.Select(s => s.ToCharArray().Select(c => c));

			seq.AppendToStringBuilder(reset(), '\t').Is(expected);
			seq.AppendToStringBuilder(reset(), "\t").Is(expected);
		}

		[Fact]
		public void AppendToStringBuilderAsLineTest()
		{
			var bld = PreInputed.ToStringBuilder();
			StringBuilder reset() => bld.Clear().Append(PreInputed);

			var array = ExpectedString.Split(' ');
			var expected = PreInputed + ExpectedString.Replace(' ', '\t') + Environment.NewLine;
			
			array.AppendToStringBuilderAsLine(reset(),'\t').Is(expected);
			
			array.AppendToStringBuilder(reset(),"\t").Is(expected);

			var span=new ReadOnlySpan<string>(array);
			span.AppendToStringBuilderAsLine(reset(),'\t').Is(expected);

			span.AppendToStringBuilderAsLine(reset(),"\t").Is(expected);

			var mem=new ReadOnlyMemory<string>(array);
			mem.AppendToStringBuilderAsLine(reset(),'\t').Is(expected);

			mem.AppendToStringBuilderAsLine(reset(),"\t").Is(expected);

			var seq = array.Select(s => s.ToCharArray().Select(c => c));
			
			seq.AppendToStringBuilderAsLine(reset(),'\t').Is(expected);
			seq.AppendToStringBuilderAsLine(reset(),"\t").Is(expected);
			
		}

		[Fact]
		public void ExtractTest()
		{
			var bld = new StringBuilder();
			StringBuilder reset() => bld.Clear().Append("0123456789");

			reset().Extract(1..).Is("123456789");
			reset().Extract(..^1).Is("012345678");

			reset().Extract(..).Is("0123456789");
			reset().Extract(^3..).Is("789");

			reset().Extract(1..^1).Is("12345678");
			reset().Extract(..^10).Is("");

			Assert.Throws<ArgumentOutOfRangeException>(() => reset().Extract(-1..));
			Assert.Throws<ArgumentOutOfRangeException>(() => reset().Extract(..-1));
			Assert.Throws<ArgumentOutOfRangeException>(() => reset().Extract(..^11));
			Assert.Throws<ArgumentOutOfRangeException>(() => reset().Extract(1..^10));
			Assert.Throws<ArgumentOutOfRangeException>(() => reset().Extract(11..));



		}



	}
}