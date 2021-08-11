/*
Intuition:

For a moment lets forget about the player and reduce our problem to what is the minimum push that is required to place the box to it's target? , the obvious answer come to our mind is to use BFS to get this answer.
Now we can assume what if someone has to push the box to place it to target and we have given the player position in matrix. It is also given that player can move in all 4 directions, it means same movement is also allowed to box if we are pushing it along the way.
Then we can ask ourselves.. ohh how do we do that? How can we reach box, then only we can push. We can simply use dfs to get the answer. Like if box is reachable then we might push it along the way if push is valid.
Now for a moment just ignore constraint and ask ourselves what if player is doing same push again? Like if we are doing same push again then it is of no use to us. So we can store this information in a set using pair. [You can think it is as a loop in a graph]
Consider below example, assume we pushed B to its right when player stands left to B. But current player's position S' can be reached via different path in this matrix. So this push we save in a set and for next same push we can ignore as result will be same.

		   [["#","#","#","#","#","#"],
           ["#","T",".",".","#","#"],
           ["#",".","S'","B",".","#"],
           ["#",".",".",".",".","#"],
           ["#",".",".",".","S","#"],
           ["#","#","#","#","#","#"]]
So final Idea is to first do dfs to reach box with given constraint and then add all possible push to queue [basically all its neighbor push].
To handle case where we cannot pass through the box, before we start visiting all the neighbors of current Box position , we set the value in grid to # and then revert it back to .

*/
class Solution {
public:
    //direction vector
    vector<vector<int>> dir {{0,1},{0,-1},{1,0},{-1,0}};
    
    int minPushBox(vector<vector<char>>& grid) {
        //rows, cols
        int N = grid.size();
        int M = grid[0].size();
        
        //intitial position
        int target=-1, box =-1, player = -1;
        
        //calcluate distance of target, box, player in grid
        for(int i=0; i<N;i++){
            for(int j=0;j <M;j++){
                if(grid[i][j]=='S'){
                    player = i * M + j;
                }
                if(grid[i][j]=='B'){
                    box = i*M + j;
                }       
                if(grid[i][j]=='T'){
                    target = i*M + j;
                }
            }
        }
        //set stl to track player-box movement
        //if already visited same path, ignore it
        set<pair<int, int>> visited;
        visited.insert({player, box});
        
        //declare queue for BFS
        //move box to all it's eligible neighbor
        queue<pair<int,int>> q;
        q.push({player, box});
        
        int ans =0;
        while(!q.empty()){
            
            ans++;
            
            //size of neighbor to be visited
            int size = q.size();
            
            while(size--){
                
                auto f = q.front();
                q.pop();
                
                //current box position 
                int box_curr = f.second;
                //get box position in matrix
                int box_x = box_curr/ M;
                int box_y = box_curr % M;
                //palyer position
                int p = f.first;
                
                //make grid with box as obstacle 
                grid[box_x][box_y] = '#';
                
                for(auto &d : dir){
                    
                    int new_box_x = box_x + d[0];
                    int new_box_y = box_y + d[1];
                    
                    int px = box_x - d[0];
                    int py = box_y - d[1];
                    
                    //to be used in dfs walk by player to reach box
                    vector<vector<int>> walk(N, vector<int>(M, 0));
                    
                    if(isValid(grid, new_box_x, new_box_y) && canWalk(grid, p/M, p %M, px, py, walk) && visited.count({px * M + py, new_box_x*M + new_box_y})==0){
                        
                        if(new_box_x == target/M && new_box_y==target%M)
                            return ans;
                        
                        visited.insert({px * M + py, new_box_x * M + new_box_y});
                        q.push({px * M + py, new_box_x * M + new_box_y});
                    }
                }        
                grid[box_x][box_y] = '.';
            }
            
        }
            
        return -1;
    }
    
    bool isValid(vector<vector<char>>& grid, int i, int j){
        if(i < 0 || i>=grid.size() || j <0 || j>=grid[0].size() || grid[i][j]=='#')
            return false;
        
        return true;
    }
    
    bool canWalk(vector<vector<char>>& grid, int x, int y, int i, int j, vector<vector<int>>& walk){
        if(x==i && y==j)
            return true;
        
        for(auto &d: dir){
            int nx = x + d[0], ny = y+d[1];   
            if(isValid(grid, nx, ny) && walk[nx][ny] == 0){
                walk[nx][ny] = 1;
                if(canWalk(grid, nx, ny, i, j, walk))
                    return true;
            }
        }
        return false;
    }
};