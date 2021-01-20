using System;
using System.Collections.Generic;
using System.Text;

namespace Company
{
    class SalesEmployee : Employee
    {
        public int AchievedTarget { get; set; }
        public SalesEmployee(int id, int vs, DateTime bd, int target):base(id, vs, bd) { VacationStock = 0; AchievedTarget = target; }

        public override int VacationStock { get => base.VacationStock; }

        
        protected override void OnLayOff(EmployeeLayOffEventArgs e)
        {
            if(e.Cause == EmployeeLayOff.Target || e.Cause == EmployeeLayOff.Pension)
                base.OnLayOff(e);
            else
                Console.WriteLine("Sales Emp");
        }

        public override bool CheckTarget(int Quota)
        {
            if(AchievedTarget < Quota)
            {
                OnLayOff(new EmployeeLayOffEventArgs() { Cause = EmployeeLayOff.Target, TargetDiff = Quota - AchievedTarget });
                return false;
            }
            else
            {
                Console.WriteLine("Nice Job!!");
                return true;
            }
        }

    }
}
