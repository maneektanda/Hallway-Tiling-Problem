public class HallwayTiler
{
    static public int CountHallwayArrangements(int n, int m, int t, List<string> tiles)
    {
        /*
        n = Hallway length
        m = Hallway width
        t = Tile length
        */

        int hallwayLength = n;
        int hallwayWidth = m;
        int tileLength = t;

        // Update the available tiles list to allow for rotating tiles.
        List<string> allTilePermutations = GetAllTilePermutations(tiles);

        // Construct all possible row permutations and combinations.
        List<List<string>> rows = GenerateAllValidRows(allTilePermutations, hallwayWidth);

        // Number of rows per hallway.
        int maxRows = hallwayLength / tileLength;

        // Construct all possible hallways, given all possible rows.
        List<List<List<string>>> hallways = GenerateAllValidHallways(rows, tileLength, hallwayLength);

        // Return the number of possible hallways.
        return hallways.Count;
    }




    public static List<List<List<string>>> GenerateAllValidHallways(List<List<string>> allRows, int tileLength, int hallwayLength)
    {
        List<List<List<string>>> allValidHallways = new List<List<List<string>>>();

        void AddRow(List<List<string>> hallway)
        {
            if (hallway.Count * tileLength == hallwayLength) allValidHallways.Add(hallway);

            else
            {
                for (int row = 0; row < allRows.Count; row++)
                {
                    List<List<string>> newHallway = new List<List<string>> (hallway);
                    newHallway.Add(allRows[row]);
                    if (newHallway.Count == 1)
                    {
                        AddRow(newHallway);
                    }
                    else if (RowPlacementIsValid(newHallway[^2], newHallway[^1]))
                    {
                        AddRow(newHallway);
                    }
                }
            }
        }

        List<List<string>> emptyHallway = new List<List<string>>();
        AddRow(emptyHallway);

        return allValidHallways;
    }
    



    public static bool RowPlacementIsValid(List<string> previousRow, List<string> placedRow)
    {
        for (int tile = 0; tile < previousRow.Count; tile++)
        {
            if (previousRow[tile][^1] == placedRow[tile][0]) return false;
        }
        return true;
    }




    public static List<List<string>> GenerateAllValidRows(List<string> allTilePermutations, int hallwayWidth)
    {
        List<List<string>> allValidRows = new List<List<string>>();

        void AddTile(List<string> row)
        {
            if (row.Count == hallwayWidth) allValidRows.Add(row);

            else
            {
                for (int tile = 0; tile < allTilePermutations.Count; tile++)
                {
                    List<string> newRow = new List<string> (row);
                    newRow.Add(allTilePermutations[tile]);
                    if (TileArrangementIsValid(newRow))
                    {
                        AddTile(newRow);
                    }
                }
            }
        }

        List<string> emptyRow = new List<string>();
        AddTile(emptyRow);

        return allValidRows;
    }




    public static bool TileArrangementIsValid(List<string> row)
    {
        for (int tile = 0; tile < row.Count - 1; tile++)
        {
            for (int square = 0; square < row[tile].Length; square++)
            {
                if (row[tile][square] == row[tile + 1][square])
                {
                    return false;
                }
            }
        }
        return true;
    }




    public static List<string> GetAllTilePermutations(List<string> allManufacturerTiles)
    {
        List<string> allPermutations = new List<string>();

        foreach (string tile in allManufacturerTiles)
        {
            allPermutations.Add(tile);
            string rotatedTile = "";
            for (int i = tile.Length - 1; i >= 0; i--)
            {
                rotatedTile += tile[i];
            }
            if (rotatedTile != tile) allPermutations.Add(rotatedTile);
            
        }

        return allPermutations;
    }
}