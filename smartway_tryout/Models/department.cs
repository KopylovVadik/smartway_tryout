using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApp.Models
{
    public class InsertDepartmentDataModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }

    }

    public class UpdateDepartmentDataModel
    {
        public string key { get; set; }
        public string value { get; set; }
        public int id { get; set; }

    }

    public class DeleteDepartmentDataModel
    {
        public int id { get; set; }

    }

}
