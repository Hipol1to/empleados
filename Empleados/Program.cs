using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static LinkedList<Empleado> listaEmpleados = new LinkedList<Empleado>();
    static string filePath = "empleados.txt";

    static void Main()
    {
        CargarDatosDesdeArchivo();

        int opcion;
        do
        {
            MostrarMenu();
            opcion = ObtenerOpcion();
            ProcesarOpcion(opcion);
        } while (opcion != 6);
    }

    static void MostrarMenu()
    {
        Console.WriteLine("==== Menú ====");
        Console.WriteLine("1- Agregar Empleado");
        Console.WriteLine("2- Consultar Empleado");
        Console.WriteLine("3- Modificar Empleado");
        Console.WriteLine("4- Eliminar Empleado");
        Console.WriteLine("5- Guardar en Archivo");
        Console.WriteLine("6- Salir");
    }

    static int ObtenerOpcion()
    {
        Console.Write("Ingrese su opción: ");
        return int.Parse(Console.ReadLine());
    }

    static void ProcesarOpcion(int opcion)
    {
        switch (opcion)
        {
            case 1:
                AgregarEmpleado();
                break;
            case 2:
                ConsultarEmpleado();
                break;
            case 3:
                ModificarEmpleado();
                break;
            case 4:
                EliminarEmpleado();
                break;
            case 5:
                GuardarEnArchivo();
                break;
            case 6:
                Console.WriteLine("Saliendo del programa.");
                break;
            default:
                Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                break;
        }
    }

    static void AgregarEmpleado()
    {
        Console.WriteLine("==== Agregar Empleado ====");
        Empleado nuevoEmpleado = new Empleado();

        Console.Write("Id_Empleado: ");
        nuevoEmpleado.Id_Empleado = int.Parse(Console.ReadLine());

        Console.Write("Nombre: ");
        nuevoEmpleado.Nombre = Console.ReadLine();

        Console.Write("Dirección: ");
        nuevoEmpleado.Direccion = Console.ReadLine();

        Console.Write("Teléfono: ");
        nuevoEmpleado.Telefono = Console.ReadLine();

        Console.Write("Edad: ");
        nuevoEmpleado.Edad = int.Parse(Console.ReadLine());

        Console.Write("Salario: ");
        nuevoEmpleado.Salario = decimal.Parse(Console.ReadLine());

        listaEmpleados.AddLast(nuevoEmpleado);
        Console.WriteLine("Empleado agregado exitosamente.");
    }

    static void ConsultarEmpleado()
    {
        Console.WriteLine("==== Consultar Empleado ====");
        Console.Write("Ingrese Id_Empleado a consultar: ");
        int idEmpleadoConsulta = int.Parse(Console.ReadLine());

        Empleado empleadoEncontrado = listaEmpleados.FirstOrDefault(empleado => empleado.Id_Empleado == idEmpleadoConsulta);


        if (empleadoEncontrado != null)
        {
            Console.WriteLine($"Empleado encontrado:");
            MostrarDatosEmpleado(empleadoEncontrado);
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    static void ModificarEmpleado()
    {
        Console.WriteLine("==== Modificar Empleado ====");
        Console.Write("Ingrese Id_Empleado a modificar: ");
        int idEmpleadoModificar = int.Parse(Console.ReadLine());

        Empleado empleadoAModificar = listaEmpleados.FirstOrDefault(empleado => empleado.Id_Empleado == idEmpleadoModificar);
        

        if (empleadoAModificar != null)
        {
            Console.WriteLine($"Empleado encontrado:");
            MostrarDatosEmpleado(empleadoAModificar);

            Console.Write("Nuevo Nombre: ");
            empleadoAModificar.Nombre = Console.ReadLine();

            Console.Write("Nueva Dirección: ");
            empleadoAModificar.Direccion = Console.ReadLine();

            Console.Write("Nuevo Teléfono: ");
            empleadoAModificar.Telefono = Console.ReadLine();

            Console.Write("Nueva Edad: ");
            empleadoAModificar.Edad = int.Parse(Console.ReadLine());

            Console.Write("Nuevo Salario: ");
            empleadoAModificar.Salario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Empleado modificado exitosamente.");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    static void EliminarEmpleado()
    {
        Console.WriteLine("==== Eliminar Empleado ====");
        Console.Write("Ingrese Id_Empleado a eliminar: ");
        int idEmpleadoEliminar = int.Parse(Console.ReadLine());

        Empleado empleadoAEliminar = listaEmpleados.FirstOrDefault(empleado => empleado.Id_Empleado == idEmpleadoEliminar);

        if (empleadoAEliminar != null)
        {
            listaEmpleados.Remove(empleadoAEliminar);
            Console.WriteLine("Empleado eliminado exitosamente.");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    static void GuardarEnArchivo()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (Empleado empleado in listaEmpleados)
            {
                writer.WriteLine($"{empleado.Id_Empleado},{empleado.Nombre},{empleado.Direccion},{empleado.Telefono},{empleado.Edad},{empleado.Salario}");
            }
        }
        Console.WriteLine("Datos guardados en archivo exitosamente.");
    }

    static void CargarDatosDesdeArchivo()
    {
        if (File.Exists(filePath))
        {
            listaEmpleados.Clear();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] datosEmpleado = line.Split(',');
                    Empleado empleado = new Empleado
                    {
                        Id_Empleado = int.Parse(datosEmpleado[0]),
                        Nombre = datosEmpleado[1],
                        Direccion = datosEmpleado[2],
                        Telefono = datosEmpleado[3],
                        Edad = int.Parse(datosEmpleado[4]),
                        Salario = decimal.Parse(datosEmpleado[5])
                    };
                    listaEmpleados.AddLast(empleado);
                }
            }
            Console.WriteLine("Datos cargados desde archivo exitosamente.");
        }
    }

    static void MostrarDatosEmpleado(Empleado empleado)
    {
        Console.WriteLine($"Id_Empleado: {empleado.Id_Empleado}");
        Console.WriteLine($"Nombre: {empleado.Nombre}");
        Console.WriteLine($"Dirección: {empleado.Direccion}");
        Console.WriteLine($"Teléfono: {empleado.Telefono}");
        Console.WriteLine($"Edad: {empleado.Edad}");
        Console.WriteLine($"Salario: {empleado.Salario}");
    }
}

class Empleado
{
    public int Id_Empleado { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public int Edad { get; set; }
    public decimal Salario { get; set; }
}
