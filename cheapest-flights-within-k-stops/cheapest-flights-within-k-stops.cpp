/*
Simple dfs approach :
1. create an adjacency list for graph where graph[i] stores all the edges ith vertex hjas in form of {destination, pair}
2. Since the destination is not changing the unique state of dp depends on: source, number of stores therefore we need a second dp array
3. we pass k+1 stops, as everytime we encounter a city we subtract a stop. so even if we encounter destination, we would have subtracted and additional stop, so +1
4. If we encounter a city we explore all fligjhts from that cuty if that city is our destination we stop the function
5. Memoize for runtime


Alternativer dijkstra's algorithm (python)
class Solution:
	def findCheapestPrice(self, n: int, flights: List[List[int]], src: int, dst: int, k: int) -> int:
    
		#: use Dijkstra algorithm with min-heap
		#: use visited but if find node with less stop consider the node into the heap
		import heapq
		
		#: build the adj. map
		adj_map = {}
		for [sour, dest, price] in flights:
			adj_map[sour] = adj_map.get(sour, [])
			adj_map[sour].append((dest, price))

		#: init 
		queue = []
		visited = {}

		heapq.heappush(queue, (0, src, -1)) #: (price, destination, stop)
	
		while queue:
			(price, node, stops) = heapq.heappop(queue)

			#: add to visited if node is NOT in visited or "stops" is less than existing stops.
			if node not in visited or (node in visited and stops < visited[node][0]): 
				#: check to see if the node is dst
				if node == dst:
					if node not in visited:  #: if node is the dst node, make sure not visited before
						if stops <= k:      #: only if the stops less than equals to k
							visited[node] = (stops, price)
				else:
					visited[node] = (stops, price)    

				#: add all adj nodes to the queue
				if node in adj_map:
					for (neighbor, neighbor_price) in adj_map[node]:
						heapq.heappush(queue, (price + neighbor_price, neighbor, stops+1))

		#: return price in the visited[dst]
		if dst in visited:
			return visited[dst][1] #: return the price

		return -1

*/


class Solution {
public:
    
    int helper(int src, int dest, vector<pair<int,int>> graph[], int k, int dp[100][102])
    {
        if(k < 0)
            return INT_MAX; //number of stops exceeds what is max allowed;
        
        if(src == dest)
            return 0;
        
        if(dp[src][k] != -1)
            return dp[src][k];
        
        int ans = INT_MAX;
        
        for(int i = 0; i < graph[src].size(); i++)
        {
            int a = helper(graph[src][i].first, dest, graph, k-1, dp);
            ans = min(ans, (a == INT_MAX)?a: a+graph[src][i].second); //if path is not possible a = int_max else current cost is a + current edge weight
        }
        return dp[src][k] = ans;
    }
    
    int findCheapestPrice(int n, vector<vector<int>>& flights, int src, int dst, int k) {
        
        int numFlights = flights.size();
        vector<pair<int, int>> graph[n];
        int dp[100][102];
        memset(dp, -1, sizeof(dp));
        
        for(int i = 0; i < numFlights; i++) 
        {
            graph[flights[i][0]].push_back({flights[i][1], flights[i][2]}); //adjacency list
        }
        
        int ans = helper(src, dst, graph, k + 1, dp);
        return (ans == INT_MAX) ? -1 : ans; //if path not possible return -1
        
    }
};