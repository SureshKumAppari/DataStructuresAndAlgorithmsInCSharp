using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    class BraceExpand
    {
		/*
		My parsing code could be cleaner I think. I am a little annoyed by the edge cases such as "abcd" and "{a,b}cdf{g,h}" and by the condition to sort lexographically but I made it work.

goals:
want to separate the parsing from the combinatorics.
write interatively without recursion

Approach:
parse list of lists
result = [a,b,c] -> [d] -> [e, f] O(N) space. O(N) operation.

3 * 1 * 2 (length of sets) = how many total strings we need to generate

Build up strings from empty to last character: O(N * M)

{a, b, c}d{e,f}{g,h}

list of lists = [[a,b,c], [d], [e,f], [g,h]] Length = 4
left = 1, right = 3 * 1 * 2 * 2 = 12;

string array of 12 empty strings
"" "" "" "" "" "" "" "" "" "" "" ""
left 1, right = 12
12 / 3 = 4 * 1 put each item in 4 times, repeat once

a a a a b b b b c c c c

left 3 right 4
4 / 1 = 4 * 3 = put each item in 4 times, repeat 3 times

ad ad ad ad bd bd bd bd cd cd cd cd

left 3 right 4
4 / 2 = 2 * 3 = put each item in 2 times, repeat three times.

ade ade adf adf bde bde bdf bdf cde cde cdf cdf

left 6 right 2
2 / 2 = 1 * 6 = each item goes in 1 time, repeat 6 times
a

adeg adeh adfg adfh bdeg bdeh bdfg bdfh cdeg cdeh cdfg cdfh

done. 
		*/
		private static void notMain(string[] args)
		{
			string[] result = Expand(Console.ReadLine());
			for(int i = 0; i< result.Length; i++)
			{
				Console.WriteLine(result[i]);
			}
			Console.WriteLine("press any key to exit");
			Console.ReadLine();
		}

		public static string[] Expand(string S)
		{
			var sets = ParseSets(S);

			var right = 1;
			foreach (var set in sets)
			{
				right *= set.Count;
				set.Sort(); // lexographic order is a lame constraint but sort here works.
			}

			var generatedStrings = new string[right];

			foreach (var set in sets)
			{
				right /= set.Count;

				for (var i = 0; i < generatedStrings.Length; i += right)
				{
					var ch = set[(i / right) % set.Count];
					for (var j = 0; j < right; j++)
						generatedStrings[i + j] += ch;
				}
			}

			return generatedStrings;
		}

		private static List<List<string>> ParseSets(string S)
		{
			var sets = new List<List<string>>();
			var currentSet = new List<string>();
			sets.Add(currentSet);

			var insideBracket = false;

			for(var i = 0; i< S.Length; i++)
			{
				var ch = S[i];
				if(ch != '{' && ch != ',' && ch != '}')
				{
					if (insideBracket)
						currentSet.Add(ch.ToString());
					else
					{
						if (currentSet.Count == 0)
							currentSet.Add(ch.ToString());
						else
							currentSet[0] += ch;
					}
				}
				else if(ch == '{' || (ch == '}' && i != S.Length - 1))
				{
					if (ch == '{')
						insideBracket = true;

					if (ch == '}')
						insideBracket = false;

					if(currentSet.Count > 0)
					{
						currentSet = new List<string>();
						sets.Add(currentSet);
					}
				}
			}

			return sets;
		}
	}

}
