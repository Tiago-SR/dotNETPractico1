using DAL.DALs;
using DAL.IDALs;
using Practico1;
using Shared;

IDAL_Personas dal = new DAL_Personas_EF();
IDAL_Vehiculos dalVehiculo = new DAL_Vehiculos_EF();
StartUp startUp = new();
startUp.UpdateDatabase();






Console.WriteLine("Bienvenido a mi primera app .NET!!!");

static void enterToContinue() {
    Console.WriteLine("\nPresiona ENTER para continuar...");
    Console.ReadLine();
    Console.Clear();
}
static void printPersonas(IDAL_Personas dal, string filtro = "") {
    List<Persona> filtradas =
        [.. dal.GetPersonas().Where(p => p.Nombre.Contains(filtro) || p.Documento.Contains(filtro)).OrderBy(p => p.Nombre)];

    foreach (Persona p in filtradas)
        Console.WriteLine(p.GetString());
}
static void callMenu(IDAL_Personas dal) {
    string comando = "NUEVA";
    do {
        Console.WriteLine("Ingrese comando: ");
        Console.WriteLine("1)NUEVA");
        Console.WriteLine("2)IMPRIMIR");
        Console.WriteLine("2)IMPRIMIR ESPECIFICO");
        Console.WriteLine("4)ELIMINAR");
        Console.WriteLine("0)EXIT");

        comando = Console.ReadLine() ?? "";
        string filtro;
        switch (comando) {
            case "1":
                Console.Clear();
                Console.WriteLine("DAR DE ALTA PERSONA");
                Persona persona = new();
                Console.WriteLine("Ingrese el nombre de la persona: ");
                persona.Nombre = Console.ReadLine() ?? "";
                if (persona.Nombre.Trim().Equals(string.Empty)) {
                    Console.Clear();
                    Console.WriteLine("Error: El nombre no puede estar vacio.");
                    enterToContinue();
                    continue;
                }
                Console.WriteLine("Ingrese el documento de la persona: ");
                persona.Documento = Console.ReadLine() ?? "";
                if (persona.Documento.Trim().Equals(string.Empty)) {
                    Console.Clear();
                    Console.WriteLine("Error: El documento no puede estar vacio.");
                    enterToContinue();
                    continue;
                }
                try {
                    dal.AddPersona(persona);
                    Console.WriteLine("Persona agregada correctamente!");
                    enterToContinue();
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                break;

            case "2":
                Console.Clear();
                Console.WriteLine("Presione ENTER para listar todos.");
                Console.WriteLine("O ingrese Nombre/Documento a filtrar:");
                filtro = Console.ReadLine() ?? "";
                printPersonas(dal, filtro);
                enterToContinue();
                break;

            case "3":
                Console.Clear();
                Console.WriteLine("Ingrese Id a listar:");
                filtro = Console.ReadLine() ?? "";
                if (filtro.Equals(string.Empty)) {
                    Console.Clear();
                    Console.WriteLine("Error: El documento no puede estar vacio.");
                    enterToContinue();
                    continue;
                }
                long personaId;
                try {
                    personaId = (long)Convert.ToDouble(filtro);
                } catch (Exception) {
                    Console.Clear();
                    Console.WriteLine("Error: El documento debe ser un numero de 8 caracteres.");
                    enterToContinue();
                    continue;
                }
                Persona pe = dal.GetPersona(personaId);
                Console.WriteLine(pe.GetString());
                break;

            case "4":
                Console.Clear();
                Console.WriteLine("Ingrese ID a eliminar:");
                filtro = Console.ReadLine() ?? "";

                dal.DeletePersona((long)Convert.ToDouble(filtro));

                enterToContinue();
                break;
            case "0":
                break;

            default:
                Console.WriteLine("Comando no reconocido.");
                break;
        }

    }
    while (comando != "0");
}

// callMenu(dal);


//printPersonas(dal);

//try {
//    Persona crear = new() {
//        Nombre = "Valentino",
//        Apellido = "Silva",
//        Documento = "58677877",
//        FechaNacimiento = new DateOnly(2010, 08, 02),
//        Telefono = "091235344",
//        DireccionCalle = "Rivera",
//        DireccionNumero = "441"
//    };
//    crear = dal.AddPersona(crear);
//} catch (Exception ex) {
//    Console.WriteLine("El mensaje de error es: " + ex.Message);
//}

//try {
//    dal.DeletePersona(2);
//} catch (Exception ex) {
//    Console.WriteLine("El mensaje de error es: " + ex.Message);
//}

//try {
//    Persona p = dal.GetPersona(1);
//    p.Nombre = "Don Tiago";
//    //Console.WriteLine($"La id pasada es {id} y el resultado es {p.GetString()}");
//    dal.UpdatePersona(p);
//} catch (Exception ex) {
//    Console.WriteLine("El mensaje de error es: " + ex.Message);
//}

//try {
//    dalVehiculo.AddVehiculo(new Vehiculo {
//        Marca = "Elau",
//        Modelo = "Tonoto",
//        Matricula = "AAC5312",
//        OwnerId = 2
//    });
//    Console.WriteLine("Vehiculo agregado correctamente!");
//} catch (Exception ex) {
//    Console.WriteLine("El mensaje de error es: " + ex.Message);
//}

//try {
//    List<Vehiculo> vehiculos = dalVehiculo.GetVehiculos();
//    Console.WriteLine("Todos los vehiculos son:");
//    foreach (Vehiculo v in vehiculos)
//        Console.WriteLine($"\tMarca: {v.Marca}, Modelo: {v.Modelo}, Matricula: {v.Matricula}");
//    vehiculos = dalVehiculo.GetVehiculosFromOwner(1);
//    Console.WriteLine("Todos los vehiculos del OwnerId 2 es:");
//    foreach (Vehiculo v in vehiculos)
//        Console.WriteLine($"\tMarca: {v.Marca}, Modelo: {v.Modelo}, Matricula: {v.Matricula}");
//} catch (Exception ex) {
//    Console.WriteLine("El mensaje de error es: " + ex.Message);
//}

//try {
//    List<Vehiculo> vehiculos = dalVehiculo.GetVehiculos();
//    Console.WriteLine("Todos los vehiculos son:");
//    foreach (Vehiculo v in vehiculos)
//        Console.WriteLine($"\tMarca: {v.Marca}, Modelo: {v.Modelo}, Matricula: {v.Matricula}");
//    dalVehiculo.DeleteVehiculo(3);
//    vehiculos = dalVehiculo.GetVehiculos();
//    Console.WriteLine("Todos los vehiculos luego de eliminar:");
//    foreach (Vehiculo v in vehiculos)
//        Console.WriteLine($"\tMarca: {v.Marca}, Modelo: {v.Modelo}, Matricula: {v.Matricula}");
//} catch (Exception ex) {
//    Console.WriteLine("El mensaje de error es: " + ex.Message);
//}

//try {
//    List<Vehiculo> vehiculos = dalVehiculo.GetVehiculosFromOwner(1);
//    foreach (Vehiculo v in vehiculos)
//        Console.WriteLine($"\tMarca: {v.Marca}, Modelo: {v.Modelo}, Matricula: {v.Matricula}");

//    Vehiculo vehiculo = dalVehiculo.GetVehiculo(1);
//    vehiculo.Matricula = "elappu";
//    dalVehiculo.UpdateVehiculo(vehiculo);
//    Console.WriteLine("Vehiculo actualizado correctamente!");
//    vehiculos = dalVehiculo.GetVehiculosFromOwner(1);
//    foreach (Vehiculo v in vehiculos)
//        Console.WriteLine($"\tMarca: {v.Marca}, Modelo: {v.Modelo}, Matricula: {v.Matricula}");

//} catch (Exception ex) {
//    Console.WriteLine("El mensaje de error es: " + ex.Message);
//}
Console.WriteLine("Hasta luego!!!");
//Console.ReadLine();