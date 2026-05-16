public class HallwayTiler
{
    static public int CountHallwayArrangements(int hallwayLength, int hallwayWidth, int tileLength, List<string> tiles)
    {
        /*
        n = Hallway length
        m = Hallway width
        t = Tile length
        */

        // Update the available tiles list to allow for rotating tiles.
        List<string> allTilePermutations = GetAllTilePermutations(tiles);

        // Construct all possible row permutations and combinations.
        List<List<string>> rows = GenerateAllValidRows(allTilePermutations, hallwayWidth);

        // Construct all possible hallways, given all possible rows.
        List<List<List<string>>> hallways = GenerateAllValidHallways(rows, tileLength, hallwayLength);

        // Return the number of possible hallways.
        return hallways.Count;
    }



    // Generates all possible hallways using the list of valid rows.
    public static List<List<List<string>>> GenerateAllValidHallways(List<List<string>> allRows, int tileLength, int hallwayLength)
    {
        // A list of hallways.
        List<List<List<string>>> allValidHallways = new List<List<List<string>>>();

        // A function to add a row to a hallway.
        void AddRow(List<List<string>> hallway)
        {
            // If the hallway length is equal to the required hallway length, then we can't add any more rows.
             // Add it to the list of valid hallways and this recursive branch ends here.
            if (hallway.Count * tileLength == hallwayLength) allValidHallways.Add(hallway);

            // Otherwise, check every combination possible from here.
            else
            {
                // For each available row.
                for (int row = 0; row < allRows.Count; row++)
                {
                    // Create a copy of the current hallway and add the row.
                    List<List<string>> newHallway = new List<List<string>> (hallway);
                    newHallway.Add(allRows[row]);

                    // If there's only one row, it must be valid. Add another row.
                    if (newHallway.Count == 1)
                    {
                        AddRow(newHallway);
                    }
                    // Otherwise, check if it's valid first then add another row.
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
    


    // Checks if the new row placement is valid.
    public static bool RowPlacementIsValid(List<string> previousRow, List<string> placedRow)
    {
        for (int tile = 0; tile < previousRow.Count; tile++)
        {
            if (previousRow[tile][^1] == placedRow[tile][0]) return false;
        }
        return true;
    }



    // Generates all possible valid rows using the updated tile list.
    public static List<List<string>> GenerateAllValidRows(List<string> allTilePermutations, int hallwayWidth)
    {
        // A list of rows.
        List<List<string>> allValidRows = new List<List<string>>();

        // A function to add a tile to a row.
        void AddTile(List<string> row)
        {
            // If the row length is equal to the hallway width, then we can't add any more tiles.
            // Add it to the list of valid rows and this recursive branch ends here.
            if (row.Count == hallwayWidth) allValidRows.Add(row);

            // Otherwise, check every combination possible from here.
            else
            {
                // For each available tile.
                for (int tile = 0; tile < allTilePermutations.Count; tile++)
                {
                    // Create a copy of the current row and add the tile.
                    List<string> newRow = new List<string> (row);
                    newRow.Add(allTilePermutations[tile]);

                    // If this new row is a valid arrangement, add another tile.
                    if (TileArrangementIsValid(newRow))
                    {
                        AddTile(newRow);
                    }
                }
            }
        }

        // Start with an emtpy row.
        List<string> emptyRow = new List<string>();
        AddTile(emptyRow);

        // Return the list of all possible valid rows.
        return allValidRows;
    }



    // Checks if the row is valid.
    // Note- this could be optimised to only check the last tile and the one before it.
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



    // Takes the original manufacturer tiles and checks if rotating 180 degrees produces a different tile.
    // Adds the new tile if this is the case.
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