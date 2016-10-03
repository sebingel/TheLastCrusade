using System;
using System.Collections.Generic;
using System.Linq;

internal class Player
{
    private static void Main()
    {
        #region RoomList

        List<Room> rooms = new List<Room>
        {
            new Room(1,
                new Dictionary<Direction, Direction>
                {
                    { Direction.LEFT, Direction.DOWN },
                    { Direction.RIGHT, Direction.DOWN },
                    { Direction.TOP, Direction.DOWN }
                }),
            new Room(2,
                new Dictionary<Direction, Direction>
                {
                    { Direction.LEFT, Direction.RIGHT },
                    { Direction.RIGHT, Direction.LEFT }
                }),
            new Room(3, new Dictionary<Direction, Direction> { { Direction.TOP, Direction.DOWN } }),
            new Room(4,
                new Dictionary<Direction, Direction>
                {
                    { Direction.TOP, Direction.LEFT },
                    { Direction.RIGHT, Direction.DOWN }
                }),
            new Room(5,
                new Dictionary<Direction, Direction>
                {
                    { Direction.TOP, Direction.RIGHT },
                    { Direction.LEFT, Direction.DOWN }
                }),
            new Room(6,
                new Dictionary<Direction, Direction>
                {
                    { Direction.LEFT, Direction.RIGHT },
                    { Direction.RIGHT, Direction.LEFT }
                }),
            new Room(7,
                new Dictionary<Direction, Direction>
                {
                    { Direction.TOP, Direction.DOWN },
                    { Direction.RIGHT, Direction.DOWN }
                }),
            new Room(8,
                new Dictionary<Direction, Direction>
                {
                    { Direction.LEFT, Direction.DOWN },
                    { Direction.RIGHT, Direction.DOWN }
                }),
            new Room(9,
                new Dictionary<Direction, Direction>
                {
                    { Direction.TOP, Direction.DOWN },
                    { Direction.LEFT, Direction.DOWN }
                }),
            new Room(10, new Dictionary<Direction, Direction> { { Direction.TOP, Direction.LEFT } }),
            new Room(11, new Dictionary<Direction, Direction> { { Direction.TOP, Direction.RIGHT } }),
            new Room(12, new Dictionary<Direction, Direction> { { Direction.RIGHT, Direction.DOWN } }),
            new Room(13, new Dictionary<Direction, Direction> { { Direction.LEFT, Direction.DOWN } })
        };

        #endregion

        string[] inputs = Console.ReadLine().Split(' ');
        int columns = int.Parse(inputs[0]); // number of columns.
        int rows = int.Parse(inputs[1]); // number of rows.
        int[,] map = new int[columns, rows];
        for (int i = 0; i < rows; i++)
        {
            string[] line = Console.ReadLine().Split(' ');

            // represents a line in the grid and contains W integers. Each integer represents one room of a given type.
            for (int j = 0; j < columns; j++)
                map[j, i] = int.Parse(line[j]);
        }
        int exitX = int.Parse(Console.ReadLine());
        // the coordinate along the X axis of the exit (not useful for this first mission, but must be read).

        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int currentX = int.Parse(inputs[0]);
            int currentY = int.Parse(inputs[1]);
            string entry = inputs[2];

            Room r = rooms.Find(x => x.Type == map[currentX, currentY]);
            Direction d = (Direction)Enum.Parse(typeof (Direction), entry);

            Console.Error.WriteLine($"currentX: {currentX}, currentY: {currentY}, Roomtype: {r.Type}, entry: {entry}");
            foreach (var direction in r.Directions)
                Console.Error.WriteLine($"entry: {direction.Key}, exit: {direction.Value}");

            Direction exit = r.Directions.First(x => x.Key == d).Value;

            int nextX = currentX;
            int nextY = currentY;

            switch (exit)
            {
                case Direction.DOWN:
                    nextY++;
                    break;
                case Direction.LEFT:
                    nextX--;
                    break;
                case Direction.RIGHT:
                    nextX++;
                    break;
            }

            // One line containing the X Y coordinates of the room in which you believe Indy will be on the next turn.
            Console.WriteLine($"{nextX} {nextY}");
        }
    }
}

internal class Room
{
    internal int Type { get; }

    internal Dictionary<Direction, Direction> Directions { get; }

    public Room(int type, Dictionary<Direction, Direction> directions)
    {
        Type = type;
        Directions = directions;
    }
}

internal enum Direction
{
    TOP,
    RIGHT,
    LEFT,
    DOWN
}