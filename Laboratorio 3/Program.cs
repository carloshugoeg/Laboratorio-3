using Laboratorio_3;
using System;
using System.Net.Mail;

List<Vehiculo> vehiculos = new List<Vehiculo>();
List<Cliente> clientes = new List<Cliente>();
List<Pedido> pedidos = new List<Pedido>();
int numeroPedido = 001;
do
{
    Console.Clear();
    Console.WriteLine("------Empresa Curiosa------");
    Console.WriteLine("\n     1. Registrar Cliente");
    Console.WriteLine("\n     2. Registrar Carro");
    Console.WriteLine("\n     3. Registrar Pedido");
    Console.WriteLine("\n     4. Mostrar Detalles de Clientes");
    Console.WriteLine("\n     5. Mostrar Detalles de Vehiculos");
    Console.WriteLine("\n     6. Mostrar Detalles de Pedidos");
    Console.WriteLine("\n     7. Buscar Cliente por Nombre");
    Console.WriteLine("\n     8. Buscar Vehiculo por Matricula");
    Console.WriteLine("\n     9. Buscar Pedido por Numero de Pedido");

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
            Console.Clear();
            RegistrarPedido(pedidos, numeroPedido, clientes);
            break;
        case "4":
            Console.Clear();
            DetallesClientes(clientes);
            break;
        case "5":
            Console.Clear();
            DetallesVehiculos(vehiculos);
            break;
        case "6":
            Console.Clear();
            DetallesPedidos(pedidos);
            break;
        case "7":
            Console.Clear();
            Console.WriteLine("-----BUSCAR CLIENTE-----");
            BuscarCliente(clientes);
            break;
        case "8":
            Console.Clear();
            BuscarVehiculo(vehiculos);
            break;

    }
} while (true);

void RegistrarCliente(List<Cliente> clientes)
{
    Console.WriteLine("-----AGREGAR CLIENTE------");
    Console.WriteLine("\n     1. Cliente Regular");
    Console.WriteLine("\n     2. Cliente VIP");
    Console.WriteLine("\n     3. Cliente Corporativo");
    Console.Write("\nEscoja una opcion: ");
    string opcion = Console.ReadLine();
    Console.Write("\nIngrese nombre completo: ");
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
                correoValido = true;
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
            clientes.Add(new ClienteRegular(nombre, correo, direccion, -1));
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
    bool encontrado = false;
    Cliente comprador = null;
    do
    {
        Console.Write("\nIngrese correo del Cliente: ");
        string correobuscado = Console.ReadLine();

        foreach (Cliente cliente in clientes)
        {
            if (cliente.Correo.ToLower().Trim().Equals(correobuscado.ToLower().Trim()))
            {
                encontrado = true;
                comprador = cliente;
            }
        }
        if (!encontrado) Console.WriteLine("\nCliente no fue encontrado");
    } while (!encontrado);
    Console.WriteLine("\n     1. Vehiculo Regular");
    if(comprador is ClienteCorporativo)
    {
        Console.WriteLine("\n     2. Vehiculo Corporativo");
    }
    Console.Write("\nEscoja una opcion: ");
    string opcion = Console.ReadLine();
    string numeroMatricula;
    bool placaValida = false;
    do
    {
        Console.Write("Agregue un numero de matricula: ");
        numeroMatricula = Console.ReadLine();
        placaValida = true;
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
            VehiculoPersonal NuevoPersonal = new VehiculoPersonal(numeroMatricula, modelo, combustible, comprador);
            vehiculos.Add(NuevoPersonal);
            Console.WriteLine("\nVehiculo personal agregado correctamente");
            comprador.Vehiculos.Add(NuevoPersonal);
            break;
        case "2":
            VehiculoCorporativo vehiculoCorporativo = new VehiculoCorporativo(numeroMatricula, modelo, combustible, comprador);
            vehiculos.Add(vehiculoCorporativo);
            Console.WriteLine("Vehiculo Corporativo agregado correctamente");
            comprador.Vehiculos.Add(vehiculoCorporativo);
            break;
    }
    Console.WriteLine("Presione ENTER para continuar");
    Console.ReadLine();
}
void RegistrarPedido(List<Pedido> pedidos, int noPedido, List<Cliente> clientes)
{
    Console.WriteLine("------CREAR PEDIDO------");
    Console.WriteLine("Pedido #"+numeroPedido);
    bool encontrado = false;
    Cliente comprador = null;
    do
    {
        Console.Write("\nIngrese correo del Cliente: ");
        string correobuscado = Console.ReadLine();
   
        foreach (Cliente cliente in clientes)
        {
            if (cliente.Correo.ToLower().Trim().Equals(correobuscado.ToLower().Trim()))
            {
                encontrado = true;
                comprador = cliente;
            }
        }
        if (!encontrado) Console.WriteLine("\nCliente no fue encontrado");
    } while (!encontrado);
    Console.WriteLine("\n------------Registrar Productos---------------");
    Producto producto = new Producto("",0);
    Console.WriteLine("\n----------------------------------------------");
    List<Producto> listaProductos = producto.AgregarProductos();
    Pedido nuevoPedido = new Pedido(noPedido, DateTime.Now, listaProductos, comprador);
    nuevoPedido.Total = nuevoPedido.CalcularTotal(listaProductos);
    if(comprador is ClienteCorporativo || comprador is ClienteVIP)
    {
        Console.WriteLine($"\nUsted tiene un descuento del {comprador.Descuento * 100}%!!");
        nuevoPedido.Total = comprador.AplicarDescuento(nuevoPedido.Total);
    }
    Console.WriteLine("\n PEDIDO REALIZADO CORRECTAMENTE");
    numeroPedido++;
    pedidos.Add(nuevoPedido);
    Console.WriteLine("Presione ENTER para continuar");
    Console.ReadLine();

}
void DetallesClientes(List<Cliente> clientes)
{
    Console.WriteLine("-------DETALLES CLIENTES--------");
    foreach (Cliente cliente in clientes)
    {
        Console.WriteLine("");
        cliente.MostrarInformacion();
        Console.WriteLine("");
        Console.WriteLine("----------------------");
    }
    Console.WriteLine("Presione ENTER para continuar");
    Console.ReadLine();
}
void DetallesVehiculos(List<Vehiculo> vehiculos)
{
    Console.WriteLine("-------DETALLES VEHICULOS--------");
    foreach (Vehiculo vehiculo in vehiculos)
    {
        Console.WriteLine("");
        vehiculo.MostrarInformacion();
        Console.WriteLine("");
        Console.WriteLine("----------------------");
    }
    Console.WriteLine("Presione ENTER para continuar");
    Console.ReadLine();
}
void DetallesPedidos(List<Pedido> pedidos)
{
    Console.WriteLine("----------DETALLES PEDIDOS--------\n\n");
    foreach(Pedido pedido in pedidos)
    {

        Console.WriteLine("");
        pedido.MostrarInformacion();
        Console.WriteLine("");
        Console.WriteLine("----------------------");
    }
    Console.WriteLine("Presione ENTER para continuar");
    Console.ReadLine();
}
void BuscarCliente(List<Cliente> clientes)
{
    Console.Write("\nIngrese Nombre Completo del cliente: ");
    string nombrebuscado = Console.ReadLine();
    bool encontrado = false;
    foreach (Cliente cliente in clientes)
    {
        if (cliente.Nombre.ToLower().Trim().Equals(nombrebuscado.ToLower().Trim()))
        {
            Console.WriteLine("---------------\n");
            cliente.MostrarInformacion();
            Console.WriteLine("\n---------------");
            encontrado = true;
        }
    }
    if(!encontrado) Console.WriteLine("\nCliente no fue encontrado");
    Console.WriteLine("Presione ENTER para continuar");
    Console.ReadLine();
}
void BuscarPedido(List<Pedido> pedidos)
{
    Console.Write("\nIngrese numero pedido: ");
    int numeroPedido = int.Parse(Console.ReadLine());
    bool encontrado = false;
    foreach (Pedido pedido in pedidos)
    {
        if (pedido.Id == numeroPedido)
        {
            Console.WriteLine("---------------\n");
            pedido.MostrarInformacion();
            Console.WriteLine("\n---------------");
            encontrado = true;
        }
    }
    if (!encontrado) Console.WriteLine("\nPedido no fue encontrado");
    Console.WriteLine("Presione ENTER para continuar");
    Console.ReadLine();
}
void BuscarVehiculo(List<Vehiculo> vehiculos)
{
    Console.WriteLine("-----BUSCAR VEHICULO-----");
    Console.Write("\nIngrese Matricula: ");
    string vehiculobuscado = Console.ReadLine();
    bool encontrado = false;
    foreach (Vehiculo vehiculo in vehiculos)
    {
        if (vehiculo.Matricula.ToLower().Trim().Equals(vehiculobuscado.ToLower().Trim()))
        {
            Console.WriteLine("---------------\n");
            vehiculo.MostrarInformacion();
            Console.WriteLine("\n---------------");
            encontrado = true;
        }
    }
    if (!encontrado) Console.WriteLine("\nVehiculo no fue encontrado");
    Console.WriteLine("Presione ENTER para continuar");
    Console.ReadLine();

}
