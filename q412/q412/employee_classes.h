/********************************************
** employee_classes.h
** Header file for Manager, Peon, and Trainer classes
** Joseph Silverstein, 4/4/11
*********************************************/

#ifndef EMPLOYEE_CLASSES_H
#define EMPLOYEE_CLASSES_H

#include <string>
using namespace std;

class Employee {
public:
	Employee();
	Employee(string new_firstName, string new_lastName, double new_salary);
	//Employee(const Employee& e);
	friend istream& operator>> (istream& in, Employee& right);
	friend ostream& operator<< (ostream& out, const Employee& right);
	string get_firstName() const;
	string get_lastName() const;
	double get_salary() const;
	virtual void print();
protected:
	string firstName, lastName;
	double salary;
};

// a manager is an employee with a store field
class Manager : public Employee {
public:
	Manager(string new_firstName, string new_lastName, double new_salary, string new_store);
	friend istream& operator>> (istream& in, Manager& right);
protected:
	string store; // the store that the manager manages
};

// a peon is an employee with an hours field
class Peon : public Employee {
public:
	Peon(string new_firstName, string new_lastName, double new_salary, int new_hours);
protected:
	int hours; // of of hours worked
};

// a trainer is an employee with a "subject taught" field
class Trainer : public Employee {
public:
	Trainer(string new_firstName, string new_lastName, double new_salary, string new_subject);
protected:
	string subject; // subject taught by trainer
};

#endif