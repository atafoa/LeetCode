class Solution:
    def longestIncreasingPath(self, matrix: List[List[int]]) -> int:
        
        directions = [(0, 1), (1, 0), (0, -1), (-1, 0)]
        if len(matrix) == 0: return 0
        num_of_rows, num_of_cols = len(matrix), len(matrix[0])
        cache = {}
        answer = 0
        
        def dfs(matrix, row, col):
            nonlocal cache
            nonlocal directions
            key = (row, col)
            if key in cache: return cache[key]
            cache[key] = 0
            for d in directions:
                next_row = row + d[0]
                next_col = col + d[1]

                if (next_row >= 0 and next_row < num_of_rows and next_col >= 0 and next_col < num_of_cols):
                    if (matrix[next_row][next_col] > matrix[row][col]):
                        cache[key] = max(cache[key], dfs(matrix, next_row, next_col))

            cache[key] += 1
            return cache[key]

        for row in range(num_of_rows):
            for col in range(num_of_cols):
                answer = max(answer, dfs(matrix, row, col))

        return answer
