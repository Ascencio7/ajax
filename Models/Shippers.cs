using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ajax.Models
{
    public class Shippers
    {
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string opcion { get; set; }

        public Shippers() { }

        public Shippers(int id, string com, string tel)
        {
            this.ShipperID = id;
            this.CompanyName = com;
            this.Phone = tel;
        }

    }
}