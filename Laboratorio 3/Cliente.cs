using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Laboratorio_3
{
    public class Cliente
    {
        public Cliente(string nombre, string correo, string direccion, double descuento)
        {
            Nombre = nombre;
            Correo = correo;
            Direccion = direccion;
            Descuento = descuento;
            Vehiculos = new List<Vehiculo>();
        }

        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public double Descuento {  get; set; }
        public List<Vehiculo> Vehiculos { get; set; }
        public virtual void MostrarInformacion()
        {
            Console.WriteLine("--------CLIENTE--------");
            Console.WriteLine("\nNombre: " + Nombre);
            Console.WriteLine("\nCorreo: " + Correo);
            Console.WriteLine("\nDireccion: " + Direccion);
            if (Descuento != -1) Console.WriteLine($"\nDescuento: {Descuento*100}%");
            if (Vehiculos.Count > 0)
            {
                foreach (var vehiculo in Vehiculos)
                {
                    vehiculo.MostrarInformacion();
                }
            }
        }
        public virtual double AplicarDescuento(double precio)
        {
            if (Descuento == 0)
            {
                return precio;
            }
            Console.WriteLine("Tu membresia tiene un descuento!!");
            Console.WriteLine("\nPrecio Anterior: Q." + precio);
            precio = (precio) - (precio * Descuento);
            Console.WriteLine("Nuevo Precio: Q." + precio);
            Console.ReadLine();
            return precio;
        }
        public virtual void AsignarVehiculo(Vehiculo vehiculo) => Vehiculos.Add(vehiculo);
    }
}
