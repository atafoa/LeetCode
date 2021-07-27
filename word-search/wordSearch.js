function wordSearch(matrix, target) {
  let visited = new Set();
  let wordFound = false;

  function search(x, y, index) {
    if (index === target.length) {
      wordFound = true;
      return;
    }
    if (y < 0 || x < 0 || y >= matrix.length || x >= matrix[0].length) {
      return;
    }
    if (matrix[y][x] !== target[index]) {
      return;
    }
    if (wordFound) {
      return;
    }
    let key = x + '_' + y;
    if (visited.has(key)) {
      return;
    }

    visited.add(key);
    search(x + 1, y, index + 1);
    search(x - 1, y, index + 1);
    search(x, y + 1, index + 1);
    search(x, y - 1, index + 1);
    visited.delete(key);
  }


  for (let y = 0; y < matrix.length; y++) {
    for (let x = 0; x < matrix[0].length; x++) {
      search(x, y, 0);
    }
  }

  return wordFound;
};

Input:

matrix = [
 ['a', 'b', 'c', 'd'],
 ['e', 'f', 'g', 'h'],
 ['i', 'd', 'o', 'j'],
 ['k', 'l', 'm', 'n']
]

'dog' -> true
'abcgfd' -> true
'don' -> false
