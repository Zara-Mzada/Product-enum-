namespace Products;

public class Product
{
    public enum Categories
    {
        Notebook,
        Phone
    }

    public Categories Category { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Product(Categories category, string brand, string model, decimal price, int quantity)
    {
        Category = category;
        Brand = brand;
        Model = model;
        Price = price;
        Quantity = quantity;
    }
}