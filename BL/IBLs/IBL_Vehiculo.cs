using Shared;

namespace BL.IBLs {
    public interface IBL_Vehiculo {
        List<Vehiculo> GetVehiculos();
        List<Vehiculo> GetVehiculosFromOwner(long id);
        Vehiculo GetVehiculo(long id);
        Vehiculo AddVehiculo(Vehiculo v);
        void DeleteVehiculo(long id);
        Vehiculo UpdateVehiculo(Vehiculo v);
    }
}
