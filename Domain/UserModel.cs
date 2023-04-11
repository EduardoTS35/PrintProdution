using System;
using System.Data;
using System.Drawing;
using DataAccess;

namespace Domain
{
    public class UserModel
    {
        UserDao userDao = new UserDao();

        public bool LoginUser(string user, string pass)
        {
            return userDao.Login(user, pass);
        }

        public void InsertarPrint(string Nombre, string IdProducto, string Producto, string PesoBruto, string PesoNeto, string Tara)
        {
            userDao.InsertarPrint(Nombre, IdProducto, Producto, Convert.ToDouble(PesoBruto), Convert.ToDouble(PesoNeto), Convert.ToDouble(Tara));
        }

        public void InsertarInventario(string ID, string Nombre, string IdProducto, string Producto, string PesoBruto, string PesoNeto)
        {
            userDao.InsertarInventario(Convert.ToInt32(ID), Nombre, IdProducto, Producto, Convert.ToDouble(PesoBruto), Convert.ToDouble(PesoNeto));
        }

        public void InsertarSalidas(string ID,string Nombre, string IdProducto, string Producto, string PesoBruto, string PesoNeto,string IDOrden)
        {
            userDao.InsertarSalidas(Convert.ToInt32(ID),Nombre, IdProducto, Producto, Convert.ToDouble(PesoBruto), Convert.ToDouble(PesoNeto),Convert.ToInt32(IDOrden));
        }

        public void RestarInventario(string ID)
        {
            userDao.RestarInventario(Convert.ToInt32(ID)-1);
        }

        public void RestarEntrada(string ID)
        {
            userDao.RestarEntrada(Convert.ToInt32(ID));
        }

        public void RestarSalida(string ID)
        {
            userDao.RestarSalida(Convert.ToInt32(ID)-1);
        }

        public void RestarSalidaOrden(string IdOrden)
        {
            userDao.RestarSalidaOrden(Convert.ToInt32(IdOrden));
        }

        public void CorregirBulk()
        {
            userDao.CorregirErrorBulk();
        }

        public DataTable MostrarDatosPrint()
        {
            DataTable table = new DataTable();
            table = userDao.MostrarDatosP();
            return table;
        }

        public DataTable MostrarDatosS()
        {
            DataTable table = new DataTable();
            table = userDao.MostrarDatosS();
            return table;
        }
        public DataTable MostrarDatosI(string ID)
        {
            DataTable table = new DataTable();
            table = userDao.MostrarDatosI(Convert.ToInt32(ID)-1);
            return table;
        }

        public DataTable MostrarDatosS(string ID)
        {
            DataTable table = new DataTable();
            table = userDao.MostrarDatosS(Convert.ToInt32(ID)-1);
            return table;
        }

        public DataTable MostrarDatosSalidaO(int IdOrden)
        {
            DataTable table = new DataTable();
            table = userDao.MostrarDatosSalidaO(Convert.ToInt32(IdOrden));
            return table;
        }

        public DataTable MostrarDatoscmbClientes()
        {
            DataTable table = new DataTable();
            table = userDao.MostrarDatoscmbClientes();
            return table;
        }
        public DataTable MostrarDatoscmbP()
        {
            DataTable table = new DataTable();
            table = userDao.MostrarDatoscmbP();
            return table;
        }


        public bool MostrarID(string producto)
        {
            return userDao.MostrarID(producto);
        }

        public bool MostrarActualId()
        {
            return userDao.MostrarActualID();
        }

        public bool MostrarOrdenId()
        {
            return userDao.MostrarOrdenID();
        }

        public void InsertarUSuarios(string Nombre, string Apellido, string Usuario, string Contraseña, string Cargo, string Area)
        {
            userDao.InsertarUsuarios(Nombre, Apellido, Usuario, Contraseña, Cargo, Area);
        }

        public void InsertarPRoductos(string ID, string Nombre)
        {
            userDao.InsertarProductos(ID, Nombre);
        }

        /*public void MostrarProduccion()
        {
             userDao.MostrarProduccionDiaria();
        }*/

    }
}
