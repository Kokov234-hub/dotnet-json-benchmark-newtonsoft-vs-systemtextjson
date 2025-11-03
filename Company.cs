using System.Collections.Generic;

// Увери се, че и този файл е в същия namespace
namespace JsonBenchmarkProject 
{
    public class Company
    {
        public string? Name { get; set; }            // <--- ЕТО ПРОМЯНАТА (добавен '?')
        public List<Employee>? Employees { get; set; } // <--- ЕTO ПРОМЯНАТА (добавен '?')
    }

    public class Employee
    {
        public string? Name { get; set; }            // <--- ЕТО ПРОМЯНАТА (добавен '?')
        public string? Position { get; set; }
        public List<string>? Hobbies { get; set; }   // <--- ЕТО ПРОМЯНАТА (добавен '?')
    }
}