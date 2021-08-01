class Solution {
    int[][] dp;
    public int minPathSum(int[][] grid) {
        // -1 represents unchanged
        dp = new int[grid.length][grid[0].length];
        for(int i=0; i<grid.length; i++){
            for(int j=0; j<grid[i].length; j++){
                dp[i][j] = -1;
            }
        }
        return recurse(grid, 0, 0, grid.length-1, grid[0].length-1);
    }
    
    public int recurse(int[][] grid, int m, int n, int tm, int tn){
        if(m==tm && n==tn){
            return grid[m][n];
        }else{
            int min = Integer.MAX_VALUE;
            // down
            if(m<tm){
                // check for memoized values
                if(dp[m+1][n] != -1){
                    // if smaller than current min
                    if(dp[m+1][n] < min){
                        min = dp[m+1][n];
                    }
                }else{
                    // calculate distance
                    dp[m+1][n] = recurse(grid, m+1, n, tm, tn);
                    if(dp[m+1][n] < min){
                        min = dp[m+1][n];
                    }
                }
            }
            
            // right
            if(n<tn){
                // check for memoized values
                if(dp[m][n+1] != -1){
                    // if smaller than current min
                    if(dp[m][n+1] < min){
                        min = dp[m][n+1];
                    }
                }else{
                    // calculate distance
                    dp[m][n+1] = recurse(grid, m, n+1, tm, tn);
                    if(dp[m][n+1] < min){
                        min = dp[m][n+1];
                    }
                }
            }
            
            return grid[m][n] + min;
        }
    }
}