namespace Test_Assessment.Storage.Interfaces
{
    public interface IUniqKeyValueStorage<T>
    {
        public Task<bool> ContainKeyAsync(string key);

        public Task SetValueAsync(string key, T value);

        public Task<T> GetValueAsync(string key);
    }
}
