using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3
{
    internal class ClienteVIP : Cliente
    {
        public ClienteVIP(string nombre, string correo, string direccion, double descuento) : base(nombre, correo, direccion, descuento) { }
    }
}
