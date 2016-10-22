/********************************************
** complex.h
** Header file for complex number class.
** Joseph Silverstein, 3/30/11
*********************************************/

#ifndef COMPLEX_H
#define COMPLEX_H

#include <iostream>
using namespace std;

class Complex {
public:
	Complex();
	friend istream& operator>> (istream& in, Complex& right);
	friend ostream& operator<< (ostream& out, const Complex& right);
	Complex operator+ (const Complex& right);
	Complex operator- (const Complex& right);
	Complex operator* (const Complex& right);
	Complex operator/ (const Complex& right);
	Complex operator^ (const int& right);
	Complex& Complex::operator= (const Complex& right);

private:
	double real; //real part
	double imaginary; // imaginary part
};

#endif