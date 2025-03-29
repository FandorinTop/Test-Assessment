using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Test_Assessment.CSVLogic
{
    public static class CsvFileHelper
    {
        public static async Task AppendCsvAsync<T>(IEnumerable<T> records, string filePath)
        {
            if (!File.Exists(filePath))
            {
                await CreateFileAsync(filePath, records);
            }
            else
            {
                await AppendToFileAsync(filePath, records);
            }
        }

        private static async Task AppendToFileAsync<T>(string filePath, IEnumerable<T> records)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                // Don't write the header again.
                HasHeaderRecord = false,
            };

            using var stream = File.Open(filePath, FileMode.Append);
            using var writer = new StreamWriter(stream);
            using var csv = new CsvWriter(writer, config);
            await csv.WriteRecordsAsync(records);
        }

        private static async Task CreateFileAsync<T>(string filePath, IEnumerable<T> records)
        {
            using var writer = new StreamWriter(filePath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteHeader<T>();
            await csv.WriteRecordsAsync(records);
        }
    }
}
