using Test_Assessment.Mapper;
using Test_Assessment.Repositories.Interfaces;
using Test_Assessment.Services.Interfaces;
using Test_Assessment.Wrapper;

namespace Test_Assessment.Services
{
    public class TaxiTripService : ITaxiTripService
    {
        readonly private ITaxiTripRepository repository;

        public TaxiTripService(ITaxiTripRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddAsync(IEnumerable<TaxiTripWrapper> items)
        {
            var entities = items.Map();

            return await repository.AddEntitiesAsync(entities);
        }
    }
}
