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

        public IReadOnlyList<T> Extract(int offset = 0, int buffer = 500)
        {
            var list = new List<T>();

            using (var reader = new StreamReader(FilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();

                for (int i = 0; i < offset; i++)
                {
                    csv.Read();
                }

                for (int i = offset; i < buffer + offset; i++)
                {
                    csv.Read();
                    list.Add(csv.GetRecord<T>());
                }
            }

            return list;
        }
    }
}
