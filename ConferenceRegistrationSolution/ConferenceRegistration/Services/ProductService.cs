using ConferenceRegistration.Adapters;
using ConferenceRegistration.Adapters.Mongo;
using ConferenceRegistration.Controllers;
using ConferenceRegistration.Models;

namespace ConferenceRegistrationApi.Services;
public class ProductService : IProductsService
{
    private readonly MarkupServiceAmountPort _amountPort;

    private readonly MongoProductsAdapter _mongoAdapter;

    public ProductService(MarkupServiceAmountPort amountPort, MongoProductsAdapter mongoAdapter)
    {
        _amountPort = amountPort;
        _mongoAdapter = mongoAdapter;
    }

    public async Task<GetProductsResponse> GetAllProductsAsync()
    {
        var products = await _mongoAdapter.GetAllAsync();
        var markup = await _amountPort.GetMarkupAmountAsync();

        var productsConverted = products.Select(p => new ProductInformationResponse(p.Id, p.Name, p.Cost * markup)).ToList();

        return new GetProductsResponse(productsConverted);
    }

    public async Task<ProductInformationResponse> GetProductAsync(string id)
    {
        // this may need many different port/adapters. Some of the information may come from a database, etc.



        var markup = await _amountPort.GetMarkupAmountAsync();
        // all the code to get the real product, etc.



        return new ProductInformationResponse(id.ToString(), "Cheese", 7.99M * (1 + markup));
    }
}