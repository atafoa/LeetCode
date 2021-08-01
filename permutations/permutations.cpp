class Solution {
public:
    void solve(vector<int> v, int l, int r, vector<vector<int>> &ans) {
        if(l == r) {
            ans.push_back(v);
            return;
        }
        for(int i = l; i <= r; i++) {
            swap(v[l], v[i]);
            solve(v, l+1, r, ans);
            swap(v[l], v[i]);
        }
    }
    
    vector<vector<int>> permute(vector<int>& nums) {
        vector<vector<int>> ans;
        solve(nums, 0, nums.size() - 1, ans);
        return ans;
    }
};