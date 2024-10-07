using System;
using System.Text.RegularExpressions;

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
// ===============================================================================================================================================
            string regex = "^[A-Za-z]+$";
            string notEmpty = @"\S+";
            string positive = @"^[0-9]+$";
            
            ReEnter:
            Console.Write("Welcome! Choose a number:\n" +
                              $"1. Add product\n" +
                              $"2. Show products\n" +
                              $"3. Update product\n" +
                              $"4. Remove product\n" +
                              $"5. Sell product\n" +
                              $"6. Exit\n" +
                              $"Enter choice: ");
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
                        goto ReEnter;
                    }
                    else if (category == "Phone")
                    {
                        productController.AddProduct(new Product(Product.Categories.Phone, brand, model, price, quantity));
                        goto ReEnter;
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
                            goto ReEnter;
                        }
                        else if (showChoice == 2)
                        {
                            productController.ShowProductsOfNotebook();
                            goto ReEnter;
                        }
                        else if (showChoice == 3)
                        {
                            productController.ShowProductsOfPhone();
                            goto ReEnter;
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
                            ID:
                            Console.WriteLine("Choose product id: ");
                            var productID = Console.ReadLine();
                            int b;
                            bool checkID = int.TryParse(productID, out a);
                            int id;

                            if (checkID && Regex.IsMatch(productID, notEmpty))
                            {
                                id = Convert.ToInt32(productID);
                                if (id <= productController.Products.Count)
                                {
                                    goto Category; 
                                }
                                else
                                {
                                    Console.WriteLine("There is not this id! Enter again");
                                    goto ID;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Wrong id! Enter again");
                                goto ID;
                            }
                            
                            Category:
                            Console.Write("Please, fill gaps:\n" +
                                          "Category: ");
                            string category = Console.ReadLine();

                            if (Regex.IsMatch(category, regex))
                            {
                                goto Brand;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Wrong category! Enter again");
                                goto Category;
                            }
                    
                            Brand:
                            Console.Write("Brand: ");
                            string brand = Console.ReadLine();
                            
                            if (Regex.IsMatch(brand, regex))
                            {
                                goto Model;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Wrong brand! Enter again");
                                goto Brand;
                            }

                            Model:
                            Console.Write("Model: ");
                            string model = Console.ReadLine();
                            
                            if (Regex.IsMatch(model, notEmpty))
                            {
                                goto Price;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Wrong model! Enter again");
                                goto Model;
                            }

                            Price:
                            Console.WriteLine("Price: ");
                            var priceCon = Console.ReadLine();
                            decimal f;
                            bool checkPrice = decimal.TryParse(priceCon, out f);
                            decimal price;

                            if (checkPrice && Regex.IsMatch(priceCon, notEmpty))
                            {
                                price = Convert.ToDecimal(priceCon);
                                goto Quantity;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Wrong model! Enter again");
                                goto Model;
                            }

                            Quantity:
                            Console.WriteLine("Quantity: ");
                            var quantityCon = Console.ReadLine();
                            int c;
                            bool checkQuan = int.TryParse(quantityCon, out c);
                            int quantity;
                            if (checkQuan && Regex.IsMatch(quantityCon, notEmpty))
                            {
                                quantity = Convert.ToInt32(quantityCon);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Wrong quantity! Enter again");
                                goto Quantity;
                            }

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
                            productController.UpdateFullProduct(id, product);
                            productController.ShowAllProducts();
                            goto ReEnter;
                        }
                        else if (updateChoice == 2)
                        {
                            ID:
                            Console.WriteLine("Choose product id: ");
                            var productCategoryCon = Console.ReadLine();
                            int b;
                            bool checkCateg = int.TryParse(productCategoryCon, out b);
                            int productCategory;
                            if (checkCateg && Regex.IsMatch(productCategoryCon, notEmpty))
                            {
                                productCategory = Convert.ToInt32(productCategoryCon);
                                if (productCategory <= productController.Products.Count)
                                {
                                    goto Category;
                                }
                                else
                                {
                                    Console.WriteLine("There is not this id! Enter again"); 
                                    goto ID;
                                }
                            }
                            else
                            {
                                Console.WriteLine("It is not an id! Enter again");
                                goto ID;
                            }
                
                            Category:
                            Console.Write("Choose from this category: \n");
                            var categories = Enum.GetValues(typeof(Product.Categories));
                            int counter = 1;
                            foreach (var category in categories)
                            {
                                Console.WriteLine($"{counter}: {category}");
                                counter++;
                            }
                            reCategory:
                            var choosenCategoryIDCon = Console.ReadLine();
                            int c;
                            bool checkCatID = int.TryParse(choosenCategoryIDCon, out c);
                            int choosenCategoryID;
                            Product.Categories newCategory;

                            if (checkCatID && Regex.IsMatch(choosenCategoryIDCon, notEmpty))
                            {
                                choosenCategoryID = Convert.ToInt32(choosenCategoryIDCon);
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
                            }
                            else
                            {
                                Console.WriteLine("Wrong category! Enter again");
                                goto reCategory;
                            }
                            
                            productController.UpdateProductByCategory(productCategory, newCategory);
                            productController.ShowAllProducts();
                            goto ReEnter;
                        }
                        else if (updateChoice == 3)
                        {
                            ID:
                            Console.WriteLine("Choose product id: ");
                            var productCategoryCon = Console.ReadLine();
                            int b;
                            bool checkProCat = int.TryParse(productCategoryCon, out b);
                            int productCategory;
                            if (checkProCat && Regex.IsMatch(productCategoryCon, notEmpty))
                            {
                                productCategory = Convert.ToInt32(productCategoryCon);
                                if (productCategory<=productController.Products.Count)
                                {
                                    goto Brand;
                                }
                                else
                                {
                                    Console.WriteLine("There is not this id! Enter again");
                                    goto ID;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong id! Enter again");
                                goto ID;
                            }
                            
                            Brand:
                            Console.WriteLine("Enter new brand: ");
                            string newBrand = Console.ReadLine();
                            if (Regex.IsMatch(newBrand, regex))
                            {
                                goto Next;
                            }
                            else
                            {
                                Console.WriteLine("Brand type is wrong! Enter again");
                                goto Brand;
                            }
                            
                            Next:
                            productController.UpdateProductByBrand(productCategory, newBrand);
                            productController.ShowAllProducts();
                            goto ReEnter;
                        }
                        else if (updateChoice == 4)
                        {
                            ID:
                            Console.WriteLine("Choose product id: ");
                            var productCategoryCon = Console.ReadLine();
                            int b;
                            bool checkCateg = int.TryParse(productCategoryCon, out b);
                            int productCategory;
                            if (checkCateg && Regex.IsMatch(productCategoryCon, notEmpty))
                            {
                                productCategory = Convert.ToInt32(productCategoryCon);
                                if (productCategory<=productController.Products.Count)
                                {
                                    goto Model;
                                }
                                else
                                {
                                    Console.WriteLine("There is not this id! Enter again");
                                    goto ID;
                                }
                            }
                            else
                            {
                                Console.WriteLine("It is not an id! Enter again");
                                goto ID;
                            }
                            
                            Model:
                            Console.WriteLine("Enter new model: ");
                            string newModel = Console.ReadLine();
                            if (Regex.IsMatch(newModel, notEmpty))
                            {
                                goto Next;
                            }
                            else
                            {
                                Console.WriteLine("Wrong model! Enter again");
                                goto Model;
                            }
                            
                            Next:
                            productController.UpdateProductByModel(productCategory, newModel);
                            productController.ShowAllProducts();
                            goto ReEnter;
                        }
                        else if (updateChoice == 5)
                        {
                            ID:
                            Console.WriteLine("Choose product id: ");
                            var productCategoryCon = Console.ReadLine();
                            int b;
                            bool checkCateg = int.TryParse(productCategoryCon, out b);
                            int productCategory;
                            if (checkCateg && Regex.IsMatch(productCategoryCon, notEmpty))
                            {
                                productCategory = Convert.ToInt32(productCategoryCon);
                                if (productCategory<=productController.Products.Count)
                                {
                                    goto Price;
                                }
                                else
                                {
                                    Console.WriteLine("There is not this id! Enter again");
                                    goto ID;
                                }
                            }
                            else
                            {
                                Console.WriteLine("It is not an id! Enter again");
                                goto ID;
                            }
    
                            Price:
                            Console.WriteLine("Enter new price: ");
                            var newPriceCon = Console.ReadLine();
                            decimal c;
                            bool checkPrice = decimal.TryParse(newPriceCon, out c);
                            decimal newPrice;
                            if (checkPrice && Regex.IsMatch(newPriceCon, notEmpty))
                            {
                                newPrice = Convert.ToDecimal(newPriceCon);
                            }
                            else
                            {
                                Console.WriteLine("Wrong price! Enter again");
                                goto Price;
                            }
                            
                            productController.UpdateProductByPrice(productCategory, newPrice);
                            productController.ShowAllProducts();
                            goto ReEnter;
                        }
                        else if (updateChoice == 6)
                        {
                            ID:
                            Console.WriteLine("Choose product id: ");
                            var productCategoryCon = Console.ReadLine();
                            int b;
                            bool checkCateg = int.TryParse(productCategoryCon, out b);
                            int productCategory;
                            if (checkCateg && Regex.IsMatch(productCategoryCon, notEmpty))
                            {
                                productCategory = Convert.ToInt32(productCategoryCon);
                                if (productCategory<=productController.Products.Count)
                                {
                                    goto Quantity;
                                }
                                else
                                {
                                    Console.WriteLine("There is not this id! Enter again");
                                    goto ID;
                                }
                            }
                            else
                            {
                                Console.WriteLine("It is not an id! Enter again");
                                goto ID;
                            }

                            Quantity:
                            Console.WriteLine("Enter new quantity: ");
                            var newQuantCon = Console.ReadLine();
                            int c;
                            bool checkPrice = int.TryParse(newQuantCon, out c);
                            int newQuantity;
                            if (checkPrice && Regex.IsMatch(newQuantCon, notEmpty))
                            {
                                newQuantity = Convert.ToInt32(newQuantCon);
                            }
                            else
                            {
                                Console.WriteLine("Wrong quantity! Enter again");
                                goto Quantity;
                            }
                            
                            productController.UpdateProductByQuantity(productCategory, newQuantity);
                            productController.ShowAllProducts();
                            goto ReEnter;
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
                    ID:
                    Console.WriteLine("Choose removed product id: ");
                    var productIDCon = Console.ReadLine();
                    int b;
                    bool checkCateg = int.TryParse(productIDCon, out b);
                    int productID;
                    if (checkCateg && Regex.IsMatch(productIDCon, notEmpty))
                    {
                        productID = Convert.ToInt32(productIDCon);
                        if (productID <= productController.Products.Count)
                        {
                            goto Next;
                        }
                        else
                        {
                            Console.WriteLine("There is not this id! Enter again");
                            goto ID;
                        }
                    }
                    else
                    {
                        Console.WriteLine("It is not an id! Enter again");
                        goto ID;
                    }
                    Next:
                    productController.RemoveProduct(productID);
                    productController.ShowAllProducts();
                    goto ReEnter;
                }
                else if (Convert.ToInt32(userChoice) == 5)
                {
                    productController.ShowAllProducts();
                    ID:
                    Console.WriteLine("Choose selled id: ");
                    var selledIDCon = Console.ReadLine();
                    int b;
                    bool checkID = int.TryParse(selledIDCon, out b);
                    int selledID;
                    if (checkID && Regex.IsMatch(selledIDCon, notEmpty))
                    {
                        selledID = Convert.ToInt32(selledIDCon);
                        if (selledID <= productController.Products.Count)
                        {
                            goto Selled;
                        }
                        else
                        {
                            Console.WriteLine("There is not this id! Enter again");
                            goto ID;
                        }
                    }
                    else
                    {
                        Console.WriteLine("It is not an id! Enter again");
                        goto ID;
                    }
                    
                    Selled:
                    Console.Write("How many you selled: ");
                    var selledAmountCon = Console.ReadLine();
                    int c;
                    bool checkSelled = int.TryParse(selledAmountCon, out c);
                    int selledAmount;

                    if (checkSelled && Regex.IsMatch(selledAmountCon, notEmpty) && Regex.IsMatch(selledAmountCon, positive))
                    {
                        selledAmount = Convert.ToInt32(selledAmountCon);
                        if (productController.SellProduct(selledID, selledAmount))
                        {
                            goto AfterSell;
                        }
                        else
                        {
                            Console.WriteLine("Amount is more than quantity. Enter again!");
                            goto Selled;
                        }
                    }
                    else
                    {
                        Console.WriteLine("It is not an correct amount! Enter again");
                        goto Selled;
                    }

                    AfterSell:
                    productController.ShowAllProducts();
                    goto ReEnter;
                }
                else if (Convert.ToInt32(userChoice) == 6)
                {
                    Console.WriteLine("Process finished..."); 
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