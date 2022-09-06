class Solution {
public:
    void rotate(vector<vector<int>>& matrix) {
        int N = matrix.size();
        // 1st: [i][j]
        // 2nd: [j][N-1-i]
        // 3rd: [N-1-i][N-1-j]
        // 4th: [N-1-j][i]
        for (int i = 0; i < (N + 1) / 2; ++i) {
            for (int j = 0; j < N / 2; ++j) {
                // to rotate 90 degree clockwise. Sequence: 
                // 1st <- 4th. 
                // 4th <- 3rd
                // 3rd <- 2nd
                // 2nd <- 1st
                
                // tmp <- 1st
                int tmp = matrix[i][j];
                // 1st <- 4th
                matrix[i][j] = matrix[N-1-j][i];
                // 4th <- 3rd
                matrix[N-1-j][i] = matrix[N-1-i][N-1-j];
                // 3rd <- 2nd
                matrix[N-1-i][N-1-j] = matrix[j][N-1-i];
                // 2nd <- tmp(aka 1st)
                matrix[j][N-1-i] = tmp;
            }
        }
        return;
    }
};