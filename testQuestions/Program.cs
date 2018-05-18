using System;
using Microsoft.Extensions.DependencyInjection; 
using testQuestions.Interfaces;
using testQuestions.ArrayTests.KadanesAlgorithm;
using testQuestions.StringTests.StringEncoder;

namespace testQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection().AddSingleton<ITest, StringEncoderService>().BuildServiceProvider();

            var testService = serviceProvider.GetService<ITest>();

            testService.Run();
            testService.HandleAppEnd();
        }
    }
}
