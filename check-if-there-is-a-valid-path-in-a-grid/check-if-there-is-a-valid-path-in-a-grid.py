class Solution:
    def hasValidPath(self, grid: List[List[int]]) -> bool:
        move = {1:[[0,-1],[0,1]], 
                2:[[-1,0],[1,0]],
                3:[[1,0],[0,-1]],
                4:[[1,0],[0,1]],
                5:[[0,-1],[-1,0]],
                6:[[-1,0],[0,1]]
        }
        
        m = len(grid)
        n = len(grid[0])
        visited = set()
        
        def isValid(i,j):
            
            if i>=0 and i<m and j>=0 and j<n:
                return True 
            else:
                False
                
        def dfs(i,j,visited):
            
            #base case 
            
            if isValid(i,j)==False:
                return False
            
            if (i,j) in visited:
                return False
            
            if i==m-1 and j==n-1:
                return True
            
            current_cell = grid[i][j]
            visited.add((i,j))
            
            for potential_move in move[current_cell]:
                new_i = potential_move[0]+i
                new_j = potential_move[1]+j
                
                if isValid(new_i,new_j) and (new_i,new_j) not in visited:
                    next_item = grid[new_i][new_j]
                    
                    if [-potential_move[0],-potential_move[1]] in move[next_item]:
                        if dfs(new_i,new_j,visited):
                            return True 
                        
            visited.remove((i,j))
            return False
        
        return dfs(0,0,visited)