using System;
using System.Collections.Generic;
using System.Text;

namespace Company
{
    class Employee
    {
        int vacationStock;
        public int EmployeeId { get; set; }
        public virtual int VacationStock
        {
            get { return vacationStock; }
            set
            {
                if (value < 0)
                    vacationStock = 50;
                else
                    vacationStock = value;       
            }
        }
        public DateTime BirthDate { get; set; }

        public Employee(int id, int vs, DateTime bd)
        {
            EmployeeId = id;
            VacationStock = vs;
            BirthDate = bd;
        }

        public event EventHandler<EmployeeLayOffEventArgs> LayOff;

        public bool RequestVacation(int noOfDays)
        {
            if (noOfDays > vacationStock)
            {
                OnLayOff(new EmployeeLayOffEventArgs() { Cause = EmployeeLayOff.VacationLimit });
                return false;
            }
            else
            {
                Console.WriteLine("Have a nice vacation");
                return true;
            }
        }

        public bool EndOfYearOperation()
        {
            int age = (DateTime.Now - BirthDate).Days / 365;
            if (age >= 60)
            { 
                OnLayOff(new EmployeeLayOffEventArgs() { Cause = EmployeeLayOff.Pension });
                return false;
            }
            else
            {
                Console.WriteLine("Another lovely year");
                return true;
            }
        }

        public virtual bool CheckTarget(int Quota) { return false; }

        public virtual bool Resign() { return false; }

        protected virtual void OnLayOff(EmployeeLayOffEventArgs e)
        {
               LayOff?.Invoke(this, e);
        }

        public override string ToString()
        {
            return $"Emp {EmployeeId} : {vacationStock} : {BirthDate.ToShortDateString()}";
        }
    }

}
