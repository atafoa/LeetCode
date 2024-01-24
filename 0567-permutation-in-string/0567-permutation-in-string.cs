public class Solution 
{
    public bool CheckInclusion(string s1, string s2) 
    {
        if(s1.Length > s2.Length)
            return false;
        
        int[] bucket = new int[26];
        
        for(int i = 0; i < s1.Length; i++)
        {
            bucket[s1[i] - 'a']++;
            bucket[s2[i] - 'a']--;
        }
        
        if(IsValid(bucket))
            return true;
        
        for(int i = s1.Length; i < s2.Length; i++)
        {
            bucket[s2[i] - 'a']--;
            bucket[s2[i - s1.Length] - 'a']++;
            
            if(IsValid(bucket))
                return true;
        }
        
        return false;
    }
    
    public bool IsValid(int[] bucket)
    {
        for(int i = 0; i < 26; i++)
        {
            if(bucket[i] != 0)
            {
                return false;
            }
        }
        
        return true;
    }
}