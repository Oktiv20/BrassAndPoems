
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.

using System.ComponentModel.Design;
using System.Net.WebSockets;
using System.Threading.Channels;

List<Product> products = new List<Product>()
{
    new Product() 
    { 
        Name = "Tuba", 
        Price = 3000.00m, 
        ProductTypeId = 1
    },
    new Product() 
    { 
        Name = "Saxophone", 
        Price = 10000.00m, 
        ProductTypeId = 1
    },
    new Product() 
    { 
        Name = "Trumpet", 
        Price = 50000.00m, 
        ProductTypeId = 1
    },
    new Product() 
    { 
        Name = "Come In", 
        Price = 1000.00m, 
        ProductTypeId = 2
    },
    new Product() 
    { 
        Name = "Music Swims Back To Me", 
        Price = 5000.00m, 
        ProductTypeId = 2
    },
};

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType() 
    { 
        Title = "Brass", 
        Id = 1 
    },
    new ProductType() 
    { 
        Title = "Poems", 
        Id = 2 
    },
};


// MAIN MENU

void MainApp()
{
    Console.WriteLine("Welcome to Brass & Poems!");

    int choice;
    do
    {
        DisplayMenu();
        string input = Console.ReadLine();

        if (int.TryParse(input, out choice))
        {
            switch (choice)
            {
                case 1:
                    DisplayAllProducts(products, productTypes);
                    break;
                case 2:
                    DeleteProduct(products, productTypes);
                    break;
                case 3:
                    AddProduct(products, productTypes);
                    break;
                case 4:
                    UpdateProduct(products, productTypes);
                    break;
                case 5:
                    Console.WriteLine("Exit App");
                    return;
                default:
                    Console.WriteLine("Please try again");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Please try again");
        };
    }
    while (choice != 5);
}

void DisplayMenu()
{
    Console.WriteLine(@"Please choose an option below:
        1. DisplayAllProducts
        2. DeleteProduct
        3. AddProduct
        4. UpdateProduct
        5. Exit");
    Console.WriteLine();
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];
        ProductType productType = productTypes.FirstOrDefault(prodType => prodType.Id == product.ProductTypeId);
        Console.WriteLine($"{i + 1}. Title: {productType.Title} \t Price: {product.Price:C} \t Product Name: {product.Name}");
    };
    Console.WriteLine();
}
Console.WriteLine();

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Delete a product");

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
    Console.WriteLine();

    Product DeleteProduct = null!;

    while (DeleteProduct == null)
    {
        try
        {
            Console.WriteLine("Enter the product number to delete:");
            int response = int.Parse(Console.ReadLine()!.Trim());
            DeleteProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid number from the list.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please enter a valid number from list.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Not a valid choice. Please try again.");
        }
    }

    products.Remove(DeleteProduct);
    Console.WriteLine();

    Console.WriteLine($"You've deleted {DeleteProduct.Name}!");
    Console.WriteLine();
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Add a new product");
    Console.WriteLine("Enter the name of the product:");
    string? newProductName = Console.ReadLine();

    if (string.IsNullOrEmpty(newProductName))
    {
        Console.WriteLine("This field is required. Please enter a name.");
    }
    Console.WriteLine();

    Console.WriteLine("Enter the price of the product:");
    if (!decimal.TryParse(Console.ReadLine(), out decimal newProductPice))
    {
        Console.WriteLine("This field is required. Please enter a price.");
    }
    Console.WriteLine();

    Console.WriteLine("Please choose one of the given numbers for the Product Type:");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. Product Id {productTypes[i].Id}: {productTypes[i].Title}");
    }
    Console.WriteLine();

    if (!Int32.TryParse(Console.ReadLine(), out int AddedProductType))
    {
        Console.WriteLine("Incorrect product type. Please choose from the given list.");
    }
    Console.WriteLine();

    Product newProduct = new Product
    {
        Name = newProductName,
        Price = newProductPice,
        ProductTypeId = AddedProductType,
    };

    products.Add(newProduct);

    Console.WriteLine($"You've successfully added {newProduct.Name}!");
    Console.WriteLine();
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Please choose which product you would like to update by the number listed.");
    DisplayAllProducts(products, productTypes);

    string userInput = Console.ReadLine();

    if (Int32.TryParse(userInput, out int index))
    {
        if (index >= 1 && index <= products.Count)
        {
            Product product = products[index - 1];
            Console.WriteLine("Enter the new name or press enter to keep original name.");
            string updatedName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(updatedName))
            {
                product.Name = updatedName;
            }
            else
            {
                Console.WriteLine();

                Console.WriteLine("Enter the new price or press enter to keep original price.");
                string updatedPrice = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(updatedPrice) && decimal.TryParse(updatedPrice, out decimal price))
                {
                    product.Price = price;
                }
                Console.WriteLine();

                Console.WriteLine("Select the updated product type or press enter to keep original product type.");
                for (int i = 0; i < productTypes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Product Id {productTypes[i].Id}: {productTypes[i].Title}");
                }
                Console.WriteLine();

                string updatedProductType = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(updatedProductType) && int.TryParse(updatedProductType, out int productType))
                {
                    product.ProductTypeId = productType;
                }
            }
        }
        else
        {
            Console.WriteLine("Not a valid input.Please try again.");
        }
    }
}

MainApp();

// don't move or change this!
public partial class Program { }