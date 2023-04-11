using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain
{
    public class SalidasLote
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public string IDProducto { get; set; }
        public string Producto { get; set; }
        public float PesoBruto { get; set; }
        public float PesoNeto { get; set; }

        public void InsertarDatosMasivo(IEnumerable<SalidasLote> salidasLotes)
        {
            var userDao = new UserDao();
            var table = new DataTable();


            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Fecha", typeof(DateTime));
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("IDProducto", typeof(string));
            table.Columns.Add("Producto", typeof(string));
            table.Columns.Add("PesoBruto", typeof(float));
            table.Columns.Add("PesoNeto", typeof(float));

            foreach(var itemDetail in salidasLotes)
            {
                table.Rows.Add(new object[]
                {
                    itemDetail.ID,
                    itemDetail.Fecha,
                    itemDetail.Nombre,
                    itemDetail.IDProducto,
                    itemDetail.Producto,
                    itemDetail.PesoBruto,
                    itemDetail.PesoNeto
                });
            }
            userDao.InsertarMasivo(table);
        }
    }
}
