using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApp.Models
{
    public class InsertPassportDataModel
    {
        public int id { get; set; }
        public string type { get; set; }
        public string number { get; set; }

    }

    public class UpdatePassportDataModel
    {
        public int id { get; set; }
        public string key { get; set; }
        public string value { get; set; }

    }

    public class DeletePassportDataModel
    {
        public int id { get; set; }
    }
}
