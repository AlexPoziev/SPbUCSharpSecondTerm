using System;

namespace Algorithms
{
	public static class BWT
	{
		public static (string, int) DirectBWT(string word)
		{
			var suffixIndexArray = new int[word.Length];
			for (int i = 0; i < suffixIndexArray.Length; ++i)
			{
				suffixIndexArray[i] = i;
			}

			var lastElement = BWTUtils.BWTSort.Sort(word, suffixIndexArray);

			string bwtString = "";
			for (int i = 0; i < word.Length; ++i)
			{
                bwtString += word[(suffixIndexArray[i] + word.Length - 1) % word.Length];
			}

			return (bwtString, lastElement);
		}
	}
}

