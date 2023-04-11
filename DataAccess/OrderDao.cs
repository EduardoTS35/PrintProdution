using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class OrderDao:ConnectionToSql
    {
        public DataTable GetOrder(DateTime fromDate, DateTime toDate)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"Select  Producto,count(*) as Bolsas,Sum(PesoNeto) as TotalProduccion from Entradas where Fecha between @fromdate and @todate group by Producto";
                    command.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                    command.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                    command.CommandType = CommandType.Text;

                    var reader = command.ExecuteReader();
                    var table = new DataTable();
                    table.Load(reader);
                    connection.Close();

                    return table;
                }
            }
        }

        public DataTable GetOrderDetail(DateTime fromDate, DateTime toDate)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"Select Id,Fecha,Nombre,Producto,Format(PesoBruto,'N2') as PesoBruto,Format(PesoNeto,'N2')as PesoNeto,Format(Tara,'N2')as Tara from Entradas where Fecha between @fromDate and @toDate";
                    command.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                    command.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                    command.CommandType = CommandType.Text;

                    var reader = command.ExecuteReader();
                    var table = new DataTable();
                    table.Load(reader);
                    connection.Close();

                    return table;
                }
            }
        }
        public DataTable GetOrderInventario()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"Select  Producto,count(*) as Bolsas,Sum(PesoNeto) as TotalInventario from Inventario group by Producto";
                    command.CommandType = CommandType.Text;

                    var reader = command.ExecuteReader();
                    var table = new DataTable();
                    table.Load(reader);
                    connection.Close();

                    return table;
                }
            }
        }
        public DataTable GetOrderInvD()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"Select *from Inventario order by ID";
                    command.CommandType = CommandType.Text;

                    var reader = command.ExecuteReader();
                    var table = new DataTable();
                    table.Load(reader);
                    connection.Close();

                    return table;
                }
            }
        }
        public DataTable GetOrderDetailS(DateTime fromDate, DateTime toDate)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @" Select *from Salidas  where Fecha between @fromDate and @toDate";
                    command.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                    command.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                    command.CommandType = CommandType.Text;

                    var reader = command.ExecuteReader();
                    var table = new DataTable();
                    table.Load(reader);
                    connection.Close();

                    return table;
                }
            }
        }

        public DataTable GetOrderResumenSalidaCliente(DateTime fromDate, DateTime toDate, int cliente)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @" Select  Producto,count(*) as Bolsas,Sum(PesoNeto) as TotalProduccion from Salidas where Clientes = @Cliente and Fecha between @fromdate and @todate group by Producto";
                    command.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                    command.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                    command.Parameters.Add("@Cliente", SqlDbType.Int).Value = cliente;
                    command.CommandType = CommandType.Text;

                    var reader = command.ExecuteReader();
                    var table = new DataTable();
                    table.Load(reader);
                    connection.Close();

                    return table;
                }
            }
        }

        public DataTable GetOrderDetallesSalidaCliente(DateTime fromDate, DateTime toDate, int cliente)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @" Select *from Salidas Inner Join Clientes on Clientes= Clientes.IDCliente where Clientes=@Cliente and Fecha between @fromDate and @toDate";
                    command.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                    command.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                    command.Parameters.Add("@Cliente", SqlDbType.Int).Value = cliente;
                    command.CommandType = CommandType.Text;

                    var reader = command.ExecuteReader();
                    var table = new DataTable();
                    table.Load(reader);
                    connection.Close();

                    return table;
                }
            }
        }

        public DataTable GetOrderResumenS(DateTime fromDate, DateTime toDate)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"Select  Producto,count(*) as Bolsas,Sum(PesoNeto) as TotalProduccion from Salidas where Fecha between @fromdate and @todate group by Producto";
                    command.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                    command.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                    command.CommandType = CommandType.Text;

                    var reader = command.ExecuteReader();
                    var table = new DataTable();
                    table.Load(reader);
                    connection.Close();

                    return table;
                }
            }
        }

        public DataTable GetOrderEtiqueta()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @" SELECT TOP 1 *FROM Entradas ORDER by ID desc";
                    command.CommandType = CommandType.Text;

                    var reader = command.ExecuteReader();
                    var table = new DataTable();
                    table.Load(reader);
                    connection.Close();

                    return table;
                }
            }
        }
    }

}
