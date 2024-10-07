using Domain.Models;
using System.Collections.Concurrent;

public class CacheService
{
    // Definindo o cache compartilhado como um ConcurrentDictionary
    private ConcurrentDictionary<string, CacheItem<IEnumerable<TaskViewModel>>> _cache;

    public CacheService()
    {
        _cache = new ConcurrentDictionary<string, CacheItem<IEnumerable<TaskViewModel>>>();
    }

    // Método para obter os dados do cache
    public bool TryGetCachedItem(string key, out CacheItem<IEnumerable<TaskViewModel>> cachedItem)
    {
        return _cache.TryGetValue(key, out cachedItem);
    }

    // Método para adicionar ou atualizar itens no cache
    public void AddOrUpdateCache(string key, CacheItem<IEnumerable<TaskViewModel>> cacheItem)
    {
        _cache[key] = cacheItem;
    }

    // Método para limpar cache (opcional)
    public void ClearCache(string key)
    {
        _cache.TryRemove(key, out _);
    }

    public class CacheItem<T>
    {
        public T Data { get; set; }
        public DateTime Expiration { get; set; }
    }
}
