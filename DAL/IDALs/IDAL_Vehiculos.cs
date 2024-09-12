using Shared;

namespace DAL.IDALs {
    public interface IDAL_Vehiculos {
        List<Vehiculo> GetVehiculos();
        Vehiculo GetVehiculo(long id);
        Vehiculo AddVehiculo(Vehiculo v);
        void DeleteVehiculo(long id);
        Vehiculo UpdateVehiculo(Vehiculo v);
    }
}
