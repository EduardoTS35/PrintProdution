    using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ReporteDetails
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<PruebasLDe> pruebasLDe { get; set; }

        public void GenerarOrdenReporteD(DateTime fromDate, DateTime toDate)
        {
            startDate = fromDate;
            endDate = toDate;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetail(fromDate, toDate);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    Id = Convert.ToInt32(rows[0]),
                    Fecha = Convert.ToDateTime(rows[1]),
                    Nombre = Convert.ToString(rows[2]),
                    Producto = Convert.ToString(rows[3]),
                    PesoBruto = Convert.ToDouble(rows[4]),
                    PesoNeto = Convert.ToDouble(rows[5]),
                    Tara = Convert.ToDouble(rows[6])

                };
                pruebasLDe.Add(pruebasModelDe);
            }

        }
        public void GenerarOrdenReporteDI()
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderInvD();

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdI = Convert.ToInt32(rows[0]),
                    FechaI = Convert.ToDateTime(rows[1]),
                    NombreI = Convert.ToString(rows[2]),
                    ProductoIDI = Convert.ToString(rows[3]),
                    ProductoI = Convert.ToString(rows[4]),
                    PesoBrutoI = Convert.ToDouble(rows[5]),
                    PesoNetoI = Convert.ToDouble(rows[6])

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }
        public void GenerarOrdenReporteDS(DateTime fromDate, DateTime toDate)
        {
            startDate = fromDate;
            endDate = toDate;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetailS(fromDate, toDate);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdS = Convert.ToInt32(rows[0]),
                    FechaS = Convert.ToDateTime(rows[1]),
                    NombreS = Convert.ToString(rows[2]),
                    ProductoIDS = Convert.ToString(rows[3]),
                    ProductoS = Convert.ToString(rows[4]),
                    PesoBrutoS = Convert.ToDouble(rows[5]),
                    PesoNetoS = Convert.ToDouble(rows[6]),
                    NumOrden=Convert.ToInt32(rows[7])
                };
                pruebasLDe.Add(pruebasModelDe);
            }

        }

        public void GenerarOrdenReporteDSC(DateTime fromDate, DateTime toDate,int cliente)
        {
            startDate = fromDate;
            endDate = toDate;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesSalidaCliente(fromDate, toDate,cliente);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdSC = Convert.ToInt32(rows[0]),
                    FechaSC = Convert.ToDateTime(rows[1]),
                    NombreSC = Convert.ToString(rows[2]),
                    ProductoIDSC = Convert.ToString(rows[3]),
                    ProductoSC = Convert.ToString(rows[4]),
                    PesoBrutoSC = Convert.ToDouble(rows[5]),
                    PesoNetoSC = Convert.ToDouble(rows[6]),
                    ClienteSC = Convert.ToString(rows[9])
                };
                pruebasLDe.Add(pruebasModelDe);
            }

        }
    }
}
