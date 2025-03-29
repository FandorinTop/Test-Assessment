using Test_Assessment.DataAccess;
using Test_Assessment.DbModel;
using Test_Assessment.Repositories.Interfaces;

namespace Test_Assessment.Repositories
{
    public class TaxiTripRepository : ITaxiTripRepository
    {
        private readonly ApplicationDbContext _context;

        public TaxiTripRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddEntitiesAsync(IEnumerable<TaxiTrip> items)
        {
            await _context.TaxiTrips.AddRangeAsync(items);
            var count = await _context.SaveChangesAsync();

            return count;
        }
    }
}
