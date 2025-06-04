using BenchmarkDotNet.Toolchains.InProcess.NoEmit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharp
{
    internal class WorkingHours
    {
        public int RegularHours { get; set; }

        public int OvertimeHours { get; set; }

        public static WorkingHours operator +(WorkingHours workHours, WorkingHours newValue)
        {
            return new WorkingHours
            {
                RegularHours = workHours.RegularHours + newValue.RegularHours,
                OvertimeHours = workHours.OvertimeHours + newValue.OvertimeHours
            };
        }
    }
}
