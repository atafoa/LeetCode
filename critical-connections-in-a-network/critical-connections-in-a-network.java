/*

  Some useful videos I watched to understand the algorithm:
  https://www.youtube.com/watch?v=wUgWX0nc4NY&t=863s
  https://www.youtube.com/watch?v=RYaakWv5m6o&t=847s
  https://www.youtube.com/watch?v=erlX-1MJlv8&t=2s
*/


private int time;
private int[] disc;
private int[] low;
private List<List<Integer>> graph;
public List<List<Integer>> criticalConnections(int n, List<List<Integer>> connections) {
	initialize(n, connections);
	List<List<Integer>> res = new ArrayList<>();
	for (int i = 0; i < n; i++) {
		if (disc[i] == -1) {
			dfs(res, i, -1);
		}
	}
	return res;
}
private void dfs(List<List<Integer>> res, int cur, int parent) {
	disc[cur] = low[cur] = time++;
	for (int neighbor : graph.get(cur)) {
		if (neighbor == parent) {
			continue;
		}
		if (disc[neighbor] == -1) {
			dfs(res, neighbor, cur);
			if (disc[cur] < low[neighbor]) {
				res.add(Arrays.asList(cur, neighbor));
			}
			else {
				low[cur] = Math.min(low[cur], low[neighbor]);
			}
		}
		else {
			low[cur] = Math.min(low[cur], low[neighbor]);
		}
	}
}
private void initialize(int n, List<List<Integer>> connections) {
	time = 0;
	disc = new int[n];
	low = new int[n];
	Arrays.fill(disc, -1);
	Arrays.fill(low, Integer.MAX_VALUE);
	graph = buildGraph(n, connections);
}
private List<List<Integer>> buildGraph(int n, List<List<Integer>> connections) {
	List<List<Integer>> graph = new ArrayList<>();
	for (int i = 0; i < n; i++) {
		graph.add(new ArrayList<>());
	}
	for (List<Integer> connection : connections) {
		int nodeA = connection.get(0);
		int nodeB = connection.get(1);
		graph.get(nodeA).add(nodeB);
		graph.get(nodeB).add(nodeA);
	}
	return graph;
}
