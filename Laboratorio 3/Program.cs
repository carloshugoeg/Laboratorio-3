using Laboratorio_3;
using System;
using System.Net.Mail;

List<Vehiculo> vehiculos = new List<Vehiculo>();
List<Cliente> clientes = new List<Cliente>();

do
{
    Console.Clear();
    Console.WriteLine("------Empresa Curiosa------");
    Console.WriteLine("\n     1. Registrar Cliente");
    Console.WriteLine("\n     2. Registrar Carro");
    Console.WriteLine("\n     3. Mostrar Habitaciones");
    Console.WriteLine("\n     4. Asignar Cliente");
    Console.WriteLine("\n     5. Liberar Habitacion");


    string opcion = Console.ReadLine();
    switch (opcion)
    {
        case "1":
            Console.Clear();
            RegistrarCliente(clientes);
            break;
        case "2":
            Console.Clear();
            RegistrarVehiculo(vehiculos);
            break;
        case "3":
            
            break;
        case "4":
            
            break;

        case "5":

           
            break;

    }
} while (true);

void RegistrarCliente(List<Cliente> clientes)
{
    Console.WriteLine("-----AGREGAR CLIENTE------");
    Console.WriteLine("\n     1. Cliente Regular");
    Console.WriteLine("\n     2. Cliente VIP");
    Console.WriteLine("\n     3. Cliente Corporativo");
    Console.Write("Ingrese nombre completo: ");
    string opcion = Console.ReadLine();
    string nombre = Console.ReadLine();
    string correo;
    bool correoValido = false;
    do
    {
        do
        {
            Console.Write("Ingrese su correo electronico: ");
            correo = Console.ReadLine();
            if (correo.Contains("@"))
            {
                break;
            }
            else Console.WriteLine("\nDireccion de correo no es valida");
        } while (true);

        foreach (Cliente cliente in clientes)
        {
            if (cliente.Correo.ToLower().Trim().Equals(correo.ToLower().Trim()))
            {
                Console.WriteLine("Este correo ya existe");
                correoValido = false;
            }
        } 
    } while (!correoValido);
    Console.Write("Direccion: ");
    string direccion = Console.ReadLine();
    switch (opcion)
    {
        case "1":
            clientes.Add(new ClienteRegular(nombre, correo, direccion, 0.0));
            Console.WriteLine("Cliente Regular agregado correctamente");
            break;
        case "2":
            clientes.Add(new ClienteVIP(nombre, correo, direccion, 0.25));
            Console.WriteLine("CLiente VIP agregado correctamente");
            break;
        case "3":
            clientes.Add(new ClienteCorporativo(nombre, correo, direccion, 0.50));
            Console.WriteLine("CLiente Corporativo agregado correctamente");
            break;
    }
    Console.WriteLine("Presione ENTER para continuar");
    Console.ReadLine();
}
void RegistrarVehiculo(List<Vehiculo> vehiculos)
{
    Console.WriteLine("-----AGREGAR Vehiculo------");
    Console.WriteLine("\n     1. Vehiculo Regular");
    Console.WriteLine("\n     2. Vehiculo Corporativo");
    Console.Write("Agregue un numero de placas");
    string opcion = Console.ReadLine();
    string numeroMatricula;
    bool placaValida = false;
    do
    {
        Console.Write("Agregue un numero de placas");
        numeroMatricula = Console.ReadLine();
        foreach (Vehiculo vehiculo in vehiculos)
        {
            if (vehiculo.Matricula.ToLower().Trim().Equals(numeroMatricula.ToLower().Trim()))
            {
                Console.WriteLine("Este numero de matricula ya existe");
                placaValida = false;
            }
        }
    } while (!placaValida);
    Console.Write("Modelo: ");
    string modelo = Console.ReadLine();
    Console.WriteLine("Tipo de combustible: 1. Diesel / 2. Regular / 3. Electrico / 4. Hibrido ");
    string combustible = Console.ReadLine();
    switch (combustible)
    {
        case "1":
            combustible = "Diesel";
            break; 
        case "2":
            combustible = "Regular";
            break;
        case "3":
            combustible = "Electrico";
            break;
        case "4":
            combustible = "Hibrido";
            break;
    }
    switch (opcion)
    {
        case "1":
            vehiculos.Add(new VehiculoPersonal(numeroMatricula, modelo, combustible));
            Console.WriteLine("Cliente Regular agregado correctamente");
            break;
        case "2":
            vehiculos.Add(new VehiculoCorporativo(numeroMatricula, modelo, combustible));
            Console.WriteLine("CLiente VIP agregado correctamente");
            break;
    }
    Console.WriteLine("Presione ENTER para continuar");
    Console.ReadLine();
}
