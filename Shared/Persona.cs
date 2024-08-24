namespace Shared
{
    public class Persona
    {
        public long Id { get; set; }
        private string documento = "";
        public string Nombre { get; set; } = "-- Sin Nombre --";
        public string Apellido { get; set; } = "-- Sin Apellido --";
        public string Telefono { get; set; } = "-- Sin Telefono --";
        public string DireccionCalle { get; set; } = "-- Sin Calle --";
        public string DireccionNumero { get; set; } = "-- Sin Numero --";
        public DateOnly FechaNacimiento { get; set; }
        public string Documento
        {
            get
            {
                return documento;
            }
            set
            {
                if (value.Length < 7)
                    throw new Exception("Formato de documento incorrecto.");
                else
                    documento = value.ToUpper();
            }
        }

        public string GetString()
        {
            return $"Id: {Id}, Documento: {documento}, Nombre: {Nombre}, Apellido: {Apellido}, Direccion: {DireccionCalle} {DireccionNumero}, Telefono: {Telefono}";
        }
        
    }
}
