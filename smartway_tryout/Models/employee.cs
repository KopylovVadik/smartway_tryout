using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApp.Models
{
    public class InsertEmployeesDataModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public int company_id { get; set; }
        public int passport_id { get; set; }

    }

    public class DeleteEmployeesDataModel
    {
        public int id { get; set; }
    }

    public class UpdateEmployeesDataModel
    {
        public int id { get; set; }
        public string key { get; set; }
        public string value { get; set; }
    }

    public class GetEmployeesCompanyDataModel
    {
        public int company_id { get; set; }
    }
}
