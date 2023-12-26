public class Solution {
    public void Solve(char[][] board) {
        var queue = new Queue<KeyValuePair<int, int>>(); 
        
        // Get coordinates of 'O' cells on the left and right border and add to queue
        for (int row = 0; row < board.Length; ++row) {
            // Check left border
            if (board[row][0] == 'O') {
                queue.Enqueue(new KeyValuePair<int, int>(row, 0));
            }
            // Check right border
            if(board[row][board[row].Length - 1] == 'O') {
                queue.Enqueue(new KeyValuePair<int, int>(row, board[row].Length - 1));
            }
        }
        
        // Get coordinates of 'O' cells on the top and bottom border and add to queue
        for (int col = 0; col < board[0].Length; ++col) {
            // Check top border
            if (board[0][col] == 'O') {
                queue.Enqueue(new KeyValuePair<int, int>(0, col));
            }
            // Check bottom border
            if (board[board.Length - 1][col] == 'O') {
                queue.Enqueue(new KeyValuePair<int, int>(board.Length - 1, col));
            }
        }
        
        // 2D bool array to keep track of 'O' cells connected to the ones on the outer border
        var visited = new bool[board.Length][];
        for (int row = 0; row < board.Length; ++row) {
            visited[row] = new bool[board[row].Length];
        }
        
        // Search directions
        var directions = new List<KeyValuePair<int, int>>() {
            // Right
            new KeyValuePair<int, int>(0, 1),
            // Left
            new KeyValuePair<int, int>(0, -1),
            // Top
            new KeyValuePair<int, int>(-1, 0),
            // Bottom
            new KeyValuePair<int, int>(1, 0),
        }; 
        
        // Find all 'O' cells connected to the ones on the outer border
        while (queue.Count > 0) {
            var current = queue.Dequeue();

            // Get current coordinates 
            var currentRow = current.Key;
            var currentCol = current.Value;

            // Mark cell as visited, which means its connected to a border cell
            visited[currentRow][currentCol] = true;

            // Search right, left, top, bottom for connected 'O' cells
            foreach (var direction in directions) {
                var newRow = currentRow + direction.Key;
                var newCol = currentCol + direction.Value;

                // Add connected cells to the queue
                if (IsValidCell(board, newRow, newCol) && board[newRow][newCol] == 'O' && !visited[newRow][newCol]) {
                    queue.Enqueue(new KeyValuePair<int, int>(newRow, newCol));
                }
            } 
        }
        
        // Mark the 'O' cells not connected to outer borders as X
        for (int row = 0; row < board.Length; ++row) {
            for (int col = 0; col < board[row].Length; ++col) {
                if (board[row][col] == 'O' && !visited[row][col]) {
                    board[row][col] = 'X';
                }
            }
        }        
    }
    
    private bool IsValidCell(char[][] board, int row, int col) {
        return row >= 0 && row < board.Length && col >= 0 && col < board[row].Length;
    }   
}