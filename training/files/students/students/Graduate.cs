using System;
using System.Collections.Generic;
using System.Text;

namespace students
{
    class Graduate
    {
        //attr
        private string _studentNo;
        private string _gender;
        private double _salary;


        //props
        public double Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string StudentNo
        {
            get { return _studentNo; }
            set { _studentNo = value; }
        }


        //ctors
        public Graduate()
        {

        }

        public Graduate(string number, string gender, double salary)
        {
            _studentNo = number;
            _gender = gender;
            _salary = salary;
        }


        //methods
        public override string ToString()
        {
            return $"{_studentNo,-12}{_gender,-10}{_salary,-10}";
        }





    }
}
