using System;
using System.Collections.Generic;
using System.Text;

namespace ManyToMany.Database
{
    public class Company
    {
        public Company()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public List<Department> Departments { get; set; }=new List<Department>();
    }
}
