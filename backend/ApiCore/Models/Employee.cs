using System;
using System.Collections.Generic;

namespace ApiCore.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public string PhotoFileName { get; set; }
    }
}
