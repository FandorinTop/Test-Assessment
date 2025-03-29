namespace Test_Assessment.Services.Interfaces
{
    public class DuplicateResponse<T>
    {
        public IReadOnlyCollection<T> DuplicatedItems { get; set; } = [];

        public IReadOnlyList<T> UniqItems { get; set; } = [];
    }
}
