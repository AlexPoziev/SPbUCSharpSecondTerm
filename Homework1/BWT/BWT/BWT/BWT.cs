namespace Algorithms;
using System;
	// class that contain direct and inverse BWT
	public static class BWT
	{
        // Direct Burrows–Wheeler transform
        // returns transformed string and index of last element
        public static (string, int) DirectBWT(in string word)
		{
			var suffixIndexArray = new int[word.Length];
			BWTSort.FillArrayBySequence(suffixIndexArray);

			var lastElement = BWTSort.DirectBWTSort(word, suffixIndexArray);

			string bwtString = "";
			for (int i = 0; i < word.Length; ++i)
			{
                bwtString += word[(suffixIndexArray[i] + word.Length - 1) % word.Length];
			}

			return (bwtString, lastElement);
		}

        // Inverse Burrows–Wheeler transform
        // returns origin string
        public static string InverseBWT(in string transformedString, int lastElementIndex)
		{
			var shiftArray = new int[transformedString.Length];
			BWTSort.FillArrayBySequence(shiftArray);
			BWTSort.InverseBWTSort(transformedString, shiftArray);

			var originString = "";  

			for (int i = 0; i < transformedString.Length; ++i)
			{
				originString += transformedString[shiftArray[lastElementIndex]];
				lastElementIndex = shiftArray[lastElementIndex];
			}

			return originString;
		}
	}