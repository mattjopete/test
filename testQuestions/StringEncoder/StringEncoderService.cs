using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using testQuestions.Interfaces;

namespace testQuestions.StringEncoder
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
           // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string stringToEncode = Console.ReadLine();

            string res = encode(stringToEncode);

            //textWriter.WriteLine(res);
            Console.WriteLine(res);
            //textWriter.Flush();
            //textWriter.Close();
        }

        static string encode(string stringToEncode)
        {
            //TODO: Refactor into dictionary once algorithm works
            if(string.IsNullOrEmpty(stringToEncode))
                return string.Empty;
         
            string encodedString = string.Empty;

            stringToEncode = stringToEncode.ToLower();
            for(int i = 0; i < stringToEncode.Length; i++)
            {           
                if(stringToEncode[i].Equals('y'))
                {
                    encodedString += ' ';
                }
                else if(stringToEncode[i].Equals(' '))
                {
                    encodedString += 'y';
                }
                else if(char.IsLetter(stringToEncode[i]) && "aeiou".Contains(stringToEncode[i]))
                {
                    switch (stringToEncode[i])
                    {
                        case 'a':
                            encodedString += '1';
                            break;
                        case 'e':
                            encodedString += '2';
                            break;
                        case 'i':
                            encodedString += '3';
                            break;
                        case 'o':
                            encodedString += '4';
                            break;
                        case 'u':
                            encodedString += '5';
                            break;
                    }
                }
                else if(char.IsLetter(stringToEncode[i]))
                {
                    encodedString += (char)(stringToEncode[i] - 1);
                }
                else if(char.IsDigit(stringToEncode[i]))
                {
                    var digits = stringToEncode.Substring(i).TakeWhile(char.IsDigit).Reverse().ToArray();
                    encodedString += new string(digits);
                    i += digits.Length - 1;
                }
                else
                {
                    encodedString += stringToEncode[i];
                }
            }

            return encodedString;
        }
    }
}