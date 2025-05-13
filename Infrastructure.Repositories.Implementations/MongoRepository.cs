using Domain.Base;
using MongoDB.Driver;
using Services.Repositories;

namespace Infrastructure.Repositories.Implementations;

public class MongoRepository<T, TPrimaryKey> : 
IRepository<T, TPrimaryKey> where T
: class, IEntity<TPrimaryKey>
{
    private readonly IMongoCollection<T> _collection;

    public MongoRepository(IMongoDatabase database, string collectionName)
    {
        _collection = database.GetCollection<T>(collectionName);
    }
    
    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _collection.Find(Builders<T>.Filter.Empty).ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(TPrimaryKey id)
    {
        return await _collection.Find(Builders<T>.Filter.Eq<TPrimaryKey>(e => e.Id, id)).FirstOrDefaultAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public virtual async Task UpdateAsync(TPrimaryKey id, T entity)
    {
        await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq<TPrimaryKey>(e => e.Id, id), entity);
    }

    public virtual async Task DeleteAsync(TPrimaryKey id)
    {
        await _collection.DeleteOneAsync(Builders<T>.Filter.Eq(e => e.Id, id));
    }
}