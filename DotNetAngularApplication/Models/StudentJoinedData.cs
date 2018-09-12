using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAngularApplication.Models
{
    public class StudentJoinedData
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentClass { get; set; }
        public int StudentAge { get; set; }

        public double StudentFees { get; set; }
        public DateTime Date { get; set; }
    }
}
