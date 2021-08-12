'''
Create a graph by having an node for each unique num and adding an edge between nodes where their value differs by 1
Find the strongly connected components in the graph. Since this is an undirected graph that can be done by a simple DFS. In a directed graph it would be more complicated.
Return the length of the largest SCC in the graph
Time and space complexity O(n).
'''
class Solution:
    def longestConsecutive(self, nums: List[int]) -> int:
        graph = self.constructGraph(nums)
        components = self.getStronglyConnectedComponents(graph)
        return max(len(c) for c in components) if len(components) > 0 else 0
    
    def constructGraph(self, nums):
        nums = set(nums)
        graph = {}
        for num in nums:
            graph[num] = []
            if num-1 in nums:
                graph[num].append(num-1)
            if num+1 in nums:
                graph[num].append(num+1)
        return graph
    
    def getStronglyConnectedComponents(self, graph):
        visited = set()
        components = []
        for node in graph:
            if node in visited:
                continue
            currentComponent = []
            self.explore(node, graph, visited, currentComponent)
            components.append(currentComponent)
        return components
            
    def explore(self, node, graph, visited, currentComponent):
        currentComponent.append(node)
        visited.add(node)
        for neighbor in graph[node]:
            if neighbor in visited:
                continue
            self.explore(neighbor, graph, visited, currentComponent)
        return
        