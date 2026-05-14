class Program
{
    static void Main(string[] args)
    {
        int hallwayLength = 20;
        int hallwayWidth = 2;
        int tileLength = 2;
        List<string> tiles = new List<string> {"BW", "BR"};

        int numHallways = HallwayTiler.CountHallwayArrangements(hallwayLength, hallwayWidth, tileLength, tiles);

        Console.WriteLine();
        Console.WriteLine($"Hallway Length = {hallwayLength}");
        Console.WriteLine($"Hallway Width = {hallwayWidth}");
        Console.WriteLine($"Tile Length = {tileLength}");
        Console.WriteLine("Tile Width is always 1.");
        Console.WriteLine("Tiles must be placed lengthways down the hallway.");
        Console.WriteLine("Tiles can be rotated 180 degrees if doing so produces a new tile.");
        Console.WriteLine();
        Console.WriteLine("Tiles-");
        for (int i = 0; i < tiles.Count; i++)
        {
            Console.WriteLine($"Tile {i+1}- {tiles[i]}");
        }
        Console.WriteLine();
        Console.WriteLine($"The number of ways to lay these tiles in the given hallway is {numHallways}.");
        Console.WriteLine();
    }

    static void PrintRows(List<List<string>> rows)
    {
        for (int row = 0; row < rows.Count; row++)
        {
            Console.WriteLine();
            for (int tile = 0; tile < rows[row].Count; tile++)
            {
                Console.Write($" {rows[row][tile]} ");
            }
            Console.WriteLine();
        }
    }

    static void PrintRowsVertically(List<List<string>> rows)
    {
        for (int row = 0; row < rows.Count; row++)
        {
            for (int colour = 0; colour < rows[row][0].Length; colour++)
            {
                for (int tile = 0; tile < rows[row].Count; tile++)
                {
                    Console.Write($"{rows[row][tile][colour]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    static void PrintTiles(List<string> tiles)
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"Tiles printed = {tiles.Count}");
        Console.WriteLine();
        for (int tile = 0; tile < tiles.Count; tile++)
        {
            Console.WriteLine(tiles[tile]);
        }
        Console.WriteLine();
    }

    static void PrintHallwaysVertically(List<List<List<string>>> hallways)
    {
        for (int hallway = 0; hallway < hallways.Count; hallway++)
        {
            Console.WriteLine();
            Console.WriteLine($"Hallway {hallway} printed vertically");
            Console.WriteLine();
            for (int row = 0; row < hallways[hallway].Count; row++)
            {
                //Console.WriteLine($"Row {row}");
                for (int colour = 0; colour < hallways[hallway][row][0].Length; colour++)
                {
                    for (int tile = 0; tile < hallways[hallway][row].Count; tile++)
                    {
                        Console.Write($"{hallways[hallway][row][tile][colour]} ");
                    }
                    Console.WriteLine();
                }
                //Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("End of hallway");    
            Console.WriteLine();
        }
    }
}
