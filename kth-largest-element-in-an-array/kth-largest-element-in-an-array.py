class Solution:
    def findKthLargest(self, arr: List[int], k: int) -> int:
        # First way is to sort the array and then return kth element from end (O(nlgn))
        # Another Idea is that kth largest element is the smallest of k largest numbers of nums array
        # So, we can use a min heap to store the k larger elements of nums, then top of this heap
        # is the kth largest element
        #This will have O(nlgk) time complexity
        #priority_queue<int, vector<int>, greater<int>> pq;
        #for (auto &num : nums) {
        #   pq.push(num);
        #   if (pq.size() > k)
        #       pq.pop();
        # }
        #return pq.top();
        start = 0
        end = len(arr) - 1
        answer = len(arr) - k
        while (start <= end):
            left = start
            right = end
            pivot = end
            while(left < right):
                while (arr[left] < arr[pivot] and left < right):
                    left += 1
                while (arr[right] >= arr[pivot] and right > left):
                    right -= 1
                arr[left], arr[right] = arr[right], arr[left]
            arr[left], arr[pivot] = arr[pivot], arr[left]
            if left == answer:
                return arr[answer]
            if left < answer:
                start = left + 1
            else:
                end = left - 1
        return None