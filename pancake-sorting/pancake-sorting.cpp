/*
Approach

The algorithm runs a loop over the values of the list, starting from the largest one
    At each round, we identifty the value to sort, which is the number we would put in place at this round
    We then locate the index of the value to sort
    If the value to sort is not at its place already, we can then perform at most two pancake flips
At the end of the round our value would be put in place
*/

class Solution {
public:
    vector<int> pancakeSort(vector<int>& arr) {
        vector<int> ans;
        
        for(int i =arr.size(); i > 0; i--)
        {
            int index = find(arr, i); //loacte the position for the value to sort in this round
            
            //sink the value to sort to the bottom, with at most two steps of pancake flipping
            if(index == i - 1)
                continue;
            
            //flip the value to the head if necessary
            if(index != 0)
            {
                ans.push_back(index+1);
                flip(arr, index+1);
            }
            
            //now that the value is at the head, flip it to the bottom
            ans.push_back(i);
            flip(arr, i);
        }
        return ans;
    }
    
    void flip(vector<int>& sublist, int k)
    {
        int i = 0;
        while(i<k/2)
        {
            int temp = sublist[i];
            sublist[i] = sublist[k-i-1];
            sublist[k-i-1] = temp;
            i+=1;
        }
    }
    
    int find(vector<int>& a, int target)
    {
        for(int i = 0; i < a.size(); i++)
        {
            if(a[i] == target)
                return i;
        }
        return -1;
    }
};