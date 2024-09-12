
using BL.IBLs;
using DAL.IDALs;
using Shared;

namespace BL.BLs {
    public class BL_Vehiculo : IBL_Vehiculo {
        private IDAL_Vehiculos _vehiculos;
        public BL_Vehiculo(IDAL_Vehiculos vehiculos) {
            _vehiculos = vehiculos;
        }

        public Vehiculo AddVehiculo(Vehiculo v) {
            return _vehiculos.AddVehiculo(v);
        }

        public void DeleteVehiculo(long id) {
            _vehiculos.DeleteVehiculo(id);
        }

        public Vehiculo GetVehiculo(long id) {
            return _vehiculos.GetVehiculo(id);
        }

        public List<Vehiculo> GetVehiculos() {
            return _vehiculos.GetVehiculos();
        }

        public Vehiculo UpdateVehiculo(Vehiculo v) {
            return _vehiculos.UpdateVehiculo(v);
        }
    }
}
