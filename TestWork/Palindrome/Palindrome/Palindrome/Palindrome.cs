/* Copyright 2023-2024 Aleksey Poziev
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License. */

namespace FirstTask;

/// <summary>
/// class for working with palindromes.
/// </summary>
public static class Palindrome
{
    /// <summary>
    /// method to check is string is a palindrome.
    /// </summary>
    /// <param name="expression">string that need to be checked.</param>
    /// <returns>true -- string is palindrome, false -- is not palindrome.</returns>
    /// <exception cref="ArgumentNullException">Can't to check is null on palindrome.</exception>
    public static bool IsPalindrome(string expression)
    {
        ArgumentNullException.ThrowIfNull(expression);

        expression = expression.ToLower();
        int leftSide = 0;
        int rightSide = expression.Length - 1;

        if (rightSide == -1)
        {
            return true;
        }

        while (leftSide < rightSide)
        {
            while (leftSide < rightSide && expression[leftSide] == ' ')
            {
                ++leftSide;
            }
            while (leftSide < rightSide && expression[rightSide] == ' ')
            {
                --rightSide;
            }

            if (leftSide >= rightSide)
            {
                return true;
            }

            if (expression[leftSide] != expression[rightSide])
            {
                return false;
            }

            ++leftSide;
            --rightSide;
        }

        return true;
    }
}