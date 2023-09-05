public class Solution {
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2) {
        /*
        Brute force
        Loop over every element in the first list and for each element we loop over the elements in the second list to check if its present or not.
        If present dont store in list
        Otherwise store
        */

        /*
        Hash set
        Store the elements in second array in hash set
        Iterate over each element in the first array
            For each element check if its in the hashset
            If yes skip
            no add to list
        */

        IList<IList<int>> results = new List<IList<int>>();
        results.Add(GetElementsOnlyInFirstList(nums1, nums2));
        results.Add(GetElementsOnlyInFirstList(nums2, nums1));

        return results;

    }

    public List<int> GetElementsOnlyInFirstList(int[] nums1, int[] nums2)
    {
        HashSet<int> onlyNumsInOne = new HashSet<int>();
        HashSet<int> existsInTwo = new HashSet<int>();

        // store all nums2 elements in hashset
        foreach(int num in nums2)
        {
            existsInTwo.Add(num);
        }

        //Iterate over each element in nums1 if not preset add to set
        foreach(int num in nums1)
        {
            if(!existsInTwo.Contains(num))
            {
                onlyNumsInOne.Add(num);
            }
        }

        return onlyNumsInOne.ToList();

    }
}