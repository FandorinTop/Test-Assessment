using CsvHelper.Configuration.Attributes;
using System.Globalization;

namespace Test_Assessment.Wrapper
{
    public record TaxiTripWrapper
    {
        [Name("VendorID")]
        public int? VendorID { get; set; }

        [DateTimeStyles(DateTimeStyles.AllowInnerWhite | DateTimeStyles.RoundtripKind)]
        [Name("tpep_pickup_datetime")]
        public DateTime? TpepPickupDatetime { get; set; }

        [DateTimeStyles(DateTimeStyles.AllowInnerWhite | DateTimeStyles.RoundtripKind)]
        [Name("tpep_dropoff_datetime")]
        public DateTime? TpepDropoffDatetime { get; set; }

        [Name("passenger_count")]
        public int? PassengerCount { get; set; }

        [Name("trip_distance")]
        public double? TripDistance { get; set; }

        [Name("RatecodeID")]
        public int? RatecodeID { get; set; }

        [Name("store_and_fwd_flag")]
        public string? StoreAndFwdFlag { get; set; }

        [Name("PULocationID")]
        public int? PULocationID { get; set; }

        [Name("DOLocationID")]
        public int? DOLocationID { get; set; }

        [Name("payment_type")]
        public int? PaymentType { get; set; }

        [Name("fare_amount")]
        public decimal? FareAmount { get; set; }

        [Name("extra")]
        public decimal? Extra { get; set; }

        [Name("mta_tax")]
        public decimal? MtaTax { get; set; }

        [Name("tip_amount")]
        public decimal? TipAmount { get; set; }

        [Name("tolls_amount")]
        public decimal? TollsAmount { get; set; }

        [Name("improvement_surcharge")]
        public decimal? ImprovementSurcharge { get; set; }

        [Name("total_amount")]
        public decimal? TotalAmount { get; set; }

        [Name("congestion_surcharge")]
        public decimal? CongestionSurcharge { get; set; }
    }
}
