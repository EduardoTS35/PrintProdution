using System;
using System.Collections.Generic;
using System.Text;

namespace Commun.Cache
{
    public class AppCache
    {
        public static string IdProducto { get; set; }
        public static int ActualId { get; set; }
        public static double ProduccionDiaria { get; set; }

        public static int ContadorClicks { get; set; }

        public static string IDI { get; set; }
        public static string IDProductoI { get; set; }
        public static string ProductoI { get; set; }
        public static string PesoBruto { get; set; }
        public static string PesoNeto { get; set; }
        public static int OrdenIDI { get; set; }
        public static int StatusPort { get; set; }
    }
}
