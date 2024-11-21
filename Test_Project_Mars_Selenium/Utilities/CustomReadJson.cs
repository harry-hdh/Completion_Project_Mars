using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Test_Project_Mars_Selenium.Utilities
{
    public class CustomReadJson
    {
        public static IEnumerable<T> LoadJson<T>(string fileName)
        {
            try
            {
                var jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                var jsonString = File.ReadAllText(jsonPath);
                return JsonSerializer.Deserialize<List<T>>(jsonString) ?? Enumerable.Empty<T>();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to load test data from {fileName}: {ex.Message}", ex);
            }

        }
    }
}
