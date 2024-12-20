namespace Domain.Dtos;

public class CreateOrderDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
}