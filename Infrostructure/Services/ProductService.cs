using System.Net;
using Dapper;
using Domain.Dtos;
using Domain.Models;
using Infrostructure.DataContext;
using Infrostructure.Response;

namespace Infrostructure.Services;

public class ProductService(IDapperContext dapperContext): IProductService
{
    public async Task<Response<bool>> Create(CreateOrderDto product)
    {
        using var connection = dapperContext.Connection();
        var sql = "insert into Products(Name, Stock) values (@Name, @Stock);";
        var res = await connection.ExecuteAsync(sql,product);
        if (res != 0) return new Response<bool>(res!=0);
        return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
    }

    public async Task<Response<List<Product>>> GetAll()
    {
        using var connection = dapperContext.Connection();
        var sql = "select * from Products;";
        var res = await connection.QueryAsync<Product>(sql);
        return new Response<List<Product>>(res.ToList());
    }

    public async Task<Response<Product>> GetById(int id)
    {
        using var connection = dapperContext.Connection();
        var sql = "select * from Products where Id=@Id;";
        var res = await connection.QueryFirstAsync<Product>(sql,new {Id=id});
        if (res != null) return new Response<Product>(res);
        return new Response<Product>(HttpStatusCode.NotFound, "Not Found");
    }

    public async Task<Response<bool>> Update(Product product)
    {
        using var connection = dapperContext.Connection();
        var sql = "update Products set Name=@Name, Stock=@Stock where Id=@Id;";
        var res = await connection.ExecuteAsync(sql,product);
        if (res != 0) return new Response<bool>(res!=0);
        return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
    }

    public async Task<Response<bool>> Delete(int id)
    {
        using var connection = dapperContext.Connection();
        var sql = "delete from Products where Id=@Id;";
        var res = await connection.ExecuteAsync(sql,new {Id=id});
        if (res != 0) return new Response<bool>(res!=0);
        return new Response<bool>(HttpStatusCode.NotFound, "Not Found");
    }
}