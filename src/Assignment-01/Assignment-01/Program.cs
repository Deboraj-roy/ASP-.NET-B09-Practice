using Assignment1;
using System.Collections;
using System.Threading.Channels;

Builder builder = new() { BuilderName = "Rupayan", ContactNumber = 0154544 };
House house = new House(builder)
{
    room = new Room(23)
    {
        RoomNumber = "23",
        Windows = new List<Window>
            {
                new Window { Width = 1030, Height = 2020 },
                new Window { Width = 3250, Height = 3500 }
            }
    },
    Car = Cars.BMW,
    HouseNames = new string[] {"Hitumi Kunjo", "Khan Vila", "SR House"},
    Rooms = new List<Room>
    {
        new Room(5)
        {
            RoomNumber = "200",
            Windows = new List<Window>
            {
                new Window { Width = 200, Height = 300 },
                new Window { Width = 44, Height = 88 }
            }
        },
        new Room(6)
        {
            RoomNumber = "300",
            Windows = new List<Window>
            {
                new Window { Width = 100, Height = 200 },
                new Window { Width = 350, Height = 500 }
            }
        }
    }
};
House.Name = "Abc";

Builder builder2 = new() { BuilderName = "Basundhara", ContactNumber = 0968554 };
house.houses = new House[] { new House(builder2)
{
    Car = Cars.Tesla,
    HouseNames = new string[] {"Hitumi Kunjo", "Khan Vila", "SR House"},
    Rooms = new List<Room>
    {
        new Room(2)
        {
            RoomNumber = "200",
            Windows = new List<Window>
            {
                new Window { Width = 200, Height = 300 },
                new Window { Width = 44, Height = 88 }
            }
        },
        new Room(1)
        {
            RoomNumber = "300",
            Windows = new List<Window>
            {
                new Window { Width = 100, Height = 200 },
                new Window { Width = 350, Height = 500 }
            }
        }
    }
} };
Building building = new Building();

SimpleMapper.CopyObject(house, building);

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("Printing Copied Item from Destination Object\n");
Console.ForegroundColor = ConsoleColor.White;

Console.WriteLine($"{Building.Name}");
Console.WriteLine($"{building.BuildingNumber}");

Array.ForEach(building.HouseNames, (houseName) => Console.WriteLine($"HouseName = {houseName}"));

Console.WriteLine($"\nCar Name = {building.Car}");

foreach (var room in building.Rooms)
{
    Console.WriteLine($"\nRoom Number = {room.RoomNumber}");
    foreach (var window in room.Windows)
    {
        Console.WriteLine($"Width : {window.Width}, Height : {window.Height}");
    }
    Console.WriteLine();
}