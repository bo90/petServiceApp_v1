// using Domain.Base;
// using MongoDB.Driver;
// using Services.Repositories;
//
// namespace Infrastructure.Repositories.Implementations;
//
// public abstract class Repository<T, TPrimaryKey> : 
//     IRepository<T, TPrimaryKey> where T
//     : class, IEntity<TPrimaryKey>
// {
//     private readonly IMongoCollection<T> _collection;
//
//     public Repository(IMongoDatabase database, string collectionName)
//     {
//         _collection = database.GetCollection<T>(collectionName);
//     }
//     
//     public virtual T Add(T entity)
//     {
//         _collection.InsertOne(entity);
//         return entity;
//     }
//
//     public virtual async Task<T> AddAsync(T entity)
//     {
//         await _collection.InsertOneAsync(entity);
//         return entity;
//     }
//
//     public virtual void SaveChanges()
//     {
//         return;
//     }
//
//     public virtual async Task SaveChangesAsync(CancellationToken token = default)
//     {
//         return;
//     }
//
//     public virtual void Update(T entity)
//     {
//         _collection.ReplaceOne(Builders<T>.Filter.Eq("_id", entity.Id), entity);
//     }
//
//     public virtual bool Delete(T entity)
//     {
//         _collection.DeleteOne(Builders<T>.Filter.Eq("_id", entity.Id));
//         return true;
//     }
//
//     public virtual bool Delete(TPrimaryKey id)
//     {
//         _collection.DeleteOne(Builders<T>.Filter.Eq("_id", id));
//         return true;
//     }
//
//     public Task<T> GetAsync(TPrimaryKey id, CancellationToken token = default)
//     {
//         throw new NotImplementedException();
//     }
//
//     public T Get(TPrimaryKey id)
//     {
//         throw new NotImplementedException();
//     }
//
//     public IQueryable<T> GetAll(bool noTracking = false)
//     {
//         throw new NotImplementedException();
//     }
//
//     public Task<List<T>> GetAllAsync(bool noTracking = false, CancellationToken token = default)
//     {
//         throw new NotImplementedException();
//     }
// }