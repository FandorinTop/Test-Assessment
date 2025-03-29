namespace Test_Assessment.Common
{
    public static class Helper
    {
        public static bool IsValidString(string? val) => !string.IsNullOrWhiteSpace(val);

        public static string CleanString(string val) => val.Trim();

        public static DateTime FromEstToUtc(string est) => FromEstToUtc(Convert.ToDateTime(est));

        public static DateTime FromEstToUtc(DateTime est) => TimeZoneInfo.ConvertTimeToUtc(est, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));

        public static string ConvertStoreAndFwdFlag(string val)
        {
            return val switch
            {
                "N" => "No",
                "Y" => "Yes",
                _ => throw new ArgumentException("Flag can have only N/Y values", nameof(val)),
            };
        }
    }
}
