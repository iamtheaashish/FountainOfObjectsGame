public class PlayerSenseMap
{
    public void SenseSurrounding(Map map, Player player)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        if (map.Rooms[player.Location.Row, player.Location.Column] == Room.Entrance)
        {
            Console.WriteLine("You see light coming from the cavern entrance.");
        }

        if (map.Rooms[player.Location.Row, player.Location.Column] == Room.Fountain)
        {
            if (!map.IsFountainOn)
                Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
            else
                Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
        }

        // sensing if there's a pit near to player. Also checking if indexes are inside the bounds of array
        // for 8 directions, N, E, W, S and NE, NW, SE, SW

        if (IsNearby(map, player, Room.Pit))
            Console.WriteLine("You feel a draft. There is a pit in a nearby room.");

        if (IsNearby(map, player, Room.Maelstrom))
            Console.WriteLine("You hear the growling and groaning of a maelstrom nearby.");

        if (IsNearby(map, player, Room.Amarok))
            Console.WriteLine("You can smell the rotten stench of an amarok in a nearby room.");
    }

    private bool IsNearby(Map map, Player player, Room roomType)
    {
        for (int row = -1; row <= 1; row++)
        {
            for (int col = -1; col <= 1; col++)
            {
                if (row == 0 && col == 0)
                    continue;

                int checkRow = player.Location.Row + row;
                int checkCol = player.Location.Column + col;

                if (checkRow >= 0 && checkRow < map.Rows && checkCol >= 0 && checkCol < map.Columns)
                    if (map.Rooms[checkRow, checkCol] == roomType)
                        return true;
            }
        }

        return false;
    }
}