using Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models {
    public class VehiculoEF {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Marca { get; set; } = "";

        [Required]
        public string Modelo { get; set; } = "";

        [Required]
        public string Matricula { get; set; } = "";

        // Clave Foránea
        [ForeignKey("Owner"), Required]
        public long OwnerId { get; set; }

        // Propiedad de Navegación
        public PersonaEF Owner { get; set; }

        public Vehiculo GetEntity() {
            return new Vehiculo() {
                Id = Id,
                Marca = Marca,
                Modelo = Modelo,
                Matricula = Matricula,
                OwnerId = OwnerId
            };
        }
        public static VehiculoEF FromEntity(Vehiculo v) {
            return new VehiculoEF() {
                Id = v.Id,
                Marca = v.Marca,
                Modelo = v.Modelo,
                Matricula = v.Matricula,
                OwnerId = v.OwnerId
            };
        }
    }
}