using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgresqlCoreDemo.Entity.Entities
{
    public class Supplier
    {
        //Pasted json as Classes
        public int id { get; set; }
        public string companyName { get; set; }
        public string contactName { get; set; }
        public string contactTitle { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public int postalCode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
    }

}
