using Test_Assessment.CSVLogic;
using Test_Assessment.DataAccess;
using Test_Assessment.Repositories;
using Test_Assessment.Services;
using Test_Assessment.Storage;
using Test_Assessment.Wrapper;

namespace Test_Assessment
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var filePath = @"C:\Users\Shewc\Desktop\testTask\sample-cab-data.csv";
            var outPath = @"C:\Users\Shewc\Desktop\testTask\out-cab-data.csv";
            File.Delete(outPath);
            int batchSize = 500;

            IReadOnlyList<TaxiTripWrapper> taxiTripWrappers = new List<TaxiTripWrapper>();
            var csvExtractor = new CsvExtractor<TaxiTripWrapper>(filePath);
            var duplicateSearcher = new DuplicateTaxiTripWrapperVerificationService(new DummyDictionaryStorage<int>());

            for (int i = 0; taxiTripWrappers.Count > 0 || i == 0; i++)
            {
                taxiTripWrappers = await csvExtractor.ExtractAsync(i * batchSize, batchSize);
                var result = await duplicateSearcher.SearchForDuplicateAsync(taxiTripWrappers);

                await CsvFileHelper.AppendCsvAsync(result.DuplicatedItems, outPath);

                using(ApplicationDbContext context = new ApplicationDbContext())
                {
                    var taxiTripService = new TaxiTripService(new TaxiTripRepository(context));

                    await taxiTripService.AddAsync(result.UniqItems);
                }
            }
        }
    }
}
