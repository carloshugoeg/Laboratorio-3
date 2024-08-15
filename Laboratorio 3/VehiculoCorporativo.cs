using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3
{
    internal class VehiculoCorporativo : Vehiculo
    {
       public VehiculoCorporativo(string matricula, string modelo, string combustible, Cliente cliente) : base(matricula, modelo, combustible, cliente) { }
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine("\nTipo Vehiculo: Corporativo");
        }
    }
}
