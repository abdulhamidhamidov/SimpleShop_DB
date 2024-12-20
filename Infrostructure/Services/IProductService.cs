using Domain.Dtos;
using Domain.Models;
using Infrostructure.Response;

namespace Infrostructure.Services;

public interface IProductService
{
    public Task<Response<bool>> Create(CreateOrderDto product);
    public Task<Response<List<Product>>> GetAll();
    public Task<Response<Product>> GetById(int id);
    public Task<Response<bool>> Update(Product product);
    public Task<Response<bool>> Delete(int id);
}