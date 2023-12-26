/*
DFS with backtracking
*/


public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
          var n = candidates.Length;
        Array.Sort(candidates);
        var result = new List<IList<int>>();
        var combination = new List<int>(); 
        Dfs(0, 0);
        
        return result;
        
        void Dfs(int startIdx, int sum)
        {            
            for(int i = startIdx; i < n; i++)
            {
                sum += candidates[i];
                combination.Add(candidates[i]);
                if (sum < target)
                {
                    Dfs(i, sum);
                }
                else if (sum == target)
                {
                    result.Add(new List<int>(combination));
                }
                else 
                {
                    combination.Remove(candidates[i]);
                    break; // to skip candidates that are also greater
                }                               
                combination.Remove(candidates[i]);
                sum -= candidates[i];                
            }
        }        
    }
}