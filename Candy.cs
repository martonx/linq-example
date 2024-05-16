namespace CandyStat;

public class Candy
{
    public Candy(int id, string name, int quantity, int unitPrice)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int UnitPrice { get; set; }
    public int StockValue => Quantity * UnitPrice;
}
