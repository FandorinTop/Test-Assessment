namespace Test_Assessment.Services.Interfaces
{
    public interface IDuplicateVerifier<T>
    {
        public Task<DuplicateResponse<T>> SearchForDuplicateAsync(IEnumerable<T> items);
    }
}
