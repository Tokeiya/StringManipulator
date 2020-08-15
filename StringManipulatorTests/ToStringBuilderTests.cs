using System;
using System.Linq;
using System.Text;
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
			reset();
			array.Append("\t").Is(expected);


			reset();
			array.Select(s => s).AppendToStringBuilder(bld, '\t').Is(expected);
			reset();
			array.Select(s=>s).AppendToStringBuilder(bld,"\t").Is(expected);

			reset();
			new ReadOnlySpan<string>(array).AppendToStringBuilder(bld,'\t').Is(expected);

			reset();
			new ReadOnlySpan<string>(array).AppendToStringBuilder(bld, "\t").Is(expected);

			reset();
			new ReadOnlyMemory<string>(array).AppendToStringBuilder(bld, '\t').Is(expected);

			reset();
			new ReadOnlyMemory<string>(array).AppendToStringBuilder(bld, "\t").Is(expected);

			var seq = array.Select(s => s.ToCharArray().Select(c => c));

			reset();
			seq.AppendToStringBuilder(bld, '\t').Is(expected);

			reset();
			seq.AppendToStringBuilder(bld, "\t").Is(expected);
		}

		[Fact]
		public void AppendToStringBuilderAsLineTest()
		{
			var bld = PreInputed.ToStringBuilder();
			StringBuilder reset() => bld.Clear().Append(PreInputed);

			var array = ExpectedString.Split(' ');
			var expected = PreInputed + ExpectedString.Replace(' ', '\t') + Environment.NewLine;
			
			array.AppendToStringBuilderAsLine(bld,'\t').Is(expected);
			
			reset();
			array.AppendToStringBuilder(bld,"\t").Is(expected);

			reset();
			var span=new ReadOnlySpan<string>(array);
			span.AppendToStringBuilderAsLine(bld,'\t').Is(expected);

			reset();
			span.AppendToStringBuilderAsLine(bld,"\t").Is(expected);

			reset();
			var mem=new ReadOnlyMemory<string>(array);
			mem.AppendToStringBuilderAsLine(bld,'\t').Is(expected);

			reset();
			mem.AppendToStringBuilderAsLine(bld,"\t").Is(expected);

			var seq = array.Select(s => s.ToCharArray().Select(c => c));
			
			reset();
			seq.AppendToStringBuilderAsLine(bld,'\t').Is(expected);

			reset();
			seq.AppendToStringBuilderAsLine(bld,"\t").Is(expected);
			
			
		}


	}
}