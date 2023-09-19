public class Solution {

    /*
    The Exist method is the entry point of the solution. It takes the 2D board (board) and the target word (word) as input.

The code initializes the rowLength and colLength variables to store the dimensions of the board.

It iterates through each cell in the board using two nested loops (i for rows and j for columns).

For each cell at position (i, j), it calls the DFS (Depth-First Search) method to check if a path starting from that cell can form the given word. If DFS returns true, it means a valid path has been found, and the method returns true, indicating that the word can be formed.

If the loop completes without finding a valid path, the method returns false, indicating that the word cannot be formed on the board.

The DFS method is a recursive function that explores possible paths starting from a given cell (row, col) on the board.

The base case for the recursion is when the length of the path list equals the length of the target word. In this case, the method returns true because the entire word has been formed.

If the current cell (row, col) is out of bounds (i.e., outside the board), contains a character different from the current character in the word, or has already been visited (present in the path list), the method returns false.

If none of the above conditions are met, the current cell (row, col) is marked as visited by adding it to the path list. Then, the method recursively calls DFS for the neighboring cells (up, down, left, right) with an incremented index to check the next character in the word.

If any of the recursive calls return true, the method sets result to true. After exploring all neighbors, the current cell (row, col) is removed from the path list to backtrack.

Finally, the method returns the result variable, which indicates whether a valid path was found.

The code uses depth-first search to explore all possible paths on the board, and it backtracks when necessary. If a path is found that matches the target word, the method returns true; otherwise, it returns false.

This algorithm ensures that all possible paths are explored on the board to determine whether the word can be formed.
*/

    int rowLength, colLength;
    public bool Exist(char[][] board, string word) {
        rowLength = board.Length;
        colLength = board[0].Length;
        for(int i=0; i< rowLength; i++)
        {
            for(int j=0; j<colLength; j++)
            {
                if(DFS(board, word, new List<(int, int)>(), i, j, 0))
                {
                    return true;
                }
            }
        }
        return false;
    }
    private bool DFS(char[][] board, string word, IList<(int, int)> path, int row, int col, int index)
    {
        if(path.Count == word.Length)
        {
            return true;
        }
        if(row < 0 || col < 0 || row >= rowLength || col >= colLength||
          word[index] != board[row][col] ||  path.Contains((row, col)))
        {
            return false;
        }
        path.Add((row,col));
        bool result = (DFS(board, word, path, row + 1, col, index + 1) ||
                        DFS(board, word, path, row - 1, col, index + 1) ||
                        DFS(board, word, path, row, col + 1, index + 1) ||
                        DFS(board, word, path, row, col - 1, index + 1));
        path.Remove((row, col));
        return result;
    }
}