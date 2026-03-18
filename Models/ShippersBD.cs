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
        // Una variable que guarde la cadena de conexion a SQL Server
        string cadena = "Data Source=VLADIMIR\\ASCENCIO;Initial Catalog=Northwind; Integrated Security=true";


        #region Conexion BD
        public ShippersBD()
        {
            this.con.ConnectionString =
                @cadena;
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
                data.Add(new Shippers(
                    int.Parse(lector[0].ToString()),
                lector[1].ToString(), 
                lector[2].ToString()));
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
            cmd.CommandText = "INSERT INTO Shippers(ShipperName, Phone) VALUES('"
                                + obj.ShipperName + "','" + obj.Phone + "')";
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


        #region Editar
        public bool editar(Shippers obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    string query = "UPDATE Shippers SET ShipperName = @name, Phone = @phone WHERE ShipperID = @id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", obj.ShipperName);
                    cmd.Parameters.AddWithValue("@phone", obj.Phone);
                    cmd.Parameters.AddWithValue("@id", obj.ShipperID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion


    }
}