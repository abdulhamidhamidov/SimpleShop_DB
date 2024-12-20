namespace Domain.Dtos;

public class GetOrdersByStartAndEndDateDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}