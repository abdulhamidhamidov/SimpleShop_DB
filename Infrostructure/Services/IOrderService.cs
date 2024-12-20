using Domain.Dtos;
using Domain.Models;
using Infrostructure.Response;
namespace Infrostructure.Services;

public interface IOrderService
{
    public Task<Response<bool>> Create(CreateOrderDto order);
    public Task<Response<List<Order>>> GetAll();
    public Task<Response<Order>> GetById(int id);
    public Task<Response<bool>> Update(Order order);
    public Task<Response<bool>> Delete(int id);
}