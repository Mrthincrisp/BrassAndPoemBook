public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int ID { get; set; }
    public ProductType? ProductType { get; set; }

    public Product(string name, decimal price, int id, ProductType productType)
    {
        Name = name;
        Price = price;
        ID = id;
        ProductType = productType;
    }
}