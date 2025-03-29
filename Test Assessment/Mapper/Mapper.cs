using Test_Assessment.Common;
using Test_Assessment.DbModel;
using Test_Assessment.Wrapper;

namespace Test_Assessment.Mapper
{
    public static class Mapper
    {
        public static TaxiTrip Map(this TaxiTripWrapper item)
        {
            return new TaxiTrip()
            {
                FareAmount = item.FareAmount,
                StoreAndFwdFlag = string.IsNullOrWhiteSpace(item.StoreAndFwdFlag)
                    ? item.StoreAndFwdFlag
                    : Helper.ConvertStoreAndFwdFlag(item.StoreAndFwdFlag),
                TipAmount = item.TipAmount,
                DOLocationID = item.DOLocationID,
                PassengerCount = item.PassengerCount,
                PULocationID = item.PULocationID,
                TripDistance = item.TripDistance,
                TpepDropoffDatetime = item.TpepDropoffDatetime is null ? item.TpepDropoffDatetime : Helper.FromEstToUtc(item.TpepDropoffDatetime.Value),
                TpepPickupDatetime = item.TpepPickupDatetime is null ? item.TpepPickupDatetime : Helper.FromEstToUtc(item.TpepPickupDatetime.Value)
            };
        }

        public static IEnumerable<TaxiTrip> Map(this IEnumerable<TaxiTripWrapper> items)
        {
            foreach (var item in items)
            {
                yield return item.Map();
            }
        }
    }
}
