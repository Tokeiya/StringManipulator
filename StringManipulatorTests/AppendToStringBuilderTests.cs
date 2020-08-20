using System;
using System.Linq;
using System.Text;
using Tokeiya3.StringManipulator;
using Xunit;

namespace Tokeiya3.StringManipulatorTests
{
	public class AppendToStringBuilderTests
	{

		private const string ExpectedString = "When seek the lazyness then arrive at diligence";

		private const string PreInputted =
			"Machines would never tumbe fall to evil, if human being didn't make mistakes.";


		[Fact]
		public void StringArrayTest()
		{
			var sample = ExpectedString.Split(' ');
			var actual = PreInputted.ToStringBuilder();

			sample.AppendToStringBuilder(actual, '\t');
			actual.Is(PreInputted, ExpectedString, " ", "\t");

			actual = PreInputted.ToStringBuilder();
			sample.AppendToStringBuilder(actual, "ばらし");
			actual.Is(PreInputted, ExpectedString, " ", "ばらし");

		}


		[Fact]
		public void JoinedAppendTest()
		{
			var expected = PreInputted + ExpectedString.Replace(' ', '\t');
			var bld = PreInputted.ToStringBuilder();

			StringBuilder reset()
			{
				return bld.Clear().Append(PreInputted);
			}


			var array = ExpectedString.Split(' ');
			array.AppendToStringBuilder(reset(), '\t').Is(expected);
			array.AppendToStringBuilder(reset(), "hoge").Is(PreInputted + ExpectedString.Replace(" ", "hoge"));

			Array.Empty<string>().AppendToStringBuilder(reset(), '\t').Is(PreInputted);
			Array.Empty<string>().AppendToStringBuilder(reset(), "hoge").Is(PreInputted);


			array.Select(s => s).AppendToStringBuilder(reset(), '\t').Is(expected);
			array.Select(s => s).AppendToStringBuilder(reset(), "hoge")
				.Is(PreInputted + ExpectedString.Replace(" ", "hoge"));

			Enumerable.Empty<string>().AppendToStringBuilder(reset(), '\t').Is(PreInputted);
			Enumerable.Empty<string>().AppendToStringBuilder(reset(), "hoge").Is(PreInputted);

			new ReadOnlySpan<string>(array).AppendToStringBuilder(reset(), '\t').Is(expected);
			new ReadOnlySpan<string>(array).AppendToStringBuilder(reset(), "hoge")
				.Is(PreInputted + ExpectedString.Replace(" ", "hoge"));
			;

			new ReadOnlySpan<string>(Array.Empty<string>()).AppendToStringBuilder(reset(), '\t').Is(PreInputted);
			new ReadOnlySpan<string>(Array.Empty<string>()).AppendToStringBuilder(reset(), "hoge").Is(PreInputted);

			new ReadOnlyMemory<string>(array).AppendToStringBuilder(reset(), '\t').Is(expected);
			new ReadOnlyMemory<string>(array).AppendToStringBuilder(reset(), "hoge")
				.Is(PreInputted + ExpectedString.Replace(" ", "hoge"));
			;

			new ReadOnlyMemory<string>(Array.Empty<string>()).AppendToStringBuilder(reset(), '\t').Is(PreInputted);
			new ReadOnlyMemory<string>(Array.Empty<string>()).AppendToStringBuilder(reset(), "hoge").Is(PreInputted);

			var seq = array.Select(s => s.ToCharArray().Select(c => c));
			seq.AppendToStringBuilder(reset(), '\t').Is(expected);
			seq.AppendToStringBuilder(reset(), "hoge").Is(PreInputted + ExpectedString.Replace(" ", "hoge"));
			;

			seq = Enumerable.Empty<string>();
			seq.AppendToStringBuilder(reset(), '\t').Is(PreInputted);
			seq.AppendToStringBuilder(reset(), "hoge").Is(PreInputted);


			var strAry = Enumerable.Range(0, 10).Select(i => i.ToString()).ToArray();
			strAry.AppendToStringBuilder(reset(), '\t').Is(PreInputted + string.Join('\t', strAry));
			strAry.AppendToStringBuilder(reset(), "hoge").Is(PreInputted + string.Join("hoge", strAry));

			object[] objAry = strAry;

			objAry.AppendToStringBuilder(reset(), '\t').Is(PreInputted + string.Join('\t', objAry));
			objAry.AppendToStringBuilder(reset(), "hoge").Is(PreInputted + string.Join("hoge", objAry));

		}


		[Fact]
		public void AppendToStringBuilderAsLineTest()
		{
			var bld = PreInputted.ToStringBuilder();

			StringBuilder reset()
			{
				return bld.Clear().Append(PreInputted);
			}

			var array = ExpectedString.Split(' ');
			var expected = PreInputted + ExpectedString.Replace(' ', '\t') + Environment.NewLine;

			array.AppendToStringBuilderAsLine(reset(), '\t').Is(expected);
			array.AppendToStringBuilder(reset(), "hoge").Is(PreInputted + ExpectedString.Replace(" ", "hoge"));

			Array.Empty<string>().AppendToStringBuilderAsLine(reset(), '\t').Is(PreInputted + Environment.NewLine);
			Array.Empty<string>().AppendToStringBuilderAsLine(reset(), "hoge").Is(PreInputted + Environment.NewLine);

			var span = new ReadOnlySpan<string>(array);
			span.AppendToStringBuilderAsLine(reset(), '\t').Is(expected);
			span.AppendToStringBuilderAsLine(reset(), "hoge").Is(PreInputted + ExpectedString.Replace(" ", "hoge") + Environment.NewLine);

			span = new ReadOnlySpan<string>(Array.Empty<string>());
			span.AppendToStringBuilderAsLine(reset(), '\t').Is(PreInputted + Environment.NewLine);
			span.AppendToStringBuilderAsLine(reset(), "hoge").Is(PreInputted + Environment.NewLine);


			var mem = new ReadOnlyMemory<string>(array);
			mem.AppendToStringBuilderAsLine(reset(), '\t').Is(expected);
			mem.AppendToStringBuilder(reset(), "hoge").Is(PreInputted + ExpectedString.Replace(" ", "hoge"));

			mem = new ReadOnlyMemory<string>(Array.Empty<string>());
			mem.AppendToStringBuilderAsLine(reset(), '\t').Is(PreInputted + Environment.NewLine);
			mem.AppendToStringBuilderAsLine(reset(), "hoge").Is(PreInputted + Environment.NewLine);

			var seq = array.Select(s => s.ToCharArray().Select(c => c));
			seq.AppendToStringBuilderAsLine(reset(), '\t').Is(expected);
			seq.AppendToStringBuilder(reset(), "hoge").Is(PreInputted + ExpectedString.Replace(" ", "hoge"));

			seq = Enumerable.Empty<string>();
			seq.AppendToStringBuilderAsLine(reset(), '\t').Is(PreInputted + Environment.NewLine);
			seq.AppendToStringBuilderAsLine(reset(), "hoge").Is(PreInputted + Environment.NewLine);

			var strArray = Enumerable.Range(0, 10).Select(i => i.ToString()).ToArray();
			strArray.AppendToStringBuilderAsLine(reset(), '\t')
				.Is(PreInputted + string.Join('\t', strArray) + Environment.NewLine);

			strArray.AppendToStringBuilderAsLine(reset(), "hoge")
				.Is(PreInputted + string.Join("hoge", strArray) + Environment.NewLine);

			object[] objArray = strArray;
			objArray.AppendToStringBuilderAsLine(reset(), '\t')
				.Is(PreInputted + string.Join('\t', objArray) + Environment.NewLine);

			objArray.AppendToStringBuilderAsLine(reset(), "hoge")
				.Is(PreInputted + string.Join("hoge", objArray) + Environment.NewLine);

			var intSeq = Enumerable.Range(0, 10);
			intSeq.AppendToStringBuilderAsLine(reset(), '\t')
				.Is(PreInputted + string.Join('\t', intSeq) + Environment.NewLine);

			intSeq.AppendToStringBuilderAsLine(reset(), "hoge")
				.Is(PreInputted + string.Join("hoge", intSeq) + Environment.NewLine);

		}
	}
}