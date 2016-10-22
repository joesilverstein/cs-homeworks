//Test main routine for Complex class

#include "complex.h"
#include <iostream>
using namespace std;

int main() {
	Complex x;
	Complex y;
	cout << "Enter first complex number: ";
	cin >> x;
	cout << "Enter second complex number: ";
	cin >> y;
	
	cout << x << " + " << y << " = " << x+y << "\n";
	cout << x << " - " << y << " = " << x-y << "\n";
	cout << "(" << x << ") * (" << y << ") = " << x*y << "\n";
	cout << "(" << x << ") / (" << y << ") = " << x/y << "\n";
	cout << "(" << x << ")^4 = " << (x^4) << "\n";
	//cout << "(" << x << ")^4 = " << x^4 << "\n";*/
	
	return 0;
}
