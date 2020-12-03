using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Datos
{
    public class DUsuario
    {
        public DataTable Listar()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("usuario_listar", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                Resultado = comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
        }


        public DataTable Buscar(string Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("usuario_buscar", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = Valor;
                sqlCon.Open();
                Resultado = comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
        }
        

        public string Existe(string Valor)
        {
            string Respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("usuario_existe", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = Valor;
                SqlParameter ParExiste = new SqlParameter();
                ParExiste.ParameterName = "@existe";
                ParExiste.SqlDbType = SqlDbType.Int;
                ParExiste.Direction = ParameterDirection.Output;
                comando.Parameters.Add(ParExiste);
                sqlCon.Open();
                comando.ExecuteNonQuery();
                Respuesta = Convert.ToString(ParExiste.Value);
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return Respuesta;
        }


        public string Insertar(Usuario Obj)
        {
            string Respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("usuario_insertar", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idrol", SqlDbType.Int).Value = Obj.IdRol;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                comando.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = Obj.TipoDocumento;
                comando.Parameters.Add("@num_documento", SqlDbType.VarChar).Value = Obj.NumDocumento;
                comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = Obj.Direccion;
                comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = Obj.Telefono;
                comando.Parameters.Add("@email", SqlDbType.VarChar).Value = Obj.Email;
                comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = Obj.Clave;
                sqlCon.Open();
                Respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar el registro";
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return Respuesta;
        }

        public string Actualizar(Usuario Obj)
        {
            string Respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("usuario_actualizar", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = Obj.IdUsuario;
                comando.Parameters.Add("@idrol", SqlDbType.Int).Value = Obj.IdRol;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                comando.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = Obj.TipoDocumento;
                comando.Parameters.Add("@num_documento", SqlDbType.VarChar).Value = Obj.NumDocumento;
                comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = Obj.Direccion;
                comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = Obj.Telefono;
                comando.Parameters.Add("@email", SqlDbType.VarChar).Value = Obj.Email;
                comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = Obj.Clave;
                sqlCon.Open();
                Respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el registro";
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return Respuesta;
        }

        public string Eliminar(int Id)
        {
            string Respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("usuario_eliminar", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = Id;
                sqlCon.Open();
                Respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro";
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return Respuesta;
        }

        public string Activar(int Id)
        {
            string Respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("usuario_activar", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = Id;
                sqlCon.Open();
                Respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo activar el registro";
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return Respuesta;
        }

        public string Desactivar(int Id)
        {
            string Respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("usuario_desactivar", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = Id;
                sqlCon.Open();
                Respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar el registro";
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return Respuesta;
        }

        public DataTable Login(string Email, string Clave)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("usuario_login", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;
                comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = Clave;
                sqlCon.Open();
                Resultado = comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
        }
    }
}
