public class Map
{
    public Room[,] Rooms { get; private set; }
    public int Rows { get; }
    public int Columns { get; }

    public bool IsFountainOn { get; private set; }
    public Map(int row, int column)
    {
        Rows = row;
        Columns = column;

        Rooms = new Room[Rows, Columns];

        for (int i = 0; i < Rows; i++)
        for (int j = 0; j < Columns; j++)
            Rooms[i, j] = Room.Empty;

        Rooms[0, 0] = Room.Entrance;
        Rooms[0, 2] = Room.Fountain;


        if (Rows == 4 && Columns == 4)
        {
            Rooms[2, 2] = Room.Pit;
            Rooms[0, 3] = Room.Maelstrom;
            Rooms[2, 0] = Room.Amarok;
        }
        if (Rows == 6 && Columns == 6)
        {
            Rooms[2, 2] = Room.Pit;
            Rooms[4, 4] = Room.Pit;
            Rooms[1, 3] = Room.Maelstrom;
            Rooms[0, 5] = Room.Amarok;
            Rooms[5, 0] = Room.Amarok;
        }
        if (Rows == 8 && Columns == 8)
        {
            Rooms[2, 2] = Room.Pit;
            Rooms[4, 4] = Room.Pit;
            Rooms[6, 6] = Room.Pit;
            Rooms[0, 7] = Room.Pit;
            Rooms[4, 3] = Room.Maelstrom;
            Rooms[2, 5] = Room.Maelstrom;
            Rooms[0, 7] = Room.Amarok;
            Rooms[7, 0] = Room.Amarok;
            Rooms[5, 2] = Room.Amarok;
        }


    }

    public void MaelstromPlayerInteraction(Player player)
    {
        int tempRow = player.Location.Row;
        int tempColumn = player.Location.Column;

        if (Rooms[tempRow, tempColumn] == Room.Maelstrom)
        {
            Console.WriteLine("Ohh no! Maelstrom threw you away from your current location.");
            if (tempRow > 0 && tempColumn < Columns - 2)
            {
                player.Location.Row -= 1;
                player.Location.Column += 2;
            }
            if (tempRow < Rows - 1 && tempColumn > 0)
            {
                Rooms[tempRow, tempColumn] = Room.Empty;
                Rooms[tempRow + 1, tempColumn - 2] = Room.Maelstrom;
            }
        }
    }

    public bool Shoot(string direction, Location location)
    {
        switch (direction)
        {
            case "north":
                if (location.Row > 0 &&
                    (Rooms[location.Row - 1, location.Column] == Room.Amarok ||
                     Rooms[location.Row - 1, location.Column] == Room.Maelstrom))
                {
                    Rooms[location.Row - 1, location.Column] = Room.Empty;
                    return true;
                }
                break;

            case "south":
                if (location.Row < Rows - 1 &&
                    (Rooms[location.Row + 1, location.Column] == Room.Amarok ||
                     Rooms[location.Row + 1, location.Column] == Room.Maelstrom))
                {
                    Rooms[location.Row + 1, location.Column] = Room.Empty;
                    return true;
                }
                break;

            case "west":
                if (location.Column > 0 &&
                    (Rooms[location.Row, location.Column - 1] == Room.Amarok ||
                     Rooms[location.Row, location.Column - 1] == Room.Maelstrom))
                {
                    Rooms[location.Row, location.Column - 1] = Room.Empty;
                    return true;
                }
                break;

            case "east":
                if (location.Column < Columns - 1 &&
                    (Rooms[location.Row, location.Column + 1] == Room.Amarok ||
                     Rooms[location.Row, location.Column + 1] == Room.Maelstrom))
                {
                    Rooms[location.Row, location.Column + 1] = Room.Empty;
                    return true;
                }
                break;
        }

        return false;
    }
    public void TurnFountainOn()
    {
        IsFountainOn = true;
    }
}