#include <iostream>
#include <cmath>

using namespace std;

int main() {
  long long n, w, h;
  cin >> n >> w >> h;
  
  auto max = sqrt(pow(w, 2) + pow(h, 2)); 

  long long inp;
  while (cin >> inp) {
    if (inp <= max) {
      cout << "DA" << endl;
    } else {
      cout << "NE" << endl;
    }
  }
  
  return 0;
}