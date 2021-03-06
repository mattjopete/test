using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using testQuestions.Interfaces;

namespace testQuestions.StringTests.StringEncoder
{
    public class StringEncoderService : ITest
    {

        public void HandleAppEnd()
        {
            Console.WriteLine("Enter any key to kill the program");
            Console.ReadKey();
        }

        public void Run()
        {
            string stringToEncode = Console.ReadLine();

            string res = encode(stringToEncode);

            Console.WriteLine(res);
        }

        static string encode(string stringToEncode)
        {
            var encodingDictionary = new Dictionary<char, char>()
            {
                {'a', '1'},
                {'e', '2'},
                {'i', '3'},
                {'o', '4'},
                {'u', '5'},
                {'y', ' '},
                {' ', 'y'},
                {'b', 'a'},
                {'c', 'b'},
                {'d', 'c'},
                {'f', 'e'},
                {'g', 'f'},
                {'h', 'g'},
                {'j', 'i'},
                {'k', 'j'},
                {'l', 'k'},
                {'m', 'l'},
                {'n', 'm'},
                {'p', 'o'},
                {'q', 'p'},
                {'r', 'q'},
                {'s', 'r'},
                {'t', 's'},
                {'v', 'u'},
                {'w', 'v'},
                {'x', 'w'},
                {'z', 'y'},
            };

            string encodedString = string.Empty;

            stringToEncode = stringToEncode.ToLower();
            for (int i = 0; i < stringToEncode.Length; i++)
            {
                var currentChar = stringToEncode[i];

                if(encodingDictionary.ContainsKey(currentChar))
                {
                    encodedString += encodingDictionary[currentChar];
                }
                else if (char.IsDigit(currentChar))
                {
                    var digits = stringToEncode.Substring(i).TakeWhile(char.IsDigit).Reverse().ToArray();
                    encodedString += new string(digits);
                    i += digits.Length - 1;
                }
                else
                {
                    encodedString += currentChar;
                }
            }
            return encodedString;
        }
    }
}