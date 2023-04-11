using System;

namespace Domain
{
    public class PruebasL
    {
        public string Producto { get; set; }
        public double TotalProd { get; set; }
        public string ProductoInventario { get; set; }
        public double TotalProdInventario { get; set; }

        public int IDs { get; set; }
        public DateTime Fechas { get; set; }
        public string Nombres { get; set; }
        public string IDProductos { get; set; }
        public string Productos { get; set; }
        public float PBrutos { get; set; }
        public float PNetos { get; set; }
        public int IDordens { get; set; }
        public int TotalBolsasProd { get; set; }
        public int TotalBolsasInv { get; set; }
        public string ProductoRS { get; set; }
        public short TotalBolsasProdRS { get; set; }
        public double TotalProdRS { get; set; } 


        public string ProductoRSC { get; internal set; }
        public short TotalBolsasSC { get; internal set; }
        public double TotalProdSC { get; internal set; }
    }
}