using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.DataBase
{
    public class CompanyCity
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }
}
