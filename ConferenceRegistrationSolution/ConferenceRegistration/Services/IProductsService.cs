using ConferenceRegistration.Models;

namespace ConferenceRegistration.Controllers
{
    public interface IProductsService
    {
        Task<ProductInformationResponse> GetProductAsync(string id);
        Task<GetProductsResponse> GetAllProductsAsync();
    }
}