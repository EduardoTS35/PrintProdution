using System;
namespace Domain
{
    public class PruebasLDe
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public string Producto { get; set; }
        public double PesoBruto { get; set; }
        public double PesoNeto { get; set; }
        public double Tara { get; set; }
        public int IdI { get; set; }
        public DateTime FechaI { get; set; }
        public string NombreI { get; set; }
        public string ProductoIDI { get; set; }
        public string ProductoI { get; set; }
        public double PesoBrutoI { get; set; }
        public double PesoNetoI { get; set; }
        public int IdS { get; set; }
        public DateTime FechaS { get; set; }
        public string NombreS { get; set; }
        public string ProductoS { get; set; }
        public double PesoBrutoS { get; set; }
        public double PesoNetoS { get; set; }
        public string ProductoIDS { get; set; }
        public int NumOrden { get; set; }
        public int IdSC { get; internal set; }
        public DateTime FechaSC { get; internal set; }
        public string NombreSC { get; internal set; }
        public string ProductoIDSC { get; internal set; }
        public string ProductoSC { get; internal set; }
        public double PesoBrutoSC { get; internal set; }
        public double PesoNetoSC { get; internal set; }
        public string ClienteSC { get; internal set; }
    }
}