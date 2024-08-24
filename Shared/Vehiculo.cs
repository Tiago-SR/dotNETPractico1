namespace Shared {
    public class Vehiculo {
        public long Id { get; set; }
        public string Marca { get; set; } = "";
        public string Modelo { get; set; } = "";
        public string Matricula { get; set; } = "";
        public long OwnerId { get; set; } = -1;
    }
}
