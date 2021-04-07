using System;
using System.Collections.Generic;
using System.Text;

namespace lab14_opp
{
    class Employee
    {
        // attributes
        //convention: start with '_' if private
        private string _gender;
        private string _name;
        private int _employeeNumber;
        private string _nationality;
        private decimal _tax;
        private decimal _salary;
        private decimal _hourlyRate;
        private int _hours;

        // static variable belong to class, no individual object has this
        public static int lastEmployeeNumber;
        

        // Name property used to get and set the name attribute of an object

        public int Hours
        {
            get { return _hours; }
            set { _hours = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public string Nationality
        {
            get  {  return _nationality;  }
            set
            {
                if (value == "British")         //if the string "British" is passed as arg @ instantiation
                    _nationality = "Visa Required";
                else
                    _nationality = value;
            }
        }

        // Gender property used to get and set the gender attribute of an object
        public string Gender
        {
            get  {  return _gender; }
            set {  _gender = value; }
        }

        public decimal HourlyRate
        {
            get { return _hourlyRate; }
            set { _hourlyRate = value; }
        }

        //ctors
        /// <summary>
        /// Default Contructor
        /// </summary>
        public Employee()
        {
            _employeeNumber = lastEmployeeNumber + 1;
            lastEmployeeNumber++;
        }

        /// <summary>
        /// Create an instance object. Takes a string nationality as parameter
        /// </summary>
        /// <param name="nationality"></param>
        public Employee(string nationality)
        {
            _employeeNumber = lastEmployeeNumber + 1;
            lastEmployeeNumber++;
            _nationality = nationality;
        }

        public Employee(decimal salary)
        {
            _employeeNumber = lastEmployeeNumber + 1;
            lastEmployeeNumber++;
            _salary = salary;
        }

        public Employee(int number)
        {
            _employeeNumber = lastEmployeeNumber + 1;
            lastEmployeeNumber++;
            _employeeNumber = number;
        }

        public Employee(string name, string gender, decimal hourly)
        {
            _employeeNumber = lastEmployeeNumber + 1;
            lastEmployeeNumber++;
            _name = name;
            _gender = gender;
            _hourlyRate = hourly;
        }

        public Employee(string name, string gender, decimal hourly, int hours)
        {
            _employeeNumber = lastEmployeeNumber + 1;
            lastEmployeeNumber++;
            _name = name;
            _gender = gender;
            _hourlyRate = hourly;
            _hours = hours;
        }

        //class Methods

        /// <summary>
        /// Calulates the Tax due to paid by an Employee object
        /// </summary>
        /// <param name="salary"></param>
        /// <returns>The tax due, calculated at 40%</returns>
        public decimal CalcTax(decimal salary)
        {
            _tax = salary * 0.4m;
            return _tax; 
        }

        /// <summary>
        /// Method subtracts tax to basic salary
        /// </summary>
        /// <returns>Decimal of the Nett Pay</returns>
        public virtual decimal CalcPay()
        {
            return _salary - _tax;
        }

        /// <summary>
        /// Overridden ToString() method
        /// </summary>
        /// <returns>Returns all attributes of the object</returns>
        public override string ToString()
        {
            string details0 = $"Employee Number: {_employeeNumber}";
            string details1 = $"Employee Name: {Name}";
            string details2 = $"Employee Gender: {Gender}";
            string details3 = $"Employee Tax: {_tax}";

            return "\n" + details0 + "\n" + details1 + "\n" + details2 + "\n" + details3;
        }
    }
}
