using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace Domain
{
    public class Reporte
    {
        public DateTime reportDate { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<PruebasL> pruebasL { get; set; }

        public void GenerarOrdenReporte(DateTime fromDate, DateTime toDate)
        {
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrder(fromDate,toDate);

            pruebasL = new List<PruebasL>();

            foreach(System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    Producto = Convert.ToString(rows[0]),
                    TotalBolsasProd=Convert.ToInt16(rows[1]),
                    TotalProd = Convert.ToDouble(rows[2])
                };
                pruebasL.Add(pruebasModel);
            }
        }
        public void GenerarOrdenReporteI()
        {
            reportDate = DateTime.Now;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderInventario();

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    ProductoInventario = Convert.ToString(rows[0]),
                    TotalBolsasInv = Convert.ToInt16(rows[1]),
                    TotalProdInventario = Convert.ToDouble(rows[2])
                };
                pruebasL.Add(pruebasModel);
            }

        }
        

        public void GenerarOrdenReporteS2(DateTime fromDate, DateTime toDate)
        {
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenS(fromDate,toDate);

            pruebasL = new List<PruebasL>();

            foreach(System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    ProductoRS = Convert.ToString(rows[0]),
                    TotalBolsasProdRS=Convert.ToInt16(rows[1]),
                    TotalProdRS = Convert.ToDouble(rows[2])
                };
                pruebasL.Add(pruebasModel);
            }
        }

        public void GenerarOrdenReporteResumenSC(DateTime fromDate,DateTime toDate,int cliente)
        {
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenSalidaCliente(fromDate, toDate, cliente);

            pruebasL = new List<PruebasL>();

            foreach(System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    ProductoRSC = Convert.ToString(rows[0]),
                    TotalBolsasSC = Convert.ToInt16(rows[1]),
                    TotalProdSC = Convert.ToDouble(rows[2])
                };
                pruebasL.Add(pruebasModel);
            }
        }

    }
}
