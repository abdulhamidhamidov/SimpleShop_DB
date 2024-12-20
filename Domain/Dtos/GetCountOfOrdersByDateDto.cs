namespace Domain.Dtos;

public class GetCountOfOrdersByDateDto
{
    public DateTime Date { get; set; }
    public int TotalOrder { get; set; }
}