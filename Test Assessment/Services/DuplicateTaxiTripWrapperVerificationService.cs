using Test_Assessment.DbModel;
using Test_Assessment.Services.Interfaces;
using Test_Assessment.Storage.Interfaces;
using Test_Assessment.Wrapper;

namespace Test_Assessment.Services
{

    public class DuplicateTaxiTripWrapperVerificationService
    {
        private readonly IUniqKeyValueStorage<int> storage;

        public DuplicateTaxiTripWrapperVerificationService(IUniqKeyValueStorage<int> storage)
        {
            this.storage = storage;
        }

        public async Task<DuplicateResponse<TaxiTripWrapper>> SearchForDuplicateAsync(IEnumerable<TaxiTripWrapper> items)
        {
            var result = new DuplicateResponse<TaxiTripWrapper>();
            var duplicateInItems = new List<TaxiTripWrapper>();
            var uniqInItems = new List<TaxiTripWrapper>();

            foreach (var item in items)
            {
                var combine = CombineForHash(item);

                if (await storage.ContainKeyAsync(combine))
                {
                    duplicateInItems.Add(item);
                    int count = await storage.GetValueAsync(combine);
                    await storage.SetValueAsync(combine, count);
                }
                else
                {
                    await storage.SetValueAsync(combine, 1);
                    uniqInItems.Add(item);
                }
            }

            result.DuplicatedItems = duplicateInItems;
            result.UniqItems = uniqInItems;

            return result;
        }

        private static string CombineForHash(TaxiTripWrapper item)
        {
            return $"{item?.TpepPickupDatetime.ToString() ?? string.Empty}{item?.TpepDropoffDatetime.ToString() ?? string.Empty}{item?.PassengerCount.ToString() ?? string.Empty}";
        }
    }
}
