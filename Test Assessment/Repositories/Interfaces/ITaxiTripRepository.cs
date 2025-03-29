using Test_Assessment.DbModel;

namespace Test_Assessment.Repositories.Interfaces
{
    public interface ITaxiTripRepository
    {
        public Task<int> AddEntitiesAsync(IEnumerable<TaxiTrip> items);
    }
}
