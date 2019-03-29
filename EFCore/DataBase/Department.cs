using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.DataBase
{
    public class Department
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
