#include <iostream>
#include <cstring>
#include <cmath>
#include <vector>
#include <deque>

using namespace std;

class Node {
  public:
    int px;
    int py;
    int dist;
    bool visited = false;
    Node(int x, int y, int d, bool v);
    Node() {};
};

Node::Node(int x, int y, int d, bool v) {
  px = x;
  py = y;
  dist = d;
  visited = v;
}

int main() {
  long long w, h;
  cin >> w >> h;

  string map[h];
  deque<Node> q;

  string inp;
  for (int i = 0; i < h; i++) {
    cin >> inp;
    map[i] = inp;

    int index = inp.find("S");
    if(index != string::npos) {
      q.push_front(Node(index, i, 0, true));
    }
  }
  string directions;
  cin >> directions;

  Node nodes[h][w];
  for (int i = 0; i < h; i++) {
    for (int j = 0; i < w; i++) {
      nodes[i][j] = Node(j, i, -1, map[i][j] != '.');
    }
  }

  int dirs[4][2] = {{0, -1}, {0, 1}, {1, 0}, {-1, 0}};

  while (!q.empty()) {
    Node curr = q.front();
    q.pop_front();

    cout << "looking at " << curr.px << ", " << curr.py << endl;

    for (int i = 0; i < 4; i++) {
      Node next = nodes[curr.py + dirs[i][1]][curr.px + dirs[i][0]];
      if (!next.visited) {
        next.dist = curr.dist + 1;
        next.visited = true;
        q.push_front(next);
      }
    }
  }

  for (int i = 0; i < h; i++) {
    for (int j = 0; i < w; i++) {
      int d = nodes[i][j].dist;
      if(d != -1) {
        map[i][j] = d;
      }
    }
  }

  for (auto &&s : map){
    cout << s << endl;
  }
  
  return 0;
}