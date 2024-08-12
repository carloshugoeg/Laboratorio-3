using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Laboratorio_3
{
    public class Vehiculo
    {
        public Vehiculo(string matricula, string modelo, string computible)
        {
            Matricula = matricula;
            Modelo = modelo;
            Computible = computible;
        }

        public string Matricula {  get; set; }
        public string Modelo { get; set; }
        public string Computible { get; set; }


    }
}
