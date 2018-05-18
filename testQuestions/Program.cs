using System;
using Microsoft.Extensions.DependencyInjection; 
using testQuestions.Interfaces;
using testQuestions.ArrayTests.KadanesAlgorithm;
using testQuestions.StringTests.StringEncoder;
using testQuestions.ArrayTests.MissingNumber;

namespace testQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection().AddSingleton<ITest, MissingNumberService>().BuildServiceProvider();

            var testService = serviceProvider.GetService<ITest>();

            testService.Run();
            testService.HandleAppEnd();
        }
    }
}
