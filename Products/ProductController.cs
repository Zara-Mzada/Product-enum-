using System.Collections;

namespace Products;

public class ProductController
{
    public ArrayList Products { get; set; }

    public ProductController()
    {
        Products = new ArrayList();
    }
    
    // Add function
    public void AddProduct(Product product)
    {
        Products.Add(product);
    }
    
    // Show all products function
    public void ShowAllProducts()
    {
        int id = 1;
        foreach (Product product in Products)
        {
            Console.WriteLine(
                $"Product ID: {id}\n" +
                $"Category: {product.Category}\n" +
                $"Brand: {product.Brand}\n" +
                $"Model: {product.Model}\n" +
                $"Price: {product.Price}\n" +
                $"Quantity: {product.Quantity}\n" +
                $"==============================\n" +
                $"==============================");
            id++;
        }
    }
    
    // Show product by category
    public void ShowProductsOfNotebook()
    {
        int id = 1;
        foreach (Product product in Products)
        {
            if (product.Category.ToString() == "Notebook")
            {
                Console.WriteLine(
                    "==============================\n" +
                    $"Product ID: {id}\n" +
                    $"Category: {Product.Categories.Notebook}\n" +
                    $"Brand: {product.Brand}\n" +
                    $"Model: {product.Model}\n" +
                    $"Price: {product.Price}\n" +
                    $"Quantity: {product.Quantity}\n" +
                    $"==============================\n");
                id++;
            }
        }
    }

    public void ShowProductsOfPhone()
    {
        int id = 1;
        foreach (Product product in Products)
        {
            if (product.Category.ToString() == "Phone")
            {
                Console.WriteLine(
                    $"Product ID: {id}\n" +
                    $"Category: {Product.Categories.Phone}\n" +
                    $"Brand: {product.Brand}\n" +
                    $"Model: {product.Model}\n" +
                    $"Price: {product.Price}\n" +
                    $"Quantity: {product.Quantity}\n" +
                    $"==============================\n" +
                    $"==============================");
                id++;
            }
        }
    }
    
    // Update full product
    public void UpdateFullProduct(int productID, Product product)
    {
        Products[productID - 1] = product;
        Console.WriteLine(product);
    }
    
    // Update by property
    public void UpdateProductByCategory(int id, Product.Categories newCategory)
    {
        Product curentProduct = (Product)Products[id - 1];
        curentProduct.Category = newCategory;
    }

    public void UpdateProductByBrand(int id, string newValue)
    {
        Product curentProduct = (Product)Products[id - 1];
        curentProduct.Brand = newValue;
    }
    
    public void UpdateProductByModel(int id, string newValue)
    {
        Product curentProduct = (Product)Products[id - 1];
        curentProduct.Model = newValue;
    }    
    
    public void UpdateProductByPrice(int id, decimal newValue)
    {
        Product curentProduct = (Product)Products[id - 1];
        curentProduct.Price = newValue;
    }    
    
    public void UpdateProductByQuantity(int id, int newValue)
    {
        Product curentProduct = (Product)Products[id - 1];
        curentProduct.Quantity = newValue;
    }   
    
    // Remove product
    public void RemoveProduct(int id)
    {
        Products.RemoveAt(id-1);
    }
    
    // Sell product
    public bool SellProduct(int id, int sellAmount)
    {
        Product currProduct = (Product)Products[id - 1];
        if (currProduct.Quantity >= sellAmount)
        {
            currProduct.Quantity -= sellAmount;
            return true;
        }

        return false;
    }
}