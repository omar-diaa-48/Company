using System;

namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] EmpsList = new Employee[] {
                new Employee(0,20,new DateTime(1950,11,25)),
                new SalesEmployee(1,10,new DateTime(1940,07,18),10),
                new Employee(2,30,new DateTime(1980,10,05)),
                new Employee(3,15,new DateTime(1960,03,08)),
                new Employee(4,10,new DateTime(1950,07,14)),
                new BoardMember(5,10,new DateTime(1940,09,09))
            };

            Department D = new Department() { DeptId = 1, DeptName = "EWD" };
            Club C = new Club() { ClubId = 1, ClubName = "Degla" };

            D.AddAllStaff(EmpsList);
            C.AddAllMembers(EmpsList);

            Console.WriteLine($"{D}{C}");

            D[3].Resign();

            Console.WriteLine($"{D}{C}");
        }
    }
}
