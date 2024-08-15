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
        public Vehiculo(string matricula, string modelo, string combustible, Cliente cliente)
        {
            Matricula = matricula;
            Modelo = modelo;
            Combustible = combustible;
            Cliente = cliente;
        }
        
        public string Matricula {  get; set; }
        public string Modelo { get; set; }
        public string Combustible { get; set; }
        public Cliente Cliente { get; set; }
        public virtual void MostrarInformacion()
        {
            Console.WriteLine("-------Vehiculo-------");
            Console.WriteLine("\nMatricula: " + Matricula);
            Console.WriteLine("\nCombustible: " + Combustible);
            Console.WriteLine("\nModelo: " + Modelo);
            Console.WriteLine("\nRegistrado a nombre de: " + Cliente.Nombre);
        }
    }
}
