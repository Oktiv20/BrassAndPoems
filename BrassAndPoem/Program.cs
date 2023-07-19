
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.

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

void App()
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
                    // AddProduct();
                    break;
                case 4:
                    // UpdateProduct();
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
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];
        ProductType productType = productTypes.FirstOrDefault(p => p.Id == product.ProductTypeId);
        Console.WriteLine($"{i + 1}. Title: {productType.Title} \t Price: {product.Price:C} \t Product Name: {product.Name}");
    };
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Delete a product:");

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }

    Product DeleteProduct = null!;

    while (DeleteProduct == null)
    {
        try
        {
            Console.WriteLine("Enter the product number to remove:");
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

    Console.WriteLine($"You've removed {DeleteProduct.Name}");
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

App();

// don't move or change this!
public partial class Program { }