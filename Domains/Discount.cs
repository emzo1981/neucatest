namespace ClassLibrary1;

public class Discount
{
    public int Id { get; set; }
    public required string Name { get; set; }
    
    public decimal Value => 5;
    public bool IsActive { get; set; }
   
}