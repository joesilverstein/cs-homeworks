/********************************************
** q407.cpp
** Organizes employee records and allows user to search them by various criteria.
** Joseph Silverstein, 3/30/11
*********************************************/

#include <iostream>
#include <string>
#include <fstream>
#include <list>
#include <map>
#include "employee.h"

using namespace std;

/* given an iterator pointing to an employee record in the master_list, 
** prints the record in an easy to read format */
void printRecord(list<Employee>::iterator iter) {
	cout << "Name: " << iter->get_name() << '\n'
	     << "ID: " << iter->get_ID() << '\n'
		 << "Age: " << iter->get_age() << '\n'
		 << "Weight: " << iter->get_weight() << '\n'
		 << "Salary: " << iter->get_salary();
	cout << "\n\n";
	return;
}

int main() {
	int choice = 0; // the user's choice from 1-7
	string filename; // name of the file
	string searchTermString; // term to search for when searching employee records (when a string is needed)
	double searchTermNumber; // term to search for when searching employee records (when a number is needed)
	Employee tempEmployee; // for reading in file
	ifstream fin; // for reading in file
	list<Employee> master_list; //master list of employee records
	list<Employee>::iterator masterIter; //iterator for master list
	map<string, list<Employee>::iterator> names; //maps names to employees
	map<string, list<Employee>::iterator> IDs; //maps ID's to employees
	map<int, list<Employee>::iterator> ages; //maps ages to employees
	map<int, list<Employee>::iterator> weights; //maps weights to employees
	map<int, list<Employee>::iterator> salaries; //maps salaries to employees

	cout << "Enter file name: ";
	cin >> filename;
	fin.open(filename.c_str());
	
	// reads in data and organizes it into a linked list of Employee objects
	while (fin >> tempEmployee) {
		master_list.push_back(tempEmployee);
	}
	fin.close();

	// construct hash tables
	masterIter = master_list.begin();
	while (masterIter != master_list.end()) {
		names[masterIter->get_name()] = masterIter;
		IDs[masterIter->get_ID()] = masterIter;
		ages[masterIter->get_age()] = masterIter;
		weights[masterIter->get_weight()] = masterIter;
		salaries[(int)((masterIter->get_salary())*100)] = masterIter; // multiply salaries by 100 to use integer keys
		masterIter++;
	}

	// user can repeat as many times as needed
	while (choice != 7) {
		cout << "1.) Look up employee by name.\n"
			 << "2.) Look up employee by ID number.\n"
			 << "3.) Look up employee by age.\n"
			 << "4.) Look up employee by weight.\n"
			 << "5.) Look up employee by salary.\n"
			 << "6.) Print all records.\n"
			 << "7.) Quit.\n"
			 << "   Enter your choice: ";
		cin >> choice; // user chooses how to search for a record

		if (choice==1 || choice==2) {
			cout << "Search for: ";
			cin >> searchTermString;
		}

		if (choice==3 || choice==4 || choice==5) {
			cout << "Search for: ";
			cin >> searchTermNumber;
		}

		//look up by name
		if (choice == 1) {
			masterIter = names[searchTermString];
			printRecord(masterIter);
		}

		//look up by ID
		if (choice == 2) {
			masterIter = IDs[searchTermString];
			printRecord(masterIter);
		}

		//look up by age
		if (choice == 3) {
			masterIter = ages[(int)searchTermNumber];
			printRecord(masterIter);
		}

		//look up by weight
		if (choice == 4) {
			masterIter = weights[(int)searchTermNumber];
			printRecord(masterIter);
		}

		//look up by salary
		if (choice == 5) {
			masterIter = salaries[searchTermNumber*100]; //multiply by 100 to access int data in hash table
			printRecord(masterIter);
		}

		// prints records
		if (choice == 6) {
			masterIter = master_list.begin();
			while (masterIter != master_list.end()) {
				printRecord(masterIter);
				masterIter++;
			}
		}
	}
	
	return 0;
}