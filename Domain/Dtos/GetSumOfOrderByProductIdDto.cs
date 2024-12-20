namespace Domain.Dtos;

public class GetSumOfOrderByProductIdDto
{
    public int  ProductId { get; set; }
    public int TotalQuantity { get; set; }
    public decimal TotalPrice { get; set; }
}