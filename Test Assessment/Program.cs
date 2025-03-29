using Test_Assessment.CSVLogic;
using Test_Assessment.DataAccess;
using Test_Assessment.Repositories;
using Test_Assessment.Services;
using Test_Assessment.Storage;
using Test_Assessment.Wrapper;

namespace Test_Assessment
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            var totalAmountOfUploadedField = 0;

            #region Configuration
            //Path to file with data
            var filePath = @"C:\Users\Shewc\Desktop\testTask\sample-cab-data.csv";

            //Path to file with duplicats
            var outPath = @"C:\Users\Shewc\Desktop\testTask\out-cab-data.csv";
            File.Delete(outPath);

            //Size of batch for reading from CSV
            int batchSize = 1000;
            #endregion

            IReadOnlyList<TaxiTripWrapper> taxiTripWrappers = [];
            var csvExtractor = new CsvExtractor<TaxiTripWrapper>(filePath);
            var duplicateSearcher = new DuplicateTaxiTripWrapperVerificationService(new DummyDictionaryStorage<int>());

            for (int i = 0; taxiTripWrappers.Count > 0 || i == 0; i++)
            {
                //Extract data from CSV file
                taxiTripWrappers = await csvExtractor.ExtractAsync(i * batchSize, batchSize);

                //searching for duplicate
                var result = await duplicateSearcher.SearchForDuplicateAsync(taxiTripWrappers);

                //writing duplicate in csv file
                await CsvFileHelper.AppendCsvAsync(result.DuplicatedItems, outPath);

                //creating new connection to db and creating service for uploading data
                using ApplicationDbContext context = new();
                var taxiTripService = new TaxiTripService(new TaxiTripRepository(context));

                var amount = await taxiTripService.AddAsync(result.UniqItems);
                totalAmountOfUploadedField += amount;
            }

            Console.WriteLine($"Total amount of uploaded fields is: " + totalAmountOfUploadedField);
        }
    }
}
