using DAL.Models;
using Shared;


namespace DAL.DALs {
    public class DAL_Personas_EF : IDALs.IDAL_Personas {
        public Persona AddPersona(Persona p) {
            if (p is null) throw new Exception("Persona no puede ser null");
            if (p.Documento.Trim().Equals(string.Empty)) throw new Exception("Documento no puede estar vacio");
            if (p.Nombre.Trim().Equals(string.Empty)) throw new Exception("Nombre no puede estar vacio");
            if (p.Apellido.Trim().Equals(string.Empty)) throw new Exception("Apellido no puede estar vacio");
            if (p.Telefono.Trim().Equals(string.Empty)) throw new Exception("Telefono no puede estar vacio");
            if (p.DireccionCalle.Trim().Equals(string.Empty)) throw new Exception("Direccion no puede estar vacio");
            if (p.DireccionNumero.Trim().Equals(string.Empty)) throw new Exception("Direccion no puede estar vacio");
            if (p.FechaNacimiento.Year < 1800) throw new Exception("Fecha de nacimiento no puede ser menor a 1800");
            if (p.FechaNacimiento > DateOnly.FromDateTime(DateTime.Now)) throw new Exception("Fecha de nacimiento no puede ser mayor a la fecha actual");

            using var context = new DBContext();
            PersonaEF? personas = context.Personas.FirstOrDefault(pi => pi.Documento == p.Documento);
            if (personas is not null) throw new Exception($"Ya existe una persona con el documento: {p.Documento}");
            personas = PersonaEF.FromEntity(p);
            context.Personas.Add(personas);
            context.SaveChanges();
            return personas.GetEntity();
        }

        public void DeletePersona(long id) {
            using var context = new DBContext();
            PersonaEF? p = context.Personas.FirstOrDefault(p => p.Id == id) ?? throw new Exception($"No existe Persona con Id: {id}");
            context.Remove(p);
            context.SaveChanges();
        }

        public Persona GetPersona(long id) {
            using var context = new DBContext();
            PersonaEF? p = context.Personas.FirstOrDefault(p => p.Id == id);
            return p is null ? null : p.GetEntity();
        }

        public List<Persona> GetPersonas() {
            using var context = new DBContext();
            return [.. context.Personas.Select(p => p.GetEntity())];
        }

        public Persona UpdatePersona(Persona p) {
            if (p is null) throw new Exception("Persona no puede ser null");
            using var context = new DBContext();
            PersonaEF? pe = context.Personas.FirstOrDefault(p => p.Id == p.Id) ?? throw new Exception($"No existe Persona con Id: {p.Id}");
            if (!p.Nombre.Trim().Equals(string.Empty)) pe.Nombre = p.Nombre;
            if (!p.Apellido.Trim().Equals(string.Empty)) pe.Apellido = p.Apellido;
            if (!p.Telefono.Trim().Equals(string.Empty)) pe.Telefono = p.Telefono;
            if (!p.DireccionCalle.Trim().Equals(string.Empty)) pe.DireccionCalle = p.DireccionCalle;
            if (!p.DireccionNumero.Trim().Equals(string.Empty)) pe.DireccionNumero = p.DireccionNumero;
            if (p.FechaNacimiento.Year < 1800) pe.FechaNacimiento = p.FechaNacimiento;
            context.SaveChanges();
            return pe.GetEntity();
        }

        public List<Vehiculo> GetVehiculos(long id) {
            using var context = new DBContext();
            return [.. context.Vehiculos.Where(v => v.OwnerId == id).Select(v => v.GetEntity())];
        }
    }
}
