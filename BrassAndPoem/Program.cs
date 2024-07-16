List<ProductType> productType = new List<ProductType>
            {
                new ProductType()
                {
                    Title = "Brass Instrument",
                    ID = 1
                },
                new ProductType()
                {
                    Title = "Poem Book",
                    ID = 2
                }
            };

List<Product> products = new List<Product>
            {
                new Product("Trumpet", 844.15m, 1, productType.First(i => i.ID == 1)),
                new Product("Tuba", 1999.55m, 2, productType.First(i => i.ID == 1)),
                new Product("French Horn", 2984.65m, 3, productType.First(i => i.ID == 1)),
                new Product("100 Poems That Matter", 16.74m, 4, productType.First(i => i.ID == 2)),
                new Product("The Giant Book of Poetry", 15.35m, 5, productType.First(i => i.ID == 2))
            };

    DisplayMenu();

void DisplayMenu()
{
    string? choice = null;
    while(choice != "5")
    {
        Text();
        Console.WriteLine(@"
 ----Main menu----
 1. Display All Products
 2. Delete Product 
 3. Add Product       
 4. Update Product   
 5. Exit Store 
");
        choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                DisplayAllProducts(products, productType);
                break;
            case "2":
                DeleteProduct(products, productType);
                break;
            case "3":
                AddProduct(products, productType);
                break;
            case "4":
                UpdateProduct(products, productType);
                break;
            case "5":
                Console.WriteLine("Later Tater");
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("enter a number between 1-5");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                break;
        }
    }

}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine(" Items in the store...");
    List<Product> store = products.Where(p => !string.IsNullOrEmpty(p.Name)).ToList();
    int count = 1;
    foreach (var product in store)
    {
        Console.WriteLine($@"  {count}. {product.Name}:  ${product.Price}
  {product.ProductType.Title} Item ID:{product.ID} ");
        count++;
    }
    Console.ReadKey();
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    while (true)
    {


        Console.WriteLine("Enter the number of the product to delete, or enter q to return");
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i}. {products[i].Name}");
        }
        string input = Console.ReadLine().ToLower().Trim();

        if (input == "q")
        {
            return;
        }

        if (int.TryParse(input, out int index) && index >= 0 && index < products.Count)
        {
            Console.WriteLine($"{products[index].Name} was deleted.");
            products.RemoveAt(index);
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
            return;
        }
        else
        {
            Console.WriteLine("No. Please enter a valid number, or q.");
            Console.ReadKey();
        }
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Enter Product details: Product's name?");
    string name = Console.ReadLine();

    Console.WriteLine("Enter Product details: Product's price?");
    decimal price;
    while (!decimal.TryParse(Console.ReadLine(), out price))
    {
        Console.WriteLine("that is not a valid number please enter a format of 0.00");
    }

    List<int> usedIds = products.Select(product => product.ID).ToList();
    int ID = 1;
    while (usedIds.Contains(ID))
    {
        ID++;
        Console.WriteLine(ID);
    }


    Console.WriteLine("Enter the number of the item's type.");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"  {i}: {productTypes[i].Title}");
    }

    int typeIndex;
    while (!int.TryParse(Console.ReadLine(), out typeIndex) || typeIndex < 0 || typeIndex >= productType.Count)
    {
        Console.WriteLine("Try again.");
    }

    Product newProduct = new(name, price, ID, productType[typeIndex]);
    products.Add(newProduct);
    Console.WriteLine($" {newProduct.Name} has been added");
    Console.WriteLine($"  press any key to continue");
    Console.ReadKey();
}

    void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Comin' soon Hun'");
}

void Text()
{
    Console.WriteLine(@"
                                                                      ,----,                               
                                                                    ,/   .`|                               
    ,---,.                                                        ,`   .'  :                       ___     
  ,'  .'  \                                                     ;    ;     /                     ,--.'|_   
,---.' .' |  __  ,-.                                          .'___,/    ,'                      |  | :,'  
|   |  |: |,' ,'/ /|             .--.--.    .--.--.           |    :     |           ,--,  ,--,  :  : ' :  
:   :  :  /'  | |' | ,--.--.    /  /    '  /  /    '          ;    |.';  ;   ,---.   |'. \/ .`|.;__,'  /   
:   |    ; |  |   ,'/       \  |  :  /`./ |  :  /`./          `----'  |  |  /     \  '  \/  / ;|  |   |    
|   :     \'  :  / .--.  .-. | |  :  ;_   |  :  ;_                '   :  ; /    /  |  \  \.' / :__,'| :    
|   |   . ||  | '   \__\/: . .  \  \    `. \  \    `.             |   |  '.    ' / |   \  ;  ;   '  : |__  
'   :  '; |;  : |   ,"" .--.; |   `----.   \ `----.   \            '   :  |'   ;   /|  / \  \  \  |  | '.'| 
|   |  | ; |  , ;  /  /  ,.  |  /  /`--'  //  /`--'  /            ;   |.' '   |  / |./__;   ;  \ ;  :    ; 
|   :   /   ---'  ;  :   .'   \'--'.     /'--'.     /             '---'   |   :    ||   :/\  \ ; |  ,   /  
|   | ,'          |  ,     .-./  `--'---'   `--'---'                       \   \  / `---'  `--`   ---`-'   
`----'             `--`---'                                                 `----'                         
                                                                                                           
");
}

// don't move or change this!
public partial class Program { }