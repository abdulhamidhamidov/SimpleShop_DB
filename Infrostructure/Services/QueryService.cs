using Dapper;
using Domain.Dtos;
using Domain.Models;
using Infrostructure.DataContext;
using Infrostructure.Response;

namespace Infrostructure.Services;

public class QueryService(IDapperContext dapperContext): IQueryService
{
    public async Task<Response<List<GetCountOfOrdersByDateDto>>> GetCountOfOrdersByDate()
    {
        using var connection = dapperContext.Connection();
        var sql = "select * from Orders;";
        var res = await connection.QueryAsync<GetCountOfOrdersByDateDto>(sql);
        return new Response<List<GetCountOfOrdersByDateDto>>(res.ToList());
    }

    public async Task<Response<GetMaxProductDto>> GetMaxProduct()
    {
        using var connection = dapperContext.Connection();
        var sql = "select Id,Name,Price from Products where Price=(select max(Price) from Products)\n";
        var res = await connection.QuerySingleAsync<GetMaxProductDto>(sql);
        return new Response<GetMaxProductDto>(res);
    }

    public async Task<Response<List<GetOrdersByStartAndEndDateDto>>> GetOrdersByStartAndEndDate(DateTime startDate, DateTime endDate)
    {
        using var connection = dapperContext.Connection();
        var sql = "select Id, ProductId, TotalPrice, OrderDate from Orders where OrderDate>=@StratDate and OrderDate<=@EndDate";
        var res = await connection.QueryAsync<GetOrdersByStartAndEndDateDto>(sql,new {StratDate= startDate,EndDate=endDate});
        return new Response<List<GetOrdersByStartAndEndDateDto>>(res.ToList());
    }

    public async Task<Response<GetSumOfOrderByProductIdDto>> GetSumOfOrderByProductId(int productId)
    {
        using var connection = dapperContext.Connection();
        var sql = "select ProductId,Sum(Quantity) as TotalQuantity,Sum(TotalPrice) as TotalPrice from Orders where ProductId=@ProductId group by  ProductId ;";
        var res = await connection.QuerySingleAsync<GetSumOfOrderByProductIdDto>(sql,new {ProductId=productId});
        return new Response<GetSumOfOrderByProductIdDto>(res);   
    }

    public async Task<Response<List<GetTenMinProductByStockDto>>> GetTenMinProductByStock()
    {
        using var connection = dapperContext.Connection();
        var sql = "select Id,Name,Stock from Products where Stock<10;";
        var res = await connection.QueryAsync<GetTenMinProductByStockDto>(sql);
        return new Response<List<GetTenMinProductByStockDto>>(res.ToList());
    }

    public async Task<Response<List<GetTreeTopOrdersByOrderDto>>> GetTreeTopOrdersByOrder()
    {
        using var connection = dapperContext.Connection();
        var sql = "select p.Id, p.Name, Count(o.Id) as TotalOrders from Products p join Orders o on o.ProductId=p.Id group by p.Id,p.Name order by TotalOrders limit 3";
        var res = await connection.QueryAsync<GetTreeTopOrdersByOrderDto>(sql);
        return new Response<List<GetTreeTopOrdersByOrderDto>>(res.ToList());
        
    }
}