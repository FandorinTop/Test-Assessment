using Test_Assessment.Wrapper;

namespace Test_Assessment.Services.Interfaces
{
    public interface ITaxiTripService
    {
        public Task<int> AddAsync(IEnumerable<TaxiTripWrapper> items);
    }
}
