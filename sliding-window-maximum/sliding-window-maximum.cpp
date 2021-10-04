/*
Approach Max heap
 vector<int> maxSlidingWindow(vector<int>& nums, int k) 
    {
        // create a priority queue (Max Heap) of pair of int
        // first of the pair is the element of the array
        // and second is the index
        priority_queue<pair<int,int>> p;
        // create a vector to store the result
        vector<int>res;
        // add all the elements in the first window to the PQ
        for(int i = 0; i < k; i++)
            p.push({arr[i],i});
        // add the max element of first window to the res vector
        res.push_back(p.top().first);
        // start iteration from the second window
        for(int i = k; i < arr.size(); i++)
        {
            // add the element into the PQ
            p.push({arr[i],i});
            // remove all the elments which are not in the current window
            // current window is from [i-k+1 , i]
            while(!(p.top().second > i-k))
                p.pop();
            // add the max element in the PQ to the res
            res.push_back(p.top().first);
        }
        // return the result
        return res;
        
    }

The TC should be O(n*logK). Here is why-

Max size of heap at any time is K.
We are inserting every element in the heap once which will cost us O(nlogK)
The inner loop is used to remove elements from the heap. So it will also run N times in total which will cost us O(nlogK)
Hence total TC will be 2O(nlogK) == O(n*logk)

And space complexity will be O(k) for maxheap.

More efficient Dequeue
Intuition behind this is very simple. In previous solution, we were pushing every element into the heap. Here we push only the elements which are candidate for becoming the answer.
vector<int> maxSlidingWindow(vector<int>& arr, int k) {
        deque<int> dq;
        vector<int> res;
        
        for(int i = 0; i < arr.size(); i++)
        {
            // insert current element
			// insert current element only when the back of the deque is greater than cur
            int cur = arr[i];
            while(dq.empty() == false and arr[dq.back()] < cur)
                dq.pop_back();
            dq.push_back(i);
            
            // remove out of bound elements
            while(dq.empty() == false and dq.front() < i-k+1)
                dq.pop_front();
            
			// max element of the window will be the front of the deque
            if(i >= k-1)
                res.push_back(arr[dq.front()]);
        }
        return res;
    }
    
Here we are pushing and poping every element into the deque only once. So the inner loops will have tc= O(n) amortized.
So TC: O(n)
SC: O(k)
*/

class Solution {
public:
   vector<int> maxSlidingWindow(vector<int>& arr, int k) {
        deque<int> dq;
        vector<int> res;
        
        for(int i = 0; i < arr.size(); i++)
        {
            // insert current element
			// insert current element only when the back of the deque is greater than current element
            int cur = arr[i];
            while(dq.empty() == false and arr[dq.back()] < cur)
                dq.pop_back();
            dq.push_back(i);
            
            // remove out of bound elements
            while(dq.empty() == false and dq.front() < i-k+1)
                dq.pop_front();
            
			// max element of the window will be the front of the deque
            if(i >= k-1)
                res.push_back(arr[dq.front()]);
        }
        return res;
    }
};

