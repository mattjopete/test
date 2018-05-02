using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using testQuestions.Interfaces;

namespace testQuestions.KadanesAlgorithm
{
    public class KadaneSolverService : ITest
    {
        public int Sum(KadaneTestCase testCase)
        {
            var sum = 0;
            for( int i =0; i< testCase.numberCount; i++ )
            {
                sum += testCase.numbers[i];
            }
            return sum;
        }

        public void Run()
        {
            var testCases = ReadInput();
            foreach(var testCase in testCases) 
            {
                var sum = Sum(testCase);
                Console.WriteLine("Sum is:" + sum);
            }
        }

        public IEnumerable<KadaneTestCase> ReadInput()
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
                var kadaneTestCase = new KadaneTestCase 
                {
                    numberCount = numberCount,
                    numbers = numbers
                };

                yield return kadaneTestCase;
            }            
        }

        public void HandleAppEnd()
        {
            Console.WriteLine("Enter any key to kill the program");
            Console.ReadKey();
        }
    }
}