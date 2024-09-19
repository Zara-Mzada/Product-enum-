using System;

namespace Products
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductController productController = new ProductController();

            Product product1 = new Product(Product.Categories.Notebook, "Apple", "Macbook Air", 2000, 8);
            Product product2 = new Product(Product.Categories.Phone, "Samsung", "A52", 800, 4);
            Product product3 = new Product(Product.Categories.Notebook, "Asus", "Zenbook", 3000, 5);
            Product product4 = new Product(Product.Categories.Phone, "Iphone", "15 Pro Max", 3600, 3);
            
            // Adding products
            productController.AddProduct(product1);
            productController.AddProduct(product2);
            productController.AddProduct(product3);
            productController.AddProduct(product4);

            ReEnter:
            // Console.Clear();
            Console.WriteLine("Welcome! Choose a number:\n" +
                              $"1. Add product\n" +
                              $"2. Show products\n" +
                              $"3. Update product\n" +
                              $"4. Remove product\n" +
                              $"5. Sell product");
            var userChoice = Console.ReadLine();
            int a;
            bool checkChoice = int.TryParse(userChoice, out a);
            
            if (checkChoice)
            {
                if (Convert.ToInt32(userChoice) == 1)
                {
                    ReCategory:
                    Console.Write("Please, fill gaps:\n" +
                                      "Category: ");
                    string category = Console.ReadLine();
                    
                    Console.Write("Brand: ");
                    string brand = Console.ReadLine();

                    Console.Write("Model: ");
                    string model = Console.ReadLine();
                    
                    RePrice:
                    Console.Write("Price: ");
                    var rawprice = Console.ReadLine();
                    decimal b;
                    bool checkPrice = decimal.TryParse(rawprice, out b);
                    decimal price;
                    if (checkPrice)
                    {
                        price = Convert.ToDecimal(rawprice);
                        if (price <= 0)
                        {
                            Console.WriteLine("Price can't be 0 or less than  0!");
                            goto RePrice;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Price must be number!");
                        goto RePrice;
                    }
                    
                    ReQuantity:
                    Console.Write("Quantity: ");
                    var rawquantity =Console.ReadLine();
                    int c;
                    bool checkQuantity = int.TryParse(rawquantity, out c);
                    int quantity = 0;

                    if (checkQuantity)
                    {
                        quantity = Convert.ToInt32(rawquantity);
                        if (quantity <= 0)
                        {
                            Console.WriteLine("Quantity can't be 0");
                            goto ReQuantity;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Quantity must be integer number!");
                        goto ReQuantity;
                    }
                    
                    
                    if (category == "Notebook")
                    {
                        productController.AddProduct(new Product(Product.Categories.Notebook, brand, model, price, quantity));
                    }
                    else if (category == "Phone")
                    {
                        productController.AddProduct(new Product(Product.Categories.Phone, brand, model, price, quantity));
                    }
                    else
                    {
                        Console.WriteLine("We don't have this category!");
                        goto ReCategory;
                    }
                    productController.ShowAllProducts();
                }
                else if (Convert.ToInt32(userChoice) == 2)
                {
                    Console.Write("1. Show all products\n" +
                                      "2. Show only noteboooks\n" +
                                      "3. Show only phones\n" +
                                      "Enter your choice by number: ");
                    ReShow:
                    var rawShowChoice = Console.ReadLine();
                    int d;
                    bool checkShowChoice = int.TryParse(rawShowChoice, out d);
                    
                    if (checkShowChoice)
                    {
                        int showChoice = Convert.ToInt32(rawShowChoice);
                        if (showChoice == 1)
                        {
                            productController.ShowAllProducts();
                        }
                        else if (showChoice == 2)
                        {
                            productController.ShowProductsOfNotebook();
                        }
                        else if (showChoice == 3)
                        {
                            productController.ShowProductsOfPhone();
                        }
                        else
                        {
                            Console.WriteLine("There is no this type. Enter from given versions!");
                            goto ReShow;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter only integer number!");
                        goto ReShow;
                    }
                }
                else if (Convert.ToInt32(userChoice) == 3)
                {
                    Console.Write("What do you want update:\n" +
                                      "1.Full product\n" +
                                      "2.Only category\n" +
                                      "3.Only brand\n" +
                                      "4.Only model\n" +
                                      "5.Only price\n" +
                                      "6.Only quantity\n" +
                                      "Enter your choice:");
                    ReUpdate:
                    var rawUpdateChoice = Console.ReadLine();
                    int e;
                    bool checkUpdate = int.TryParse(rawUpdateChoice, out e);

                    if (checkUpdate)
                    {
                        productController.ShowAllProducts();
                        int updateChoice = Convert.ToInt32(rawUpdateChoice);
                        if (updateChoice == 1)
                        {
                            Console.WriteLine("Choose product id: ");
                            int productID = Convert.ToInt32(Console.ReadLine());
                            
                            Console.Write("Please, fill gaps:\n" +
                                          "Category: ");
                            string category = Console.ReadLine();
                    
                            Console.Write("Brand: ");
                            string brand = Console.ReadLine();

                            Console.Write("Model: ");
                            string model = Console.ReadLine();

                            Console.WriteLine("Price: ");
                            decimal price = Convert.ToDecimal(Console.ReadLine());

                            Console.WriteLine("Quantity: ");
                            int quantity = Convert.ToInt32(Console.ReadLine());

                            Product product = null;
                            if (category == "Notebook")
                            {
                                product = new Product(Product.Categories.Notebook, brand, model, price,
                                    quantity);
                            }
                            else if (category == "Phone")
                            {
                                product = new Product(Product.Categories.Phone, brand, model, price,
                                    quantity);
                            }
                            productController.UpdateFullProduct(productID, product);
                            productController.ShowAllProducts();
                        }
                        else if (updateChoice == 2)
                        {
                            Console.WriteLine("Choose product id: ");
                            int productCategory = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Choose from this category: \n");
                            var categories = Enum.GetValues(typeof(Product.Categories));
                            int counter = 1;
                            foreach (var category in categories)
                            {
                                Console.WriteLine($"{counter}: {category}");
                                counter++;
                            }
                            reCategory:
                            int choosenCategoryID = Convert.ToInt32(Console.ReadLine());
                            Product.Categories newCategory;
                            if (choosenCategoryID == 1)
                            {
                                newCategory = Product.Categories.Notebook; 
                            }
                            else if (choosenCategoryID == 2)
                            {
                                newCategory = Product.Categories.Phone;
                            }
                            else
                            {
                                Console.WriteLine("Wrong category! Enter again!");
                                goto reCategory;
                            }
                            
                            productController.UpdateProductByCategory(productCategory, newCategory);
                            productController.ShowAllProducts();
                        }
                        else if (updateChoice == 3)
                        {
                            Console.WriteLine("Choose product id: ");
                            int productCategory = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter new brand: ");
                            string newBrand = Console.ReadLine();
                            
                            productController.UpdateProductByBrand(productCategory, newBrand);
                            productController.ShowAllProducts();
                        }
                        else if (updateChoice == 4)
                        {
                            Console.WriteLine("Choose product id: ");
                            int productCategory = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter new model: ");
                            string newModel = Console.ReadLine();
                            
                            productController.UpdateProductByModel(productCategory, newModel);
                            productController.ShowAllProducts();
                        }
                        else if (updateChoice == 5)
                        {
                            Console.WriteLine("Choose product id: ");
                            int productCategory = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter new price: ");
                            decimal newPrice = Convert.ToDecimal(Console.ReadLine());
                            
                            productController.UpdateProductByPrice(productCategory, newPrice);
                            productController.ShowAllProducts();
                        }
                        else if (updateChoice == 6)
                        {
                            Console.WriteLine("Choose product id: ");
                            int productCategory = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter new quantity: ");
                            int newQuantity = Convert.ToInt32(Console.ReadLine());
                            
                            productController.UpdateProductByQuantity(productCategory, newQuantity);
                            productController.ShowAllProducts();
                        }
                        else
                        {
                            Console.WriteLine("There is no this choice number! Enter again!");
                            goto ReUpdate;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter correct choice with number!");
                        goto ReUpdate;
                    }
                }
                else if (Convert.ToInt32(userChoice) == 4)
                {
                    productController.ShowAllProducts();
                    Console.WriteLine("Choose product id: ");
                    int productID = Convert.ToInt32(Console.ReadLine());
                    productController.RemoveProduct(productID);
                    productController.ShowAllProducts();
                }
                else if (Convert.ToInt32(userChoice) == 5)
                {
                    productController.ShowAllProducts();
                    Console.Write("Choose selled product id: ");
                    int selledID = Convert.ToInt32(Console.ReadLine());
                    Console.Write("How many you selled: ");
                    int selledAmount = Convert.ToInt32(Console.ReadLine());
                    
                    productController.SellProduct(selledID, selledAmount);
                    productController.ShowAllProducts();
                }
                else
                {
                    Console.WriteLine("There is no this type. Enter again!");
                    goto ReEnter;
                }
                
            }
            else
            {
                Console.WriteLine("It is not a number! Enter again!");
                goto ReEnter;
            }
            goto ReEnter;
        }
    }
}