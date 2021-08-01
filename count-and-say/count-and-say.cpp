class Solution {
public:
    string countAndSay(int n) 
    {
        if(n==1)
            return "1";
        if(n==2)
            return "11";
        string ans1;
        string temp="11";
        for(int i=2;i<n;i++)
        {
            ans1="";
            for(int j=0;j<temp.size();j++)
            { 
                int freq=1;
                while(temp[j]==temp[j+1])
                {
                    freq++;
                    j++;
                }
                ans1+=to_string(freq)+temp[j];
                freq=1;
            }
            temp=ans1;
        }
        return ans1;
    }
};