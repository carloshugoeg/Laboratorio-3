using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3
{
    internal class ClienteCorporativo : Cliente
    {
        public ClienteCorporativo(string nombre, string correo, string direccion, double descuento) : base(nombre, correo, direccion, descuento) { Vehiculos = new List<Vehiculo>(); }
    }
}
