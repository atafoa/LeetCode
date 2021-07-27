class Solution {
public:
    vector<int> spiralOrder(vector<vector<int>>& matrix) {
        vector<int> results;
        if(!matrix.size())
            return results;
        int yMin = 0, xMin = 0;
        int yMax = matrix.size() - 1;
        int xMax = matrix[0].size() - 1;
        
        while(xMin <= xMax && yMin <= yMax)
        {
            for(int i = xMin; i <= xMax; i++)
            {
                results.push_back(matrix[yMin][i]);
            }
            yMin++;
            for(int i = yMin; i <= yMax; i++)
            {
                results.push_back(matrix[i][xMax]);
            }
            xMax--;
            if(yMin <= yMax)
            {
                for(int i = xMax; i >= xMin; i--)
                    results.push_back(matrix[yMax][i]);
                yMax--;
            }
             if(xMin <= xMax)
            {
                for(int i = yMax; i >= yMin; i--)
                    results.push_back(matrix[i][xMin]);
                xMin++;
            }
        }
        return results;
    }
};