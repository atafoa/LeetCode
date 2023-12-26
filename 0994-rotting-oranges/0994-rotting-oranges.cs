public class Solution {
    private int minutes = 0;
    public int OrangesRotting(int[][] grid) {
        var freshCount = 0;
        var rottenCoordinates = new Queue<(int i, int j)>();
        for (int i = 0; i < grid.Length; i++)
        {
            var row = grid[i];
            for (int j = 0; j < row.Length; j++)
            {
                if (row[j] == 1)
                {
                    freshCount++;
                }
                
                if (row[j] == 2)
                {
                    rottenCoordinates.Enqueue((i, j));
                }
            }
        }
        
        if (freshCount == 0)
        {
            return 0;
        }
        
        var minutes = -1;
        while (rottenCoordinates.Count > 0)
        {
            var count = rottenCoordinates.Count;
            
            while (count > 0)
            {
                var coordinates = rottenCoordinates.Dequeue();
                var i = coordinates.i;
                var j = coordinates.j;
                
                if (j < grid[i].Length - 1 && grid[i][j + 1] == 1)
                {
                    rottenCoordinates.Enqueue((i, j + 1));
                    grid[i][j + 1] = 2;
                    freshCount--;
                }
                
                if (i > 0 && grid[i - 1][j] == 1)
                {
                    rottenCoordinates.Enqueue((i - 1, j));
                    grid[i - 1][j] = 2;
                    freshCount--;
                }
                
                if (j > 0 && grid[i][j - 1] == 1)
                {
                    rottenCoordinates.Enqueue((i, j - 1));
                    grid[i][j - 1] = 2;
                    freshCount--;
                }
                
                if (i < grid.Length - 1 && grid[i + 1][j] == 1)
                {
                    rottenCoordinates.Enqueue((i + 1, j));
                    grid[i + 1][j] = 2;
                    freshCount--;
                }
                
                count--;
            }
            
            minutes++;
        }
        
        return freshCount > 0 ? -1 : minutes;
    }
}