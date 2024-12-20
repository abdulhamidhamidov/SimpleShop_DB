using Domain.Dtos;
using Infrostructure.Response;

namespace Infrostructure.Services;

public interface IQueryService
{
    public Task<Response<List<GetCountOfOrdersByDateDto>>> GetCountOfOrdersByDate();
    public Task<Response<GetMaxProductDto>> GetMaxProduct();
    public Task<Response<List<GetOrdersByStartAndEndDateDto>>> GetOrdersByStartAndEndDate(DateTime startDate,DateTime endDate);
    public Task<Response<GetSumOfOrderByProductIdDto>> GetSumOfOrderByProductId(int productId);
    public Task<Response<List<GetTenMinProductByStockDto>>> GetTenMinProductByStock();
    public Task<Response<List<GetTreeTopOrdersByOrderDto>>> GetTreeTopOrdersByOrder();
}