using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

public class SharedDictionaryService<TKey, TEntity>
{
    // Dicionário compartilhado seguro para acesso concorrente
    private readonly ConcurrentDictionary<TKey, IEnumerable<TEntity>> _dictionary;

    // Singleton da classe
    private static SharedDictionaryService<TKey, TEntity> _instance;
    private static readonly object _lock = new object();

    // Construtor privado para evitar múltiplas instâncias
    private SharedDictionaryService()
    {
        _dictionary = new ConcurrentDictionary<TKey, IEnumerable<TEntity>>();
    }

    // Método para obter a instância Singleton
    public static SharedDictionaryService<TKey, TEntity> Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SharedDictionaryService<TKey, TEntity>();
                    }
                }
            }
            return _instance;
        }
    }

    // Método para adicionar ou atualizar um valor
    public void AddOrUpdate(TKey key, IEnumerable<TEntity> entities)
    {
        _dictionary.AddOrUpdate(key, entities, (k, oldValue) => entities);
    }

    // Método para obter os valores pelo chave
    public bool TryGetValue(TKey key, out IEnumerable<TEntity> entities)
    {
        return _dictionary.TryGetValue(key, out entities);
    }

    // Método para remover uma entrada do dicionário
    public bool TryRemove(TKey key)
    {
        return _dictionary.TryRemove(key, out _);
    }

    // Método para verificar se uma chave existe
    public bool ContainsKey(TKey key)
    {
        return _dictionary.ContainsKey(key);
    }

    // Método para listar todas as entradas
    public void PrintAllEntries()
    {
        foreach (var entry in _dictionary)
        {
            Console.WriteLine($"Key: {entry.Key}, Values: {string.Join(", ", entry.Value)}");
        }
    }
}
