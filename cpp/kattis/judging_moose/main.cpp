#include <iostream>
#include <cstring>
#include <cmath>

using namespace std;

int main() {
  long long a, b;
  cin >> a >> b;

  if (a == 0 and b == 0) {
    cout << "Not a moose" << endl;
  } else {
    string parity;
    parity = a == b ? "Even" : "Odd";
    cout << parity << " " << max(a, b) * 2 << endl;
  }
  return 0;
}