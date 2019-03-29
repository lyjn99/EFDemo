using System;
using System.Collections.Generic;
using System.Text;

namespace ManyToMany.Database
{
    public class Department
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
