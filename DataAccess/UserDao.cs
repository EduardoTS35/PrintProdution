using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Commun.Cache;
using System.Drawing;

namespace DataAccess
{
    public class UserDao : ConnectionToSql
    {
        public bool Login(string user, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select *from Usuarios where Usuario=@user and Contraseña=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserLoginCache.FirstName = reader.GetString(1);
                            UserLoginCache.LastName = reader.GetString(2);
                            UserLoginCache.Position = reader.GetString(5);
                            UserLoginCache.Area = reader.GetString(6);
                            UserLoginCache.Id = reader.GetInt32(0);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public void InsertarPrint(string Nombre, string IdProducto, string Producto, double PesoBruto, double PesoNeto, double Tara)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Insert into Entradas values (GETDATE(),'" + Nombre + "','" + IdProducto + "','" + Producto + "','" + PesoBruto + "','" + PesoNeto + "','" + Tara + "')";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void InsertarInventario(int ID, string Nombre, string IdProducto, string Producto, double PesoBruto, double PesoNeto)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Insert into Inventario values ('" + ID + "',GetDate(),'" + Nombre + "','" + IdProducto + "','" + Producto + "','" + PesoBruto + "','" + PesoNeto + "')";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void InsertarSalidas(int ID ,string Nombre, string IdProducto, string Producto, double PesoBruto, double PesoNeto,int IDOrden)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Insert into Salidas values ('"+ID+"',GETDATE(),'" + Nombre + "','" + IdProducto + "','" + Producto + "','" + PesoBruto + "','" + PesoNeto + "','"+IDOrden+"')";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void RestarInventario(int ID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Delete from Inventario where ID='" + ID + "'";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void RestarEntrada(int ID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Delete from Entradas where ID='" + ID + "'";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void RestarSalida(int ID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Delete from Salidas where ID='" + ID + "'";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void RestarSalidaOrden(int IDOrden)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Delete from Salidas where IDOrden='" + IDOrden + "'";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public DataTable MostrarDatosP()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select  TOP 50 ID,Fecha,Nombre,IDProducto,Producto,PesoBruto,PesoNeto,Tara from Entradas Order by id desc";
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        public DataTable MostrarDatosS()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select TOP 50 *from Salidas Order by Fecha desc";
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        public DataTable MostrarDatosI(int ID)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select *from Inventario where ID='" + ID + "'";
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        public DataTable MostrarDatosS(int ID)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select *from Salidas where ID='" + ID + "'";
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        public DataTable MostrarDatosSalidaO(int IdOrden)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select ID,Cast(Fecha as smalldatetime) as Fecha,Nombre,IDProducto,Producto,PesoBruto,PesoNeto from Salidas where IDOrden='" + IdOrden + "'";
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        public DataTable MostrarDatoscmbP()
        {
            try
            {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CargarProd";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
            }
            catch
            {
                return null;
            }

        }

        public DataTable MostrarDatoscmbClientes()
        {
            try
            {
                SqlDataReader leer;
                DataTable table = new DataTable();

                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "Select *from Clientes";
                        command.CommandType = CommandType.Text;
                        leer = command.ExecuteReader();
                        table.Load(leer);
                        connection.Close();
                        return table;
                    }
                }
            }
            catch
            {
                return null;
            }

        }
        public bool MostrarID(string producto)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select *from Productos where NombreP=@producto";
                    command.Parameters.AddWithValue("@producto", producto);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            AppCache.IdProducto = reader.GetString(0);
                        }
                        return true;
                    }
                    else
                        return false;
                }

            }
        }

        public bool MostrarActualID()
        {
            try
            {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CargarSigID";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            AppCache.ActualId = reader.GetInt32(0);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
            }
            catch
            {
                return false;
            }

        }

        public bool MostrarOrdenID()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT TOP 1 *FROM Salidas ORDER by IDOrden desc";
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            AppCache.OrdenIDI = reader.GetInt32(7);
                        }
                        return true;
                    }
                    else
                        return false;
                }

            }
        }

        public void InsertarUsuarios(string Nombre, string Apellido, string Usuario, string Contraseña, string Cargo, string Area)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Insert into Usuarios values ('" + Nombre + "','" + Apellido + "','" + Usuario + "','" + Contraseña + "','" + Cargo + "','" + Area + "')";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void InsertarProductos(string ID, string Nombre)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Insert into Productos values ('" + ID + "','" + Nombre + "')";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public DataTable InsertarMasivo(DataTable table)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction=connection.BeginTransaction())
                {
                    using (SqlBulkCopy bulkCopy= new SqlBulkCopy(connection,SqlBulkCopyOptions.Default,transaction))
                        try
                        {
                            bulkCopy.DestinationTableName = "Inventario";
                            bulkCopy.WriteToServer(table);
                            transaction.Commit();
                            
                        }
                        catch
                        {
                            transaction.Rollback();
                            connection.Close();
                        }
                }
                return table;
            }
        }
        public void CorregirErrorBulk()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Delete from Inventario where ID='0'";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        /*public bool MostrarProduccionDiaria()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select SUM(PesoNeto) as TotalProduccion from Produccion where cast(Fecha as date) = cast(getdate() as date);";
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            AppCache.ProduccionDiaria = reader.GetDouble(0);
                        }
                        return true;
                    }
                    else
                        return true;
                }

            }
        }*/
    }
}

