/*
    Since the given candidates are unique, if we can simply sort the array we can iterate over the same to find all combinations of elements which forms the sum equals to target.

"Sorting" is only used to make the finding of combination efficient, where we can ignore the further elements if the current sum itself is greater than the target. So one can solve this withoug sorting also.

Also, we need to consider that the sum can be formed using the same element multiple times.

We use backtracking to solve this, where we'll also recursively perform the operations on same index position too for considering the same element multiple times.
*/


public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        IList<IList<int>> result = new List<IList<int>>();
        
        //Sorting is to reduce the number of recursions
        Array.Sort(candidates);
        BackTrackCombiSum(candidates, target, 0, new List<int>(), result);
        
        return result;
    }
    
    private void BackTrackCombiSum(int[] candidates, int target, int idx
        , List<int> temp, IList<IList<int>> result)
    {
        if (target == 0)
        {
            result.Add(temp.ToList());
            return;
        }
        else
        {
            while (idx < candidates.Length)
            {
                if (candidates[idx] > target)
                {
                    break;
                }

                temp.Add(candidates[idx]);
                BackTrackCombiSum(candidates, target - candidates[idx], idx, temp, result);
                temp.RemoveAt(temp.Count - 1);

                idx++;
            }
        }
    }
}