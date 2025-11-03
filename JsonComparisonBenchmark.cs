namespace JsonBenchmarkProject
{
    using BenchmarkDotNet.Attributes;
    using System.Collections.Generic;
    using System.Linq; 

    
    using Stj = System.Text.Json;
    using Nsj = Newtonsoft.Json;

    [MemoryDiagnoser]
    public class JsonComparisonBenchmark
    {
        [Params(100, 1000, 5000)]
        public int EmployeeCount { get; set; }

        
        private string? _jsonStringContent;
        private Company? _companyObject;

        [GlobalSetup] 
        public void Setup()
        {
            
            
            var employees = new List<Employee>();
            for (int i = 0; i < EmployeeCount; i++)
            {
                employees.Add(new Employee
                {
                    Name = $"Employee Name {i}",
                    Position = (i % 10 == 0) ? "Manager" : "Developer",
                    Hobbies = new List<string> { "Reading", $"Task-{i}", "Skiing" }
                });
            }

            _companyObject = new Company
            {
                Name = $"Big Tech Corp (Служители: {EmployeeCount})",
                Employees = employees
            };

            
            _jsonStringContent = Stj.JsonSerializer.Serialize(_companyObject);
        }

        

        [Benchmark(Description = "Newtonsoft: Serialize")]
        public string SerializeNewtonsoft()
        {
            return Nsj.JsonConvert.SerializeObject(_companyObject);
        }

        [Benchmark(Description = "System.Text.Json: Serialize")]
        public string SerializeSystemTextJson()
        {
            return Stj.JsonSerializer.Serialize(_companyObject);
        }

    

        [Benchmark(Description = "Newtonsoft: Deserialize")]
        public Company DeserializeNewtonsoft()
        {
            return Nsj.JsonConvert.DeserializeObject<Company>(_jsonStringContent);
        }

        [Benchmark(Description = "System.Text.Json: Deserialize")]
        public Company DeserializeSystemTextJson()
        {
            return Stj.JsonSerializer.Deserialize<Company>(_jsonStringContent);
        }
    }
}