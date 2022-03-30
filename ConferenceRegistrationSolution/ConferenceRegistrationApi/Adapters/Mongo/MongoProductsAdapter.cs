using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ConferenceRegistrationApi.Adapters.Mongo;

public class MongoProductsAdapter
{

    private readonly IMongoCollection<Product> _productsCollection;
    public MongoProductsAdapter(IOptions<ProductsSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _productsCollection = mongoDatabase.GetCollection<Product>(settings.Value.CollectionName);
    }

    public async Task<List<Product>> GetAllAsync() => await _productsCollection.Find(_ => true).ToListAsync();

    public async Task<Product> GetProductById(string id) => await _productsCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
}
