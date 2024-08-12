using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3
{
    public class ClienteRegular:Cliente
    {
        public ClienteRegular(string nombre, string correo, string direccion, double descuento) : base(nombre, correo, direccion, descuento) { }

    }
}
