public class Solution {
    public int LeastBricks(IList<IList<int>> wall) {
        
        // Time complexity: O (m*n + k)
        // Space complexity:O(k)
        Dictionary<int, int> dict = new();
        foreach (var col in wall)
        {
            var sum = 0;
             //we don't consider the last brick
             for(var i = 0; i<col.Count-1; i++)
             {
                sum += col[i];
                if(!dict.ContainsKey(sum))
                {
                    dict.Add(sum,0);
                }
                dict[sum]++;
             }
        }
        
        var res = wall.Count;
        foreach(var dic in dict )
        {
            res = Math.Min(res, wall.Count - dic.Value);
        }
        return res;
    }
}