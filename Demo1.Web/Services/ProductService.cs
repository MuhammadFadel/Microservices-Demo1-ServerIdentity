using Demo1.Web.Models;
using Demo1.Web.Services.IServices;

namespace Demo1.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> CreateProductAsync<T>(ProductCreateDto productCreateDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = productCreateDto,
                ApiUrl = SD.ProductApiBase + "/api/products",
                AccessToken = token
            });
        }

        public async Task<T> DeleteProductAsync<T>(Guid id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,                
                ApiUrl = SD.ProductApiBase + "/api/products/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetProductByIdAsync<T>(Guid id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.ProductApiBase + "/api/products/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetProductsAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.ProductApiBase + "/api/products",
                AccessToken = token
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductCreateDto productCreateDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = productCreateDto,
                ApiUrl = SD.ProductApiBase + "/api/products",
                AccessToken = token
            });
        }
    }
}
