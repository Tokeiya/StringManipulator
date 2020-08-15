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

		private const string PreInputted =
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
			array.ToStringBuilder("hoge").Is(ExpectedString.Replace(" ", "hoge"));
			Array.Empty<string>().ToStringBuilder('\t').Is("");
			Array.Empty<string>().ToStringBuilder("hoge").Is("");

			array.Select(x => x).ToStringBuilder('\t').Is(expected);
			array.Select(x => x).ToStringBuilder("hoge").Is(ExpectedString.Replace(" ", "hoge"));
			Enumerable.Empty<string>().ToStringBuilder('\t').Is("");
			Enumerable.Empty<string>().ToStringBuilder("hoge").Is("");

			var mem = new ReadOnlyMemory<string>(array);
			mem.ToStringBuilder('\t').Is(expected);
			mem.ToStringBuilder("hoge").Is(ExpectedString.Replace(" ", "hoge"));
			
			mem=new ReadOnlyMemory<string>(Array.Empty<string>());
			mem.ToStringBuilder('\t').Is("");
			mem.ToStringBuilder("hoge").Is("");


			var span = new ReadOnlySpan<string>(array);
			span.ToStringBuilder('\t').Is(expected);
			span.ToStringBuilder("hoge").Is(ExpectedString.Replace(" ", "hoge"));

			span=new ReadOnlySpan<string>(Array.Empty<string>());
			span.ToStringBuilder('\t').Is("");
			span.ToStringBuilder("hoge").Is("");


			var seq = array.Select(x => x.ToCharArray().Select(y => y));
			seq.ToStringBuilder('\t').Is(expected);
			seq.ToStringBuilder("hoge").Is(ExpectedString.Replace(" ","hoge"));

			Enumerable.Empty<string>().ToStringBuilder('\t').Is("");
			Enumerable.Empty<string>().ToStringBuilder("hoge").Is("");
		}

		[Fact]
		public void JoinedAppendTest()
		{
			var expected = PreInputed + ExpectedString.Replace(' ', '\t');
			var bld = PreInputed.ToStringBuilder();

			StringBuilder reset() => bld.Clear().Append(PreInputed);


			var array = ExpectedString.Split(' ');
			array.AppendToStringBuilder(reset(),'\t').Is(expected);
			array.AppendToStringBuilder(reset(),"hoge").Is(PreInputed + ExpectedString.Replace(" ", "hoge"));

			Array.Empty<string>().AppendToStringBuilder(reset(),'\t').Is(PreInputed);
			Array.Empty<string>().AppendToStringBuilder(reset(),"hoge").Is(PreInputed);


			array.Select(s => s).AppendToStringBuilder(reset(), '\t').Is(expected);
			array.Select(s=>s).AppendToStringBuilder(reset(),"hoge").Is(PreInputed+ExpectedString.Replace(" ","hoge"));

			Enumerable.Empty<string>().AppendToStringBuilder(reset(),'\t').Is(PreInputed);
			Enumerable.Empty<string>().AppendToStringBuilder(reset(),"hoge").Is(PreInputed);

			new ReadOnlySpan<string>(array).AppendToStringBuilder(reset(),'\t').Is(expected);
			new ReadOnlySpan<string>(array).AppendToStringBuilder(reset(), "hoge").Is(PreInputed + ExpectedString.Replace(" ", "hoge")); ;

			new ReadOnlySpan<string>(Array.Empty<string>()).AppendToStringBuilder(reset(),'\t').Is(PreInputed);
			new ReadOnlySpan<string>(Array.Empty<string>()).AppendToStringBuilder(reset(),"hoge").Is(PreInputed);

			new ReadOnlyMemory<string>(array).AppendToStringBuilder(reset(), '\t').Is(expected);
			new ReadOnlyMemory<string>(array).AppendToStringBuilder(reset(), "hoge").Is(PreInputed + ExpectedString.Replace(" ", "hoge")); ;

			new ReadOnlyMemory<string>(Array.Empty<string>()).AppendToStringBuilder(reset(),'\t').Is(PreInputed);
			new ReadOnlyMemory<string>(Array.Empty<string>()).AppendToStringBuilder(reset(),"hoge").Is(PreInputed);

			var seq = array.Select(s => s.ToCharArray().Select(c => c));
			seq.AppendToStringBuilder(reset(), '\t').Is(expected);
			seq.AppendToStringBuilder(reset(), "hoge").Is(PreInputed + ExpectedString.Replace(" ", "hoge")); ;

			seq = Enumerable.Empty<string>();
			seq.AppendToStringBuilder(reset(),'\t').Is(PreInputed);
			seq.AppendToStringBuilder(reset(),"hoge").Is(PreInputed);

		}

		[Fact]
		public void AppendToStringBuilderAsLineTest()
		{
			var bld = PreInputed.ToStringBuilder();
			StringBuilder reset() => bld.Clear().Append(PreInputed);

			var array = ExpectedString.Split(' ');
			var expected = PreInputed + ExpectedString.Replace(' ', '\t') + Environment.NewLine;

			array.AppendToStringBuilderAsLine(reset(), '\t').Is(expected);
			array.AppendToStringBuilder(reset(),"hoge").Is(PreInputed+ExpectedString.Replace(" ","hoge"));
			
			Array.Empty<string>().AppendToStringBuilderAsLine(reset(),'\t').Is(PreInputed+Environment.NewLine);
			Array.Empty<string>().AppendToStringBuilderAsLine(reset(),"hoge").Is(PreInputed+Environment.NewLine);

			var span=new ReadOnlySpan<string>(array);
			span.AppendToStringBuilderAsLine(reset(),'\t').Is(expected);
			span.AppendToStringBuilderAsLine(reset(), "hoge").Is(PreInputed + ExpectedString.Replace(" ", "hoge"));

			span=new ReadOnlySpan<string>(Array.Empty<string>());
			span.AppendToStringBuilderAsLine(reset(),'\t').Is(PreInputed+Environment.NewLine);
			span.AppendToStringBuilderAsLine(reset(),"hoge").Is(PreInputed+Environment.NewLine);

			
			var mem=new ReadOnlyMemory<string>(array);
			mem.AppendToStringBuilderAsLine(reset(),'\t').Is(expected);
			mem.AppendToStringBuilder(reset(), "hoge").Is(PreInputed + ExpectedString.Replace(" ", "hoge"));

			mem=new ReadOnlyMemory<string>(Array.Empty<string>());
			mem.AppendToStringBuilderAsLine(reset(),'\t').Is(PreInputed+Environment.NewLine);
			mem.AppendToStringBuilderAsLine(reset(),"hoge").Is(PreInputed+Environment.NewLine);

			var seq = array.Select(s => s.ToCharArray().Select(c => c));
			seq.AppendToStringBuilderAsLine(reset(),'\t').Is(expected);
			seq.AppendToStringBuilder(reset(), "hoge").Is(PreInputed + ExpectedString.Replace(" ", "hoge"));

			seq = Enumerable.Empty<string>();
			seq.AppendToStringBuilderAsLine(reset(),'\t').Is(PreInputed+Environment.NewLine);
			seq.AppendToStringBuilderAsLine(reset(),"hoge").Is(PreInputed+Environment.NewLine);

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
			reset().Extract(10..).Is("");

			Assert.Throws<ArgumentOutOfRangeException>(() => reset().Extract(-1..));
			Assert.Throws<ArgumentOutOfRangeException>(() => reset().Extract(..-1));
			Assert.Throws<ArgumentOutOfRangeException>(() => reset().Extract(..^11));
			Assert.Throws<ArgumentOutOfRangeException>(() => reset().Extract(1..^10));
			Assert.Throws<ArgumentOutOfRangeException>(() => reset().Extract(11..));
		}



	}
}