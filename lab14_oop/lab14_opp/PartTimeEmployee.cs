using System;
using System.Collections.Generic;
using System.Text;

namespace lab14_opp
{
   
        class PartTimeEmployee : Employee // inherits from Employee class
        {
            //attributes
            private int _hoursWorked;  // this is the new attribute for part time employeess


            //properties
            public int HoursWorked
            {
                get
                {
                    return _hoursWorked;
                }
                set
                {
                    _hoursWorked = value;
                }
            }


            //constructors
            public PartTimeEmployee() : base()
            {

            }

            public PartTimeEmployee(string n, string gender, decimal hourlyRate, int hrs) : base(n, gender, hourlyRate)
            {
                _hoursWorked = hrs;
            }


            //methods
            public override decimal CalcPay()
            {
                return HoursWorked * HourlyRate;
            }

            public override string ToString() // note that this over rides(replaces) all super level toString methods
            {

                return base.ToString() + " HoursWorked : " + HoursWorked;
            }
        }



    
}
