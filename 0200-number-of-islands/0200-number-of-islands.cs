public class Solution {
    public int NumIslands(char[][] grid) 
    {
        (int Row, int Column)[] directions = new[] {(-1, 0), (1, 0), (0, -1), (0, 1)};
        Queue<(int Row, int Column)> queue = new();
        
        int result = 0;
        
        for (int i = 0; i < grid.Length ; i++)
            for (int j = 0; j < grid[i].Length ; j++)
            {
                if (grid[i][j] == '1')
                {                
                    result++;
                    queue.Enqueue((i, j));
                    while (queue.Count > 0)
                    {
                        var p = queue.Dequeue();
                        foreach (var dir in directions)
                        {
                            int r = p.Row + dir.Row;
                            int c = p.Column + dir.Column;
                            
                            if(r >=0 && r < grid.Length &&
                               c >= 0 && c < grid[r].Length &&
                               grid[r][c] == '1')
                            {
                                grid[r][c] = '2';
                                queue.Enqueue((r, c));
                            }
                        }
                    }
                }
            }
        
        return result;
    }
}