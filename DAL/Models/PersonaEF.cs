using Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DAL.Models {
    public class PersonaEF {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        [Required]
        public string Nombre { get; set; } = "";
        [Required, Length(8, 8)]
        public string Documento { get; set; } = "";
        public string Apellido { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string DireccionCalle { get; set; } = "";
        public string DireccionNumero { get; set; } = "";
        public DateOnly FechaNacimiento { get; set; } = new DateOnly();
        public Persona GetEntity() {
            return new Persona() {
                Id = Id,
                Documento = Documento,
                Nombre = Nombre,
                Apellido = Apellido,
                Telefono = Telefono,
                DireccionCalle = DireccionCalle,
                DireccionNumero = DireccionNumero,
                FechaNacimiento = FechaNacimiento
            };
        }
        public static PersonaEF FromEntity(Persona persona) {
            return new PersonaEF() {
                Id = persona.Id,
                Documento = persona.Documento,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Telefono = persona.Telefono,
                DireccionCalle = persona.DireccionCalle,
                DireccionNumero = persona.DireccionNumero,
                FechaNacimiento = persona.FechaNacimiento
            };
        }
    }
}

