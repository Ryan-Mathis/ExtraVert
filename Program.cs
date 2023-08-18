using System.Runtime.CompilerServices;

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Rose",
        LightNeeds = 3,
        AskingPrice = 5.75M,
        City = "Nashville",
        ZIP = 37214,
        Sold = true
    },
    new Plant()
    {
        Species = "Tulip",
        LightNeeds = 4,
        AskingPrice = 2.75M,
        City = "Old Hickory",
        ZIP = 37176,
        Sold = false
    },
    new Plant()
    {
        Species = "Pumpkin",
        LightNeeds = 3,
        AskingPrice = 5.75M,
        City = "Hendersonville",
        ZIP = 37075,
        Sold = false
    },
    new Plant()
    {
        Species = "Black Rose",
        LightNeeds = 1,
        AskingPrice = 6.66M,
        City = "Nashville",
        ZIP = 37209,
        Sold = false
    },
    new Plant()
    {
        Species = "Turnip",
        LightNeeds = 4,
        AskingPrice = 1.75M,
        City = "Ashland City",
        ZIP = 37015,
        Sold = true
    },
};

string greeting = @"Welcome to ExtraVert
A place to buy and sell plants";

Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. Display all plants
                        2. Post a plant to be adopted
                        3. Adopt a plant
                        4. Delist a plant");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        DisplayAllPlants();
    }
    else if (choice == "2")
    {
        throw new NotImplementedException("Post a plant to be adopted");
    }
    else if (choice == "3")
    {
        throw new NotImplementedException("Adopt a plant");
    }
    else if (choice == "4")
    {
        throw new NotImplementedException("Delist a plant");
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Please choose an existing option!");
    }
}
void DisplayAllPlants()
{
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for {plants[i].AskingPrice} dollars");
    } 
}
void PostAPlant()
{
    Console.WriteLine("Please input your plant's species");
    string postedPlantSpecies = Console.ReadLine().Trim();
    Console.WriteLine("Please input your plant's light needs ranging from 1 - 5");
    int postedPlantLightNeeds = int.Parse(Console.ReadLine().Trim());
    Console.WriteLine("Please input the asking price for your plant");
    decimal postedPlantAskingPrice = decimal.Parse(Console.ReadLine().Trim());
}