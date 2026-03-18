using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ajax.Models
{
    public class Shippers
    {
        public int ShipperID { get; set; }
        public string ShipperName { get; set; }
        public string Phone { get; set; }
        public string opcion { get; set; }

        public Shippers() { }

        public Shippers(int id, string name, string tel)
        {
            this.ShipperID = id;
            this.ShipperName = name;
            this.Phone = tel;
        }

    }
}