using CsvHelper;
using System.Globalization;

namespace Test_Assessment.CSVLogic
{
    public class CsvExtractor<T>
    {
        public string FilePath { get; private set; }

        public CsvExtractor(string filePath)
        {
            FilePath = filePath;
        }

        public async Task<IReadOnlyList<T>> ExtractAsync(int offset = 0, int buffer = 500)
        {
            var list = new List<T>();

            using (var reader = new StreamReader(FilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                await csv.ReadAsync();
                csv.ReadHeader();

                for (int i = 0; i < offset; i++)
                {
                    await csv.ReadAsync();
                }

                for (int i = offset; i < buffer + offset; i++)
                {
                    if(await csv.ReadAsync())
                        list.Add(csv.GetRecord<T>());
                }
            }

            return list;
        }
    }
}
