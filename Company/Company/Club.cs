using System;
using System.Collections.Generic;
using System.Text;

namespace Company
{
    class Club
    {
        public int ClubId { get; set; }
        public String ClubName { get; set; }
        List<Employee> Members = new List<Employee>();
        public void AddAllMembers(Employee[] Emps)
        {
            foreach (Employee E in Emps)
                AddMember(E);
        }
        public void AddMember(Employee Emp)
        {
            Emp.LayOff += this.RemoveMember;
            Members.Add(Emp);
        }
        public void RemoveMember(object sender, EmployeeLayOffEventArgs e)
        {
            if((sender is Employee E) && (Members.Contains(E)) && (e.Cause == EmployeeLayOff.VacationLimit))
            {
                Members.Remove(E);
                Console.WriteLine($"Member {E} is removed because of {e.Cause}");
            }
        }

        public Employee this[int index]
        {
            get { return Members[index]; }
        }
        public override string ToString()
        {
            string result = $"{ClubName}\n";
            foreach (Employee E in Members)
                result += $"{E}\n";
            return result;
        }
    }
}
