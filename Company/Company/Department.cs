using System;
using System.Collections.Generic;
using System.Text;

namespace Company
{
    class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }

        List<Employee> Staff = new List<Employee>();

        public void AddAllStaff(Employee[] Emps)
        {
            foreach (Employee E in Emps)
                AddStaff(E);
        }

        public void AddStaff(Employee Emp)
        {
            Emp.LayOff += this.RemoveStaff;
            Staff.Add(Emp);
        }

        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            if((sender is Employee E) && (Staff.Contains(E)))
            {
                Staff.Remove(E);
                Console.WriteLine($"Staff {E} is removed because of {e.Cause}");
            }
        }

        public Employee this[int index]
        {
            get { return Staff[index]; }
        }
        public override string ToString()
        {
            string result = $"{DeptName}\n";
            foreach (Employee E in Staff)
                result += $"{E}\n";
            return result;
        }
    }
}
