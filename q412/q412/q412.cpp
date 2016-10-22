/********************************************
** q412.cpp
** Looks up employee records in a class hierarchy.
** Joseph Silverstein, 4/4/11
*********************************************/

#include <iostream>
#include <string>
#include <fstream>
#include <map>
#include "employee_classes.h"

using namespace std;

/* given an iterator pointing to an employee record in the master_list, 
** prints the record in an easy to read format 
void printRecord(list<Employee>::iterator iter) {
	cout << "Name: " << iter->get_name() << '\n'
	     << "ID: " << iter->get_ID() << '\n'
		 << "Age: " << iter->get_age() << '\n'
		 << "Weight: " << iter->get_weight() << '\n'
		 << "Salary: " << iter->get_salary();
	cout << "\n\n";
	return;
}*/

int main() {
	char choice = 'y'; // either 'y' or 'n'
	string filename; // name of the file
	string employeeName; // format: "firstName lastName"
	Employee tempEmployee; // for reading in file
	ifstream fin; // for reading in file
	//istream in; // for reading in types of employees
	char type; // the type of employee
	map<string, Employee*> names; //maps names to employees

	cout << "Enter file name: ";
	cin >> filename;
	fin.open(filename.c_str());
	
	// reads in data and organizes it into a linked list of Employee objects
	while (fin >> tempEmployee) {
		//in >> type;

		// constructs hash table to map employee full names to newly-allocated employee objects
		names[tempEmployee.get_firstName() + " " + tempEmployee.get_lastName()] = new Employee(tempEmployee);
	}
	fin.close();

	// user can repeat as many times as needed
	while (choice == 'y') {
		cout << "Enter employee name: ";
		cin >> employeeName;
		//names[employeeName]->print(); //print record (calls different fxn for each type)
	}
	
	return 0;
}