using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3
{
    public class VehiculoPersonal : Vehiculo
    {
        public VehiculoPersonal(string matricula, string modelo, string combustible) : base(matricula, modelo, combustible) { }
    }
}
