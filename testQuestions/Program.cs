using System;
using Microsoft.Extensions.DependencyInjection; 
using testQuestions.Interfaces;
using testQuestions.KadanesAlgorithm;

namespace testQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection().AddSingleton<ITest, KadaneSolverService>().BuildServiceProvider();

            var testService = serviceProvider.GetService<ITest>();

            testService.Run();
            testService.HandleAppEnd();
        }
    }
}
