/********************************************
** employee_classes.cpp
** Implements Manager, Peon, and Trainer classes
** Joseph Silverstein, 4/4/11
*********************************************/

#include "employee_classes.h"

Employee::Employee() {
	firstName = lastName = "-";
}

// Employee base class constructor
Employee::Employee(string new_firstName, string new_lastName, double new_salary) {
	firstName = new_firstName;
	lastName = new_lastName;
	salary = new_salary;
}

istream& operator>> (istream& in, Employee& right) {
	char type; // the type of employee
	in >> type
	   >> right.firstName 
	   >> right.lastName
	   >> right.salary;
	return in;
}

ostream& operator<< (ostream& out, const Employee& right) {
	out << right.firstName << " " 
		<< right.lastName << " "
		<< right.salary << "\n";
	return out;
}

string Employee::get_firstName() const {
	return firstName;
}

string Employee::get_lastName() const {
	return lastName;
}

double Employee::get_salary() const {
	return salary;
}

/** Manager class starts here **/

// Manager derived class constructor
Manager::Manager(string new_firstName, string new_lastName, double new_salary, 
				 string new_store) : Employee(new_firstName, new_lastName, new_salary) {
	store = new_store;
}

/** Peon class starts here **/

// Peon derived class constructor
Peon::Peon(string new_firstName, string new_lastName, double new_salary, 
		   int new_hours) : Employee(new_firstName, new_lastName, new_salary) {
	hours = new_hours;
}

/** Trainer class starts here **/

// Trainer derived class constructor
Trainer::Trainer(string new_firstName, string new_lastName, double new_salary, 
				 string new_subject) : Employee(new_firstName, new_lastName, new_salary) {
	subject = new_subject;
}