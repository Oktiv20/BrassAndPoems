
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.

using System.Threading.Channels;

List<Product> products = new List<Product>()
{
    new Product { Name = "Tuba", Price = 3000.00m, ProductTypeId = 1},
    new Product { Name = "Saxophone", Price = 10000.00m, ProductTypeId = 1},
    new Product { Name = "Trumpet", Price = 50000.00m, ProductTypeId = 1},
    new Product { Name = "Come In", Price = 1000.00m, ProductTypeId = 2},
    new Product { Name = "Music Swims Back To Me", Price = 5000.00m, ProductTypeId = 2},
};

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType { Title = "Brass", Id = 1 },
    new ProductType { Title = "Poems", Id = 2 },
};
//put your greeting here

string greeting = "Welcome to Brass and Poems!";
Console.WriteLine(greeting);
string? choice = null;


// MAIN MENU

void App()
{
    Console.WriteLine("Welcome to Brass & Poems!");

    int choice;
    do
    {
        DisplayMenu();
        string input = Console.ReadLine();

        
    }
}

void DisplayMenu()
{
    throw new NotImplementedException();
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

// don't move or change this!
public partial class Program { }