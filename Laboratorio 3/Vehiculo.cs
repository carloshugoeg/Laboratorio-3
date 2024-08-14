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
        public Vehiculo(string matricula, string modelo, string combustible)
        {
            Matricula = matricula;
            Modelo = modelo;
            Combustible = combustible;
        }
        
        public string Matricula {  get; set; }
        public string Modelo { get; set; }
        public string Combustible { get; set; }
        public virtual void MostrarInformacion()
        {
            Console.WriteLine("-------Vehiculo-------");
            Console.WriteLine("Matricula: " + Matricula);
            Console.WriteLine("Combustible" + Combustible);
            Console.WriteLine("Modelo: " + Modelo);
        }
    }
}
