using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laboratorio_3
{
    internal class Pedido
    {
        public Pedido(int id, DateTime fecha, List<Producto> productos, Cliente cliente)
        {
            Id = id;
            Fecha = fecha;
            Productos = productos;
            Cliente = cliente;
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public List<Producto> Productos { get; set; }
        public double Total { get; set; }


        public double CalcularTotal(List<Producto> productos)
        {
            double total = 0;
            foreach (Producto producto in productos)
            {
                total += producto.Precio;
            }
            return total;
        }
        public void MostrarInformacion()
        {
            Console.WriteLine("-------PEDIDO-------");
            Console.WriteLine("\nNumero pedido: " + Id.ToString());
            Console.WriteLine("\nFecha" + Fecha.ToString());
            Console.WriteLine("\nCliente: " + Cliente.Nombre);
            Console.WriteLine("\nCorreo Cliente: " + Cliente.Correo);
            foreach (Producto producto in Productos) Console.WriteLine("\nProducto: " + producto.Nombre);
            Console.WriteLine("\nTotal: Q."+Total);
        }
    }
}
