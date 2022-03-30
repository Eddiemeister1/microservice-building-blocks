namespace ConferenceRegistrationApi.Services;

public interface IProductsService
{
    Task<ProductInformationResponse> GetProductAsync(string id);
    Task<GetProductsResponse> GetAllProductsAsync();
}
