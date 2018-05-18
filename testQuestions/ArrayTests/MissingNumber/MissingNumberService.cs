using System;
using System.Collections.Generic;
using System.Linq;
using testQuestions.Interfaces;

namespace testQuestions.ArrayTests.MissingNumber
{
    public class MissingNumberService : ITest
    {
        public void HandleAppEnd()
        {
            Console.WriteLine("Enter any key to kill the program");
            Console.ReadKey();
        }

        public void Run()
        {
            var testCases = ReadInput();
            foreach(var testCase in testCases) 
            {
                Console.WriteLine("Result for test case: " + ProcessTestCase(testCase));
            }
        }

        public int ProcessTestCase(MissingNumberTestCase testCase)
        {
            for( int i = 0; i< testCase.NumberCount -1; i++)
                {
                    int whatItShouldBe = i + testCase.Numbers.First();
                    if( whatItShouldBe != testCase.Numbers[i])
                    {
                        return whatItShouldBe;
                    }
                }

                return testCase.Numbers.First() + testCase.NumberCount -1;
        }

         public IEnumerable<MissingNumberTestCase> ReadInput()
        {
            Console.WriteLine("Enter the number of test cases:");
            var numberOfCases = Console.ReadLine();
            Int32.TryParse(numberOfCases, out int cases);
            
            for(int i = 0; i< cases; i++)
            {
                Console.WriteLine("Enter the amount of numbers in this case:");
                var caseLength = Console.ReadLine();
                Int32.TryParse(caseLength, out int numberCount);
                
                Console.WriteLine("Enter the numbers for this case separated by a blank space:");
                var caseNumbers = Console.ReadLine();
                var splitCaseNumbers = caseNumbers.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                var numbers = splitCaseNumbers.Select(s => Int32.TryParse(s, out int n) ? n : (int?)null)
                    .Where(n => n.HasValue)
                    .Select(n => n.Value)
                    .ToList();
                var missingNUmberTestcase = new MissingNumberTestCase 
                {
                    NumberCount = numberCount,
                    Numbers = numbers
                };

                yield return missingNUmberTestcase;
            }            
        }

    }
}