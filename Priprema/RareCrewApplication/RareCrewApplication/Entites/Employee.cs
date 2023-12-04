    using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RareCrewApplication.Entites
{
    public class Employee
    {
        public string Id { get; set; }
        public string EmployeeName { get; set; }
        public DateTime StarTimeUtc { get; set; }
        public DateTime  EndTimeUtc { get; set; }


       
    }
    public class TotalWorkTime
    {
        public string EmployeeName { get; set; }
        public double TotalWorkHours { get; set; }
    }

}
