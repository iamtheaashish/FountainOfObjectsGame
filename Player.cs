public class Player
{
    public Location Location { get; private set; } = new(0, 0);
    private byte _numArrows = 5;


    public void Action(Map map)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("What do you want to do? ");

        Console.ForegroundColor = ConsoleColor.Cyan;

        string? action = Console.ReadLine()?.ToLower();

        switch (action)
        {
            case "move north":
                if (Location.Row > 0)
                    Location.Row--;
                break;

            case "move south":
                if (Location.Row < map.Rows - 1)
                    Location.Row++;
                break;

            case "move west":
                if (Location.Column > 0)
                    Location.Column--;
                break;

            case "move east":
                if (Location.Column < map.Columns - 1)
                    Location.Column++;
                break;
            case "enable fountain":
                if (map.Rooms[Location.Row, Location.Column] == Room.Fountain)
                    map.TurnFountainOn();
                break;
            case "shoot north":
                if (map.Shoot("north", Location) && _numArrows > 0)
                    Console.WriteLine("Killed a monster!");
                else
                    Console.WriteLine("Arrow wasted.");
                _numArrows -= 1;
                break;

            case "shoot south":
                if (map.Shoot("south", Location) && _numArrows > 0)
                    Console.WriteLine("Killed a monster!");
                else
                    Console.WriteLine("Arrow wasted.");
                _numArrows -= 1;
                break;

            case "shoot west":
                if (map.Shoot("west", Location) && _numArrows > 0)
                    Console.WriteLine("Killed a monster!");
                else
                    Console.WriteLine("Arrow wasted.");
                _numArrows -= 1;
                break;

            case "shoot east":
                if (map.Shoot("east", Location) && _numArrows > 0)
                    Console.WriteLine("Killed a monster!");
                else
                    Console.WriteLine("Arrow wasted.");
                _numArrows -= 1;
                break;
            
            case "help":
                Console.WriteLine("move <direction> | direction {north, south, west, east}\nThis command moves the player one unit ahead of it's current location.");

                Console.WriteLine("shoot <direction> | direction {north, south, west, east}\nThis command shoots arrows in the specified direction. Range of the arrow is just one room.");

                Console.WriteLine("enable fountain | enables the fountain, getting one step closer to the win.");

                break;

            default:
                Console.WriteLine("I don't understand that, no changes made.");
                break;
        }
    }
}