using System;
using System.Collections.Generic;
using System.Text;

namespace q428
{
    class Employee
    {
        protected string firstName, lastName;
        protected double salary;
        public Employee()
        {
            firstName = lastName = "";
            salary = 0;
        }
        // create new employee
        public Employee(string new_firstName, string new_lastName, double new_salary)
        {
            firstName = new_firstName;
            lastName = new_lastName;
            salary = new_salary;
        }
        public string get_firstName()
        {
            return firstName;
        }
        public string get_lastName()
        {
            return lastName;
        }
        public double get_salary()
        {
            return salary;
        }
        // how object will be displayed in ListBox
        public override string ToString()
        {
            return "Employee " + firstName + " " + lastName;
        }
    }

    class Manager : Employee
    {
        private string store;
        public Manager(string new_firstName, string new_lastName, double new_salary, string new_store)
            : base(new_firstName, new_lastName, new_salary)
        {
            store = new_store;
        }
        public string get_store()
        {
            return store;
        }
        public override string ToString()
        {
            return "Manager " + firstName + " " + lastName;
        }
    }

    class Peon : Employee
    {
        private double hours;
        public Peon(string new_firstName, string new_lastName, double new_salary, double new_hours)
            : base(new_firstName, new_lastName, new_salary)
        {
            hours = new_hours;
        }
        public double get_hours()
        {
            return hours;
        }
        public override string ToString()
        {
            return "Peon " + firstName + " " + lastName;
        }
    }

    class Trainer : Employee
    {
        private string subject;
        public Trainer(string new_firstName, string new_lastName, double new_salary, string new_subject)
            : base(new_firstName, new_lastName, new_salary)
        {
            subject = new_subject;
        }
        public string get_subject()
        {
            return subject;
        }
        public override string ToString()
        {
            return "Trainer " + firstName + " " + lastName;
        }
    }
}
