/*

Create scope variables called result and path, and initialize path to an empty array (or dynamic array).
Create a helper method that takes in two indices x and y, that represent the current position in the maze we'll be recursing over.
a) If a path is already found, stop recursing and return.

b) Failure base case: If row or col are out of bound or the value at maze[row][col] equals 1 return

c) Push [row, col] into path, to store the current location in the maze

d) Successful base case: if row or col are at the bottom right corner, set result to be a copy of path and return

e) Perform a recursive call going down (row + 1, col)

f) Perform a recursive call going right (row, col + 1)

g) Pop off the last element from the path array

h) If both recursive calls have returned without finding a path, we know this position is part of a dead end. To prevent future recursive calls from going down this path again, we can toggle the position in the original maze,maze[row][col], to be a 1. Making this change improves our time complexity from O(2^MN) to O(MN) by ensuring we don't repeatedly traverse unproductive paths.

Call the helper method with initial parameters of (0, 0)
If result is undefined return [-1, -1], otherwise return result

*/

function ratPath(maze) {
  let result;
  let path = [];
  function findPath(row, col) {
    //stop recursing once we find a result
    if(result !== undefined) {return;}
    if(row >= maze.length || col >= maze[0].length || maze[row][col] === 1) {
      return;
    }
    path.push([row, col]);
    if(row === maze.length - 1 && col === maze[0].length - 1) {
      result = path.slice();
      return;
    }
    findPath(row + 1, col);
    findPath(row, col + 1);
    path.pop();
    //Toggle dead ends into walls! This line is the only change needed to go from O(2^MN) to 0(MN)
    maze[row][col] = 1;
  }
  findPath(0, 0);
  return !result ? [-1, -1] : result;
}

let maze = [[0, 0, 0, 1],
	    [0, 1, 0, 1],
	    [0, 1, 0, 0],
	    [0, 0, 1, 0]]
console.log(ratPath(maze))

/*
[ [ 0, 0 ],
  [ 0, 1 ],
  [ 0, 2 ],
  [ 1, 2 ],
  [ 2, 2 ],
  [ 2, 3 ],
  [ 3, 3 ] ]
*/
