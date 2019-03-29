using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.DataBase
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CompanyCity> CompanyCities { get; set; }
    }
}
