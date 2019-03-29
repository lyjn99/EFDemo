using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.DataBase
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
        public List<CompanyCity> CompanyCities=new List<CompanyCity>();

        public Owner Owner { get; set; }
    }
}
