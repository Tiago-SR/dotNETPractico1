using DAL.DALs;
using DAL.IDALs;
using DataAccessLayer.DALs;
using Shared;

IDAL_Personas dal = new DAL_Personas_ADONET();

string comando = "NUEVA";

Console.WriteLine("Bienvenido a mi primera app .NET!!!");

do {
    Console.WriteLine("Ingrese comando: ");
    Console.WriteLine("1)NUEVA");
    Console.WriteLine("2)IMPRIMIR");
    Console.WriteLine("3)ELIMINAR");
    Console.WriteLine("0)EXIT");

    try {
        comando = Console.ReadLine().ToUpper();
        string filtro;
        switch (comando) {
            case "1":
                Console.Clear();
                Console.WriteLine("DAR DE ALTA PERSONA");
                Persona persona = new Persona();
                Console.WriteLine("Ingrese el nombre de la persona: ");
                persona.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el documento de la persona: ");
                persona.Documento = Console.ReadLine();
                try {
                    dal.AddPersona(persona);
                    Console.WriteLine("Persona agregada correctamente!");
                    Console.ReadLine();
                    Console.Clear();
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                break;

            case "2":
                Console.Clear();
                Console.WriteLine("Presione ENTER para listar todos.");
                Console.WriteLine("O ingrese Nombre/Documento a filtrar:");
                filtro = Console.ReadLine();

                List<Persona> filtradas =
                    dal.GetPersonas().Where(p => p.Nombre.Contains(filtro) || p.Documento.Contains(filtro))
                            .OrderBy(p => p.Nombre)
                            .ToList();

                foreach (Persona p in filtradas)
                    Console.WriteLine(p.GetString());
                Console.WriteLine("\nPresiona ENTER para continuar...");
                Console.ReadLine();
                Console.Clear();
                break;

            case "3":
                Console.Clear();
                Console.WriteLine("Ingrese ID a eliminar:");
                filtro = Console.ReadLine();

                dal.DeletePersona(filtro);

                Console.WriteLine("\nPresiona ENTER para continuar...");
                Console.ReadLine();
                Console.Clear();
                break;
            case "0":
                break;

            default:
                Console.WriteLine("Comando no reconocido.");
                break;
        }
    } catch (Exception ex) {
        Console.WriteLine(ex.Message);
    }
}
while (comando != "0");

Console.WriteLine("Hasta luego!!!");
Console.ReadLine();