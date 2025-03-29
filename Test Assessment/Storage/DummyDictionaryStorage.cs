﻿using Test_Assessment.Storage.Interfaces;

namespace Test_Assessment.Storage
{
    public class DummyDictionaryStorage<T> : IUniqKeyValueStorage<T>
    {
        private readonly Dictionary<string, T> totalSetOfDuplicates = new Dictionary<string, T>();

        public Task SetValueAsync(string key, T value)
        {
            if (!totalSetOfDuplicates.ContainsKey(key))
            {
                totalSetOfDuplicates.Add(key, value);
            }
            else
            {
                totalSetOfDuplicates[key] = value;
            }

            return Task.CompletedTask;
        }

        public Task<bool> ContainKeyAsync(string key)
        {
            return Task.FromResult(totalSetOfDuplicates.ContainsKey(key));
        }

        public Task<T> GetValueAsync(string key)
        {
            return Task.FromResult(totalSetOfDuplicates[key]);
        }
    }
}
