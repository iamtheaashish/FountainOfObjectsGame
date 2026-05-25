public class Game
{
    private Map Map { get; set; } = new(4, 4);
    private Player Player { get; } = new();

    private PlayerSenseMap PlayerSenseMap { get; } = new();

    public void Run()
    {
        DateTime GameBeginTime = DateTime.Now;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search of the Fountain of Objects.\nLight is visible only in the entrance, and no other light is seen anywhere in the caverns.\nYou must navigate the Caverns with your other senses.\nFind the Fountain of Objects, activate it, and return to the entrance.\n");

        Console.WriteLine("Look out for pits. You will feel a breeze if a pit is in an adjacent room. If you enter a room with a pit, you will die.");

        Console.WriteLine("Maelstroms are violent forces of sentient wind. Entering a room with one could transport you to any other location in the caverns. You will be able to hear their growling and groaning in nearby rooms.");

        Console.WriteLine("Amaroks roam the caverns. Encountering one is certain death, but you can smell their rotten stench in nearby rooms.");

        Console.WriteLine("You carry with you a bow and a quiver of arrows. You can use them to shoot monsters in the caverns but be warned: you have a limited supply.");

        while (true)
        {
            Console.Write("Do you want to play a \"small\", \"medium\", or \"large\" game?\t");
            string? input = Console.ReadLine()?.ToLower();

            switch (input)
            {
                case "small":
                    Map = new Map(4, 4);
                    break;
                case "medium":
                    Map = new Map(6, 6);
                    break;
                case "large":
                    Map = new Map(8, 8);
                    break;
                default:
                    Console.WriteLine("Invalid input, try again.");
                    continue;
            }
            break;
        }


        while (!HasWon() && IsAlive())
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------------------------------------------------------------------------");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"You are in the room at (Row={Player.Location.Row}, Column={Player.Location.Column}).");

            PlayerSenseMap.SenseSurrounding(Map, Player);
            Player.Action(Map);
            Map.MaelstromPlayerInteraction(Player);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------------------------------------------------------------------------");
        }
        Console.WriteLine("Game over.");
        DateTime GameEndTime = DateTime.Now;
        TimeSpan GameTime = GameEndTime - GameBeginTime;

        Console.WriteLine($"Game went on for {GameTime.Seconds} seconds.");
    }

    private bool HasWon()
    {
        if (Map.Rooms[Player.Location.Row, Player.Location.Column] == Room.Entrance && Map.IsFountainOn)
        {
            Console.WriteLine("You win!");
            Console.WriteLine("----------------------------------------------------------------------------------");
            return true;
        }

        return false;
    }

    private bool IsAlive()
    {
        if (Map.Rooms[Player.Location.Row, Player.Location.Column] == Room.Pit)
        {
            Console.WriteLine("You died by falling into the pit. You Lost!");
            return false;
        }
        if (Map.Rooms[Player.Location.Row, Player.Location.Column] == Room.Amarok)
        {
            Console.WriteLine("You were killed by an Amarok, You Lost!");
            return false;
        }

        return true;
    }
}