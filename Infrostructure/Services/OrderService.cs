using System.Net;
using Dapper;
using Domain.Dtos;
using Domain.Models;
using Infrostructure.DataContext;
using Infrostructure.Response;

namespace Infrostructure.Services;

public class OrderService(IDapperContext dapperContext) : IOrderService
{
    public async Task<Response<bool>> Create(CreateOrderDto order)
    {
        using var connection = dapperContext.Connection();
        var sql = "insert into Orders( ProductId, Quantity, TotalPrice, OrderDate) values ( @ProductId, @Quantity,(select Price from Products where id = @ProductId)*@Quantity, @OrderDate));";
        var res = await connection.ExecuteAsync(sql,order);
        if (res != 0) return new Response<bool>(res!=0);
        return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
    }

    public async Task<Response<List<Order>>> GetAll()
    {
        using var connection = dapperContext.Connection();
        var sql = "select * from Orders;";
        var res = await connection.QueryAsync<Order>(sql);
        return new Response<List<Order>>(res.ToList());
    }

    public async Task<Response<Order>> GetById(int id)
    {
        using var connection = dapperContext.Connection();
        var sql = "select * from Orders where Id=@Id;";
        var res = await connection.QueryFirstAsync<Order>(sql,new {Id=id});
        if (res != null) return new Response<Order>(res);
        return new Response<Order>(HttpStatusCode.NotFound, "Not Found");    }

    public async Task<Response<bool>> Update(Order order)
    {
        using var connection = dapperContext.Connection();
        var sql = "update Orders set ProductId=@ProductId, Quantity=@Quantity, TotalPrice=@TotalPrice,OrderDate=@OrderDate where Id=@Id;";
        var res = await connection.ExecuteAsync(sql,order);
        if (res != 0) return new Response<bool>(res!=0);
        return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
    }

    public async Task<Response<bool>> Delete(int id)
    {
        using var connection = dapperContext.Connection();
        var sql = "delete from Orders where Id=@Id;";
        var res = await connection.ExecuteAsync(sql,new {Id=id});
        if (res != 0) return new Response<bool>(res!=0);
        return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
    }
}