using System.Globalization;

namespace ExerciseFiles.Entities;

public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Product()
    {
    }

    public Product(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"{Name}, {TotalPrice(Price, Quantity).ToString("F2", CultureInfo.InvariantCulture)}";
    }

    public double TotalPrice(double price, int quantity)
    {
        return quantity * price;
    }
}