using BenchmarkDotNet.Running;

// Слагаме Program в същия "namespace", в който е и твоят бенчмарк клас
namespace JsonBenchmarkProject 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Този ред казва на BenchmarkDotNet да намери всички методи
            // в класа JsonComparisonBenchmark и да ги изпълни.
            
            // Вече ще го намира, защото и двата класа са в "JsonBenchmarkProject"
            var summary = BenchmarkRunner.Run<JsonComparisonBenchmark>();
        }
    }
}