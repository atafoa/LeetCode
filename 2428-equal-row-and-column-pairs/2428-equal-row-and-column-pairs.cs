public class Solution {
    public int EqualPairs(int[][] grid) {
        /*
        Brute force
        iterate over each row in grid
        for each column in grid
            check if row r equals column c by comparing each element at the same index in both r and c
            if equal increase count by 1
        reurn count

        Hash map
        create a hash map and set the count to 0
        For each row in the grid store it in a hash map with the frequency
        for reach column convert it into the same type of hashtable object
            check if it already exists in the hash map
            if it exists increment the count by the frequency
        return count
        */

        int count = 0, n = grid.Length;
        
        //keep track of the frequency of each row
        Dictionary<string, int> rowCounter = new Dictionary<string, int>();

        foreach(int[] row in grid)
        {
            string rowString = string.Join(",", row);
            if(rowCounter.ContainsKey(rowString))
            {
                rowCounter[rowString]++;
            }
            else
            {
                rowCounter.Add(rowString, 1);
            }
        }

        //add up the frequencies of each column in map
        for(int c = 0; c < n; c++)
        {
            int[] colArray = new int[n];
            for (int r = 0; r < n; ++r)
            {
                colArray[r] = grid[r][c];
            }
            string colString = string.Join(",", colArray);
            
            if(rowCounter.ContainsKey(colString))
            {
                count += rowCounter[colString];
            }
        }

        return count;
    }
}