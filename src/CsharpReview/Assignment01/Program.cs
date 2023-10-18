using Assignment01;
House house = new House
{
    Rooms = new List<Room>
            {
                new Room
                {
                    RoomNumber = "200",
                    Windows = new List<Window>
                    {
                        new Window { Width = 200, Height = 300 },
                        new Window { Width = 44, Height = 88 }
                    }
                },
                new Room
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

Building building = new Building();

SimpleMapper mapper = new SimpleMapper();
mapper.Copy(house, building);

PrintBuildingData(building);


static void PrintBuildingData(Building building)
{
    Console.WriteLine("Building Number: " + building.BuildingNumber);
    foreach (var room in building.Rooms)
    {
        Console.WriteLine("Room Number: " + room.RoomNumber);
        foreach (var window in room.Windows)
        {
            Console.WriteLine("Window Width: " + window.Width + ", Height: " + window.Height);
        }
    }
}
