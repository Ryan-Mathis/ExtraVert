using System.ComponentModel;
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
        PostAPlant();
    }
    else if (choice == "3")
    {
        AdoptAPlant();
    }
    else if (choice == "4")
    {
        DelistAPlant();
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
    string newPlantSpecies = Console.ReadLine().Trim();
    Console.WriteLine("Please input your plant's light needs ranging from 1 - 5");
    int newPlantLightNeeds = int.Parse(Console.ReadLine().Trim());
    Console.WriteLine("Please input the asking price for your plant");
    decimal newPlantAskingPrice = decimal.Parse(Console.ReadLine().Trim());
    Console.WriteLine("Please input your city");
    string newPlantCity = Console.ReadLine().Trim();
    Console.WriteLine("Please input your ZIP");
    int newPlantZIP = int.Parse(Console.ReadLine().Trim());

    Plant newPlant = new Plant()
    {
        Species = newPlantSpecies,
        LightNeeds = newPlantLightNeeds,
        AskingPrice = newPlantAskingPrice,
        City = newPlantCity,
        ZIP = newPlantZIP,
        Sold = false
    };

    plants.Add(newPlant);
}
void AdoptAPlant()
{
    //create a new empty list to store the unsold plants
    List<Plant> adoptablePlants = new List<Plant>();
    //loop through the plants
    foreach (Plant plant in plants)
    {
        //add each plant that is unsold to the adoptablePlants List
        if (!plant.Sold)
        {
            adoptablePlants.Add(plant);
        }
    }
    Console.WriteLine("Adoptable plants:");
    //print the adoptable plant list to the console
    for (int i = 0; i < adoptablePlants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {adoptablePlants[i].Species}");
    }
    Plant chosenPlant = null;
    while (chosenPlant == null)
    {
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenPlant = adoptablePlants[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }
    }
    chosenPlant.Sold = true;
    Console.WriteLine($"You chose {chosenPlant.Species}!");
}
void DelistAPlant()
{
    Console.WriteLine("Choose a plant to delist");
        for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
    }
    int response = int.Parse(Console.ReadLine().Trim());
    plants.RemoveAt(response - 1);
}