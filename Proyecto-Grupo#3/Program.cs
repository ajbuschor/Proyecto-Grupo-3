using System;

class Estudiante    //creando la clase estudiante para poner el get y set de la cedula, nombre, promedio y condicion 
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public double Promedio { get; set; }
    public string Condicion { get; set; }
}

class Program //clase principal donde los vectores llegan a maximo 10 posiciones empezando desde 0
{
    static Estudiante[] estudiantes = new Estudiante[10];
    static int numEstudiantes = 0;

    static void Main(string[] args)
    {
        int opcion; // menu principal donde el usuario podra elegir una de las 7 opciones 
        do
        {
            Console.WriteLine("Menu principal");
            Console.WriteLine("1. Inicializar vectores");
            Console.WriteLine("2. Incluir estudiantes");
            Console.WriteLine("3. Consultar estudiantes");
            Console.WriteLine("4. Modificar estudiantes");
            Console.WriteLine("5. Eliminar estudiantes");
            Console.WriteLine("6. Submenu reportes");
            Console.WriteLine("7. Salirse del menu");
            Console.Write("Seleccione una de las opciones: ");
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion) //utilizando un switch para las opciones elegidas por el usuario sean ejecutadas
                {
                    case 1:
                        InicializarVectores();
                        break;
                    case 2:
                        IncluirEstudiantes();
                        break;
                    case 3:
                        ConsultarEstudiantes();
                        break;
                    case 4:
                        ModificarEstudiantes();
                        break;
                    case 5:
                        EliminarEstudiantes();
                        break;
                    case 6:
                        SubmenuReportes();
                        break;
                    case 7:
                        Console.WriteLine("Saliendo del programa muchas gracias!!!..."); // opcion para salirse del programa sacando al usuario del sistema.
                        break;
                    default:
                        Console.WriteLine("Opcion invalida, por favor, seleccione una opcion valida."); //en caso de que el usuario haya ingresado un numero menor o mayor que es solicitado
                        break;
                }
            }
            else //en caso de que el usuario ponga una letra la opcion seria invalida cual le pide ingresar de nuevo el dato con un numero
            {
                Console.WriteLine("digito invalida, por favor, ingrese un numero dentro del rango");
            }

        } while (opcion != 7);
    }

    static void InicializarVectores() //inicializa los vectores 0; monstrando por pantalla que los vectores ya estan inicializados
    {
        estudiantes = new Estudiante[10];
        numEstudiantes = 0;
        Console.WriteLine("vectores inicializados");
    }

    static void IncluirEstudiantes()  //incluir estudiantes en caso de que el usuario haya elegido la opcion 3 se ejuctaria el ingreso de los datos del estudiante
        //como la cedula, nombre y el promedio de la nota
    {
        if (numEstudiantes < 10)
        {
            Console.WriteLine("Ingrese los datos del estudiante:");
            Console.Write("Cedula: ");
            string cedula = Console.ReadLine();
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Promedio: ");
            double promedio;
            if (!double.TryParse(Console.ReadLine(), out promedio)) // el (if) por si el promedio ingresado fue incorrecto salte por pantalla que el promedio ingresado es falso
            {
                Console.WriteLine("Promedio invalido, ingrese un numero valido.");
                return;
            }

            string condicion; //la condicion de aprobar seria tener un promedio de 70 o mayor, en caso de que sea menor reprueba 
            // en el ejemplo dado seria reprobado entre mayor o igual que 60 y si es menor a 60 igual reprobado
            if (promedio >= 70)
                condicion = "APROBADO";
            else if (promedio >= 60)
                condicion = "REPROBADO";
            else
                condicion = "REPROBADO";

            estudiantes[numEstudiantes] = new Estudiante { Cedula = cedula, Nombre = nombre, Promedio = promedio, Condicion = condicion };
            numEstudiantes++;
            Console.WriteLine("Estudiante incluido ");
        }
        else
        {
            Console.WriteLine("No se pueden incluir mas estudiantes ya el limite de 10 estudiantes ha sido alcanzado"); // si el usuario ingresa mas de 10 estudiantes alcanza el maximo del vector 
        }
    }

    static void ConsultarEstudiantes() //opcion numero 3, preguntadole al usuario la cedula del estudiante para poder verificar y encontrar los datos del estudiante 
    {
        Console.Write("Ingrese la cedula del estudiante a consultar: ");
        string cedula = Console.ReadLine();
        bool encontrado = false;
        foreach (var estudiante in estudiantes) // muestra de cedula, nombre y el promedio con su condicion ya sea aprobada o reprobada
        {
            if (estudiante != null && estudiante.Cedula == cedula)
            {
                Console.WriteLine($"Cedula: {estudiante.Cedula}, Nombre: {estudiante.Nombre}, Promedio: {estudiante.Promedio}, Condicion: {estudiante.Condicion}");
                encontrado = true;
                break;
            }
        }
        if (!encontrado)
        {
            Console.WriteLine("Estudiante no encontrado."); // si la cedula ingresada contiene diferentes numeros no encuentra al estudiante 
        }
    }

    static void ModificarEstudiantes() //opcion numero 4 modificar al estudiante; ingresando el numero de cedula del estudiante que desee cambiarle el nombre y el promedio
    {
        Console.Write("Ingrese la cédula del estudiante a modificar: ");
        string cedula = Console.ReadLine();
        bool encontrado = false;
        for (int i = 0; i < numEstudiantes; i++) //utilizando un ciclo mientras el valor de i sea menor que numEstudiantes, el ciclo seguira ejecutandose
        {
            if (estudiantes[i].Cedula == cedula)
            {
                Console.WriteLine("Ingrese los nuevos datos del estudiante:"); //al modificar los datos la condicion tendra que ser == al numero de cedula 
                Console.Write("Nombre: ");
                estudiantes[i].Nombre = Console.ReadLine();
                Console.Write("Promedio: ");
                double promedio;
                if (!double.TryParse(Console.ReadLine(), out promedio))
                {
                    Console.WriteLine("Promedio invalido. Ingrese un numero valido");
                    return;
                }
                estudiantes[i].Promedio = promedio;

                if (promedio >= 70)
                    estudiantes[i].Condicion = "APROBADO"; //condiciones de promedio, si el promedio es mayor o igual que 70 se aprueba 
                else if (promedio >= 60)
                    estudiantes[i].Condicion = "REPROBADO";// si el promedio es mayor o igual que 60 reprueba
                else
                    estudiantes[i].Condicion = "REPROBADO";// en caso de que sea menor igual reprueba

                Console.WriteLine("Estudiante modificado exitosamente.");
                encontrado = true;
                break;
            }
        }
        if (!encontrado) // si la cedula ingresada es diferente o no existe el estudiante no sera encontrado
        {
            Console.WriteLine("Estudiante no encontrado.");
        }
    }

    static void EliminarEstudiantes() //opcion numero 5, eliminar a un estudiante, sera eleminada con base a la cedula del estudiante
    {
        Console.Write("Ingrese la cedula del estudiante a eliminar: ");
        string cedula = Console.ReadLine();
        bool encontrado = false;
        for (int i = 0; i < numEstudiantes; i++) //ciclo for mientras el valor de i sea menor que numEstudiantes el ciclo continuara ejecutandose
        {
            if (estudiantes[i].Cedula == cedula) // el dato ingresado tendra que ser igual == que la cedula para que sea ejecutado el ciclo 
            {
                for (int j = i; j < numEstudiantes - 1; j++)
                {
                    estudiantes[j] = estudiantes[j + 1]; // este bucle mueve los datos ingresados en el array estudiantes hacia la izquierda para poder eleminiar al ultimo 
                    //estudiante del array
                }
                estudiantes[numEstudiantes - 1] = null;
                numEstudiantes--;
                Console.WriteLine("Estudiante eliminado exitosamente "); // el estudiante sera eleminado correctamente 
                encontrado = true;
                break;
            }
        }
        if (!encontrado)
        {
            Console.WriteLine("Estudiante no encontrado "); // si la cedula ingresada es diferente el estudiante no sera encontrado
        }
    }

    static void SubmenuReportes() //opcion numero 6, sub menu de reportes, monstrando por pantalla otro menu en el cual contrae 3 opciones para el usuario
    {
        int opcion;

        bool salir = false; 
        while (!salir)
        {
            try                      // el (try catch) para monstrar primero el submenu con switch options en donde dependiendo de la opcion elegida del usuario sea ejecutado  
            {
                Console.WriteLine("Submenú Reportes");
                Console.WriteLine("1. Reporte Estudiantes por Condición");
                Console.WriteLine("2. Reporte Todos los datos");
                Console.WriteLine("3. Regresar Menu Principal");
                Console.Write("Seleccione una opción: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ReporteEstudiantesPorCondicion();
                        break;
                    case 2:
                        ReporteTodosLosDatos();
                        break;
                    case 3:
                        Console.WriteLine("Regresando al Menú Principal...");
                        salir = true; // Establecer salir como verdadero para salir del bucle
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
            catch (FormatException) // manejo de la excepcion monstrando un error si el usuario ingreso un numero invalido fuera del rango de los switch dentro del try
            {
                Console.WriteLine("Error: por favor, ingrese un numero valido ");
            }
        }


        static void ReporteEstudiantesPorCondicion() //reporte de estudiante por las condiciones en donde el usuario tendra que elegir para ver los datos de aprobado, reprobado o aplazado
        {
            Console.WriteLine("Seleccione la condicion para el reporte: ");
            Console.WriteLine("1. Aprobado");
            Console.WriteLine("2. Reprobado");
            Console.WriteLine("3. Aplazado");

            int opcion;
            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 3) //verificar si el rango ingresado sea dentro de 1 y el 3, si esta fuera del rango se ejecutaria 
            {
                Console.WriteLine("Opcion invalida, seleccione una opcion valida (1, 2 o 3) "); // una opcion invalida el usuario tendra que elegir dentro de este rango 1,2,3
                return;
            }

            string condicionSeleccionada;    // la condicion seleccionada dentro del rango de 1-3 , sino muestra opcion invalida para que una opcion correcta sea elegida
            switch (opcion)
            {
                case 1:
                    condicionSeleccionada = "APROBADO";
                    break;
                case 2:
                    condicionSeleccionada = "REPROBADO";
                    break;
                case 3:
                    condicionSeleccionada = "APLAZADO";
                    break;
                default:
                    Console.WriteLine("Opcion invalida ");
                    return;
            }

            // muestra los estudiantes con la condicisn seleccionada por el usuario
            Console.WriteLine($"Reporte de estudiantes con condicion '{condicionSeleccionada}':");
            bool encontrado = false;
            foreach (var estudiante in estudiantes) // verifica si el estudiante actual no es nulo y si su condicion coincide con la condicion seleccionada
            {
                if (estudiante != null && estudiante.Condicion == condicionSeleccionada) // si el estudiante cumple con la condicion muestra sus datos
                {
                    Console.WriteLine($"Cedula: {estudiante.Cedula}, Nombre: {estudiante.Nombre}, Promedio: {estudiante.Promedio}, Condición: {estudiante.Condicion}");
                    encontrado = true;
                }
            }

            if (!encontrado) //si no contiene una condicion no encuentra al estudiante 
            {
                Console.WriteLine($"No se encontraron estudiantes con la condicion '{condicionSeleccionada}'.");
            }

        }
        static void ReporteTodosLosDatos() // reporte de los datos, imprime por pantalla la cedula , nombre, promedio y la condicion de los estudiantes
        {
            Console.WriteLine("Reporte de todos los estudiantes:");
            foreach (var estudiante in estudiantes)
            {
                if (estudiante != null)
                {
                    Console.WriteLine($"Cedula: {estudiante.Cedula}, Nombre: {estudiante.Nombre}, Promedio: {estudiante.Promedio}, Condicion: {estudiante.Condicion}");
                }
            }

            // muestra de estadisticas 
            if (numEstudiantes > 0)
            {
                double promedioMayor = estudiantes.Where(est => est != null).Max(est => est.Promedio); // calcula el promedio mayor y el promedio menor entre todos los estudiantes
                double promedioMenor = estudiantes.Where(est => est != null).Min(est => est.Promedio);

                var estudiantesPromedioMayor = estudiantes.Where(est => est != null && est.Promedio == promedioMayor); // filtrando los estudiantes donde el promedio es igual al promedio mayor y al promedio menor
                var estudiantesPromedioMenor = estudiantes.Where(est => est != null && est.Promedio == promedioMenor);

                Console.WriteLine($"Estudiantes con el promedio mayor: "); //muestra los estudiantes con el mayor promedio
                foreach (var estudiante in estudiantesPromedioMayor)
                {
                    Console.WriteLine($"Cedula: {estudiante.Cedula}, Nombre: {estudiante.Nombre}, Promedio: {estudiante.Promedio}");
                }
                Console.WriteLine($"Estudiantes con el promedio menor: "); //muestra los estudiantes con el menor promedio
                foreach (var estudiante in estudiantesPromedioMenor)
                {
                    Console.WriteLine($"Cedula: {estudiante.Cedula}, Nombre: {estudiante.Nombre}, Promedio: {estudiante.Promedio}");
                }
            }
            else // si no hay estudiantes registrados muestra por pantalla que no hay estudiante 
            {
                Console.WriteLine("no hay estudiantes registrados");
            }

        }
    }   
     
    
 
}



      
   

