class Solution {
public:
    bool dfs(int i, int j, int curr, string word, vector<vector<char>> &board){
        if(curr == word.size()){
            return true;
        }
        
        if(i<0 or i>=board.size() or j<0 or j>=board[i].size() or board[i][j] != word[curr])
            return false;
        
        
        char temp = board[i][j];
        board[i][j] = ' ';
        
        bool ans = dfs(i + 1, j , curr + 1, word, board)
            or dfs(i - 1, j, curr + 1, word, board)
            or dfs(i, j + 1, curr + 1, word, board)
            or dfs(i, j - 1, curr + 1, word, board);
        
        board[i][j] = temp;
        
        return ans;        
    }
    
    bool exist(vector<vector<char>>& board, string word) {
        for(int i=0; i<board.size(); i++){
            for(int j=0; j<board[i].size(); j++){
                if(board[i][j] == word[0] and dfs(i, j, 0, word, board)){
                    return true;
                }
            }
        }
        
        return false;
    }
};