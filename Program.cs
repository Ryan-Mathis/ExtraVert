﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Rose",
        LightNeeds = 2,
        AskingPrice = 5.75M,
        City = "Nashville",
        ZIP = 37214,
        Sold = true,
        AvailableUntil = new DateTime(2023, 10, 25)
    },
    new Plant()
    {
        Species = "Tulip",
        LightNeeds = 3,
        AskingPrice = 2.75M,
        City = "Old Hickory",
        ZIP = 37176,
        Sold = false,
        AvailableUntil = new DateTime(2023, 12, 12)
    },
    new Plant()
    {
        Species = "Pumpkin",
        LightNeeds = 3,
        AskingPrice = 5.75M,
        City = "Hendersonville",
        ZIP = 37075,
        Sold = false,
        AvailableUntil = new DateTime(2023, 7, 11)
    },
    new Plant()
    {
        Species = "Black Rose",
        LightNeeds = 2,
        AskingPrice = 6.66M,
        City = "Nashville",
        ZIP = 37209,
        Sold = false,
        AvailableUntil = new DateTime(2023, 8, 25)
    },
    new Plant()
    {
        Species = "Turnip",
        LightNeeds = 3,
        AskingPrice = 1.75M,
        City = "Ashland City",
        ZIP = 37015,
        Sold = true,
        AvailableUntil = new DateTime(2023, 11, 25)
    },
};

Random random = new Random();
int randomInteger = random.Next(0, plants.Count + 1);

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
                        4. Delist a plant
                        5. Random plant of the day
                        6. Search plants by light needs
                        7. View statistics");
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
    else if (choice == "5")
    {
        RandomPlant();
    }
    else if (choice == "6")
    {
        SearchByLightNeeds();
    }
    else if (choice == "7")
    {
        ViewStats();
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
        Console.WriteLine($"{i + 1}. {PlantDetails(plants[i])} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for {plants[i].AskingPrice} dollars");
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
    Console.WriteLine("Please enter the year your post will expire");
    int newPlantYearExp = int.Parse(Console.ReadLine().Trim());
    Console.WriteLine("Please enter the month your post will expire");
    int newPlantMonthExp = int.Parse(Console.ReadLine().Trim());
    Console.WriteLine("Please enter the day your post will expire");
    int newPlantDayExp = int.Parse(Console.ReadLine().Trim());
    try
    {
        DateTime newPlantYMDExp = new DateTime(newPlantYearExp, newPlantMonthExp, newPlantDayExp);
        Plant newPlant = new Plant()
        {
            Species = newPlantSpecies,
            LightNeeds = newPlantLightNeeds,
            AskingPrice = newPlantAskingPrice,
            City = newPlantCity,
            ZIP = newPlantZIP,
            Sold = false,
            AvailableUntil = newPlantYMDExp
        };

        plants.Add(newPlant);
    }
    catch (ArgumentOutOfRangeException)
    {
        Console.WriteLine("That date shows as invalid, please choose a date that exists!");
    }
}
void AdoptAPlant()
{
    //create a new empty list to store the unsold plants
    List<Plant> adoptablePlants = new List<Plant>();
    DateTime now = DateTime.Now;

    //loop through the plants
    foreach (Plant plant in plants)
    {
        //add each plant that is unsold to the adoptablePlants List
        if (!plant.Sold && plant.AvailableUntil > now)
        {
            adoptablePlants.Add(plant);
        }
    }
    Console.WriteLine("Adoptable plants:");
    //print the adoptable plant list to the console
    for (int i = 0; i < adoptablePlants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {PlantDetails(adoptablePlants[i])}");
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
    Console.WriteLine($"You chose {PlantDetails(chosenPlant)}!");
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
void RandomPlant()
{
    Plant randomPlant = null;
    while (randomPlant == null)
    {
        if (plants[randomInteger].Sold)
        {
            randomInteger = random.Next(0, plants.Count + 1);
        }
        else
        {
            randomPlant = plants[randomInteger];
        }
    }
    randomPlant = plants[randomInteger];
    Console.WriteLine($@"Today's random plant is a {PlantDetails(randomPlant)}, it has a light need rating of {randomPlant.LightNeeds}, and is located in {randomPlant.City} for {randomPlant.AskingPrice}.");
}
void SearchByLightNeeds()
{
    Console.WriteLine("Please enter the maximum light needs number you can cater to in your space(scale of 1 - 5)");
    int response = int.Parse(Console.ReadLine().Trim());
    List<Plant> lightNeedsPlants = new List<Plant>();
    foreach (Plant plant in plants)
    {
        if (plant.LightNeeds <= response)
        {
            lightNeedsPlants.Add(plant);
        }
    }
    Console.WriteLine("The following plants are suitable for your space's light requirements:");
    for (int i = 0; i < lightNeedsPlants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {PlantDetails(lightNeedsPlants[i])}");
    }
}
void ViewStats()
{
    double totalPlantCount = plants.Count;
    Plant cheapestPlant = new Plant()
    {
        AskingPrice = 100
    };
    foreach (Plant plant in plants)
    {
        if (plant.AskingPrice < cheapestPlant.AskingPrice)
        {
            cheapestPlant = plant;
        }
    };
    Console.WriteLine($"The cheapest plant in our selection is the {PlantDetails(cheapestPlant)}");
    List<Plant> availablePlants = new List<Plant>();
    DateTime now = DateTime.Now;
    //loop through the plants
    foreach (Plant plant in plants)
    {
        //add each plant that is unsold to the availablePlants List
        if (!plant.Sold && plant.AvailableUntil > now)
        {
            availablePlants.Add(plant);
        }
    }
    int availablePlantCount = availablePlants.Count;
    Console.WriteLine($"There are currently {availablePlantCount} plants available for adoption");
    Plant neediestPlant = new Plant()
    {
        LightNeeds = 1
    };
    foreach (Plant plant in plants)
    {
        if (plant.LightNeeds > neediestPlant.LightNeeds)
        {
            neediestPlant = plant;
        }
    }
    Console.WriteLine($"Our neediest plant is the {PlantDetails(neediestPlant)}, with a light need of {neediestPlant.LightNeeds}!");
    int totalLightNeeds = 0;
    foreach (Plant plant in plants)
    {
        totalLightNeeds += plant.LightNeeds;
    }
    double totalLightNeedsAsDouble = (double)totalLightNeeds;
    double avgLightNeeds = totalLightNeeds / totalPlantCount;
    Console.WriteLine($"The average light needs of all our plants is {avgLightNeeds}.");
}
string PlantDetails(Plant plant)
{
    string plantString = plant.Species;

    return plantString;
}