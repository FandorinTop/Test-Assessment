using System.ComponentModel.DataAnnotations;

namespace Test_Assessment.DbModel
{
    public class TaxiTrip : BaseEntity
    {
        public DateTime TpepPickupDatetime { get; set; }

        public DateTime TpepDropoffDatetime { get; set; }

        public int PassengerCount { get; set; }

        public double TripDistance { get; set; }

        [Required]
        [MaxLength(3)]
        public string StoreAndFwdFlag { get; set; } = default!;

        public int PULocationID { get; set; }

        public int DOLocationID { get; set; }

        public decimal FareAmount { get; set; }

        public decimal TipAmount { get; set; }
    }
}
