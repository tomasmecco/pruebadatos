using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Datos
{
    public class Conexion
    {
        
        private static Conexion Con = null;

        private Conexion()
        {
            
        }
        public SqlConnection CrearConexion()
        {
            SqlConnection cadena = new SqlConnection();
            try
            {
                cadena.ConnectionString = "Data Source=DESKTOP-G71MUBC\\CHORI;Initial Catalog=dbsistema;User ID=sa;Password=tobita1996";
            }
            catch (Exception ex)
            {
                cadena = null;
                throw ex;
                
            }
            return cadena;

        }
        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
