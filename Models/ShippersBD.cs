using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ajax.Models
{
    public class ShippersBD
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        #region Conexion BD
        public ShippersBD()
        {
            this.con.ConnectionString =
                @"Data Source=VLADIMIR\ASCENCIO;Initial Catalog=Northwind; Integrated Security=true";
        }
        #endregion

        #region Obtener tabla
        public List<Shippers> getTabla()
        {
            List<Shippers> data = new List<Shippers>();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Shippers";
            cmd.Connection.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                data.Add(new Shippers(int.Parse(lector[0].ToString()),
                lector[1].ToString(), lector[2].ToString()));
            }
            cmd.Connection.Close();
            lector.Close();
            return data;
        }
        #endregion

        #region Insertar
        public bool insertar(Shippers obj)
        {
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Shippers(CompanyName, Phone) values('" + obj.CompanyName + "','" + obj.Phone + "')"; cmd.Connection.Open();
            int r = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            if (r == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Eliminar
        public bool eliminar(Shippers obj)
        {
            cmd.Connection = con;
            cmd.CommandText = "delete from Shippers where ShipperId =" + obj.ShipperID;
            cmd.Connection.Open();
            int r = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            if (r == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}