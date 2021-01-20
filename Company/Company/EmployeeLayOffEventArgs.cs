using System;
using System.Collections.Generic;
using System.Text;

namespace Company
{
    class EmployeeLayOffEventArgs : EventArgs
    {
        public int TargetDiff;
        public EmployeeLayOff Cause;
    }
    enum EmployeeLayOff
    {
        VacationLimit,
        Pension,
        Target,
        Resign
    }
}
