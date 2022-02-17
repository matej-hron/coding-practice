using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution
{
    

    public class Solution {
        
        static List<(char left, char right)> brackets = new List<(char left, char right)> 
        {
            ('(', ')'),
            ('[', ']'),
            ('{', '}'),
        };

        public static void Main(string[] args) {
            // you can write to stdout for debugging purposes, e.g.
            Test<string>.For(1, Validate("()")).ShouldBe("YES");
            Test<string>.For(2, Validate("")).ShouldBe("YES");
            Test<string>.For(3, Validate("(")).ShouldBe("NO");
            Test<string>.For(4, Validate("(")).ShouldBe("NO");
            Test<string>.For(5, Validate("([])")).ShouldBe("YES");
            Test<string>.For(6, Validate("([)]")).ShouldBe("YES");
        }

        public static string Validate(string expression)
        {
            var openBrackets = new HashSet<char>(brackets.Select(pair => pair.left));
            var rightToLeftMap = brackets.ToDictionary(pair => pair.right, pair => pair.left);

            int ValidateRec(char openBracket, int index)
            {
                for(int i = index; i < expression.Length; i++)
                {
                    var currentChar = expression[i];

                    if(openBrackets.Contains(currentChar)) // opening bracket
                    {
                        i = ValidateRec(currentChar, i + 1);
                    }

                    if(rightToLeftMap.ContainsKey(currentChar))
                    {
                        if(openBracket != rightToLeftMap[currentChar])
                        {
                            throw new Exception($"Closing bracket: {currentChar} does not match currently opened bracket: {openBracket}");
                        }

                        return i;
                    }
                }

                if(openBracket != default)
                {
                    throw new Exception($"Reached end of expression with opened bracket {openBracket}");
                }

                return expression.Length - 1;
            }
            try
            {
                ValidateRec(default, 0);
                return "YES";
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return "NO";
            }
        }
    }

    public class Test<T> where T : class
    {
        private T expected;
        private T actual;
        private int testNumber;

        public static Test<T> For<T>(int testNumber, T actual) where T : class
        {
            Console.WriteLine($"Test {testNumber}, Actual: {actual}");
            return new Test<T> {actual = actual};
        }

        public void ShouldBe(T expected)
        {
            Console.WriteLine($"Expected: {expected}");
            if(expected == actual)
            {
                Console.WriteLine("passed");
            }
            else{
                Console.WriteLine("failed");
            }
        }
    }
}
