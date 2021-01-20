using System;
using System.Collections.Generic;
using System.Text;

namespace Company
{
    class BoardMember : Employee
    {
        public BoardMember(int id, int vs, DateTime bd):base(id, vs, bd) { VacationStock = 0; }
        public override int VacationStock { get => base.VacationStock; }

        public override bool Resign()
        {
            OnLayOff(new EmployeeLayOffEventArgs() { Cause = EmployeeLayOff.Resign });
            Console.WriteLine("Thanks for you service");
            return true;
        }

        protected override void OnLayOff(EmployeeLayOffEventArgs e)
        {
            if (e.Cause == EmployeeLayOff.Resign)
                base.OnLayOff(e);
            else
                Console.WriteLine("Board Member");
        }
    }
}
