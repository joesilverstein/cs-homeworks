/********************************************
** complex.cpp
** Allows handling of complex numbers.  
** Implements complex arithmetic.
** Joseph Silverstein, 3/30/11
*********************************************/

#include "complex.h"

// default constructor
Complex::Complex() {
	real=imaginary=0;
}

// overloads >> to read in the real and imaginary parts of the complex number
istream& operator>> (istream& in, Complex& right) {
	in >> right.real >> right.imaginary; // reads in real and imaginary components, ignoring '+'
	in.ignore(1,'\n'); // ensures that in reads the next entry
	return in;
}

// overloads << to print out a complex number in an easy to read format
ostream& operator<< (ostream& out, const Complex& right) {
	out << right.real;
	if (right.imaginary > 0)
		out << "+";
	if (right.imaginary != 0)
		out << right.imaginary;
	if (right.imaginary != 0)
		out << "i";
	return out;
}

// overloads + to compute the sum of two complex numbers
Complex Complex::operator+ (const Complex& right) {
	Complex sum;
	sum.real = real + right.real;
	sum.imaginary = imaginary + right.imaginary;
	return sum;
}

// overloads - to compute the difference of two complex numbers
Complex Complex::operator- (const Complex& right) {
	Complex difference;
	difference.real = real - right.real;
	difference.imaginary = imaginary + right.imaginary;
	return difference;
}

// overloads * to compute the difference of two complex numbers
Complex Complex::operator* (const Complex& right) {
	Complex result;
	result.real = real*right.real - imaginary*right.imaginary;
	result.imaginary = real*right.imaginary + imaginary*right.real;
	return result;
}

// overloads / to divide two complex numbers
Complex Complex::operator/ (const Complex& right) {
	Complex result;
	result.real = (real*right.real + imaginary*right.imaginary) / (((int)right.real)*((int)right.real) + ((int)right.imaginary)*((int)right.imaginary));
	result.imaginary = (imaginary*right.real - real*right.imaginary) / (((int)right.real)*((int)right.real) + ((int)right.imaginary)*((int)right.imaginary));
	return result;
}

// overloads ^ to compute the difference of two complex numbers
// only works correctly for positive integer powers
Complex Complex::operator^ (const int& right) {
	Complex result = *this;
	for (int i=1; i<4; i++) {
		result = result * (*this);
	}
	return result;
}

// overloads = operator for complex numbers
Complex& Complex::operator= (const Complex& right) {
	real = right.real;
	imaginary = right.imaginary;
	return *this;
}