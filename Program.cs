using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConverterToJson
{
    public class Program
    {
        static void Main(string[] args)
        {
            string csvFilePath = @"C:\Folder\file.csv";
            string jsonFilePath = @"C:\Folder\file.json";

            var lines = File.ReadAllLines(csvFilePath);
            var list = new List<Dictionary<string, string>>();

            string[] headers = lines[0].Split(',');

            for (int i = 1; i < lines.Length; i++)
            {
                var obj = new Dictionary<string, string>();
                string[] values = lines[i].Split(',');

                for (int j = 0; j < headers.Length; j++)
                {
                    obj.Add(headers[j].Trim(), values[j].Trim());
                }

                list.Add(obj);
            }

            string json = JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFilePath, json);

            Console.WriteLine("Complete with success!");
        }

}
}
