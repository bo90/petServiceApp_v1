using Domain.Entity;
using MongoDB.Driver;
using Services.Repositories;

namespace Infrastructure.Repositories.Implementations;

public class BeastRepository : MongoRepository<Beast, Guid>, IBeastRepository
{
    public BeastRepository(IMongoDatabase database, string collectionName) : base(database, collectionName)
    {
    }
}