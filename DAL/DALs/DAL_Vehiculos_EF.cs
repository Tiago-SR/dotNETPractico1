using DAL.Models;
using Shared;

namespace DAL.DALs {
    public class DAL_Vehiculos_EF : IDALs.IDAL_Vehiculos {
        public List<Vehiculo> GetVehiculos() {
            using var context = new DBContext();
            return [.. context.Vehiculos.Select(v => v.GetEntity())];
        }
        public Vehiculo GetVehiculo(long id) {
            using var context = new DBContext();
            VehiculoEF? v = context.Vehiculos.FirstOrDefault(v => v.Id == id);
            return v is null ? null: v.GetEntity();
        }
        public Vehiculo AddVehiculo(Vehiculo v) {
            if (v is null) throw new Exception("El vehiculo no puede ser nulo.");
            if (v.Marca.Trim().Equals(string.Empty)) throw new Exception("El vehiculo debe tener una marca.");
            if (v.Modelo.Trim().Equals(string.Empty)) throw new Exception("El vehiculo debe tener un modelo.");
            if (v.Matricula.Trim().Equals(string.Empty)) throw new Exception("El vehiculo debe tener una matricula.");
            if (v.OwnerId == -1) throw new Exception("El vehiculo debe tener un propietario.");
            using var context = new DBContext();
            PersonaEF? ownerEF = context.Personas.Find(v.OwnerId) ?? throw new Exception("El propietario no existe.");
            VehiculoEF vehiculo = VehiculoEF.FromEntity(v);
            vehiculo.Owner = ownerEF;
            context.Vehiculos.Add(vehiculo);
            context.SaveChanges();
            return vehiculo.GetEntity();
        }
        public void DeleteVehiculo(long id) {
            using var context = new DBContext();
            VehiculoEF? v = context.Vehiculos.FirstOrDefault(v => v.Id == id) ?? throw new Exception($"No existe Vehiculo con Id: {id}");
            context.Remove(v);
            context.SaveChanges();
        }
        public Vehiculo UpdateVehiculo(Vehiculo v) {
            if (v is null) throw new Exception("El vehiculo no puede ser nulo.");
            using var context = new DBContext();
            VehiculoEF? ve = context.Vehiculos.FirstOrDefault(v => v.Id == v.Id) ?? throw new Exception($"No existe Vehiculo con Id: {v.Id}");
            if (!v.Marca.Trim().Equals(string.Empty)) ve.Marca = v.Marca;
            if (!v.Modelo.Trim().Equals(string.Empty)) ve.Modelo = v.Modelo;
            if (!v.Matricula.Trim().Equals(string.Empty)) ve.Matricula = v.Matricula;
            if (v.OwnerId != -1 && v.OwnerId != ve.OwnerId) {
                PersonaEF? ownerEF = context.Personas.Find(v.OwnerId) ?? throw new Exception("El propietario no existe.");
                ve.Owner = ownerEF;
            }
            context.SaveChanges();
            return ve.GetEntity();
        }
    }
}
