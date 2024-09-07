using BL.IBLs;
using DAL.IDALs;
using Shared;

namespace BL.BLs {
    public class BL_Personas : IBL_Personas {
        private IDAL_Personas _personas;
        public BL_Personas(IDAL_Personas personas) {
            _personas = personas;
        }

        public List<Persona> GetPersonas() {
            return _personas.GetPersonas();
        }

        public Persona GetPersona(long id) {
            return _personas.GetPersona(id);
        }

        public Persona AddPersona(Persona persona) {
            return _personas.AddPersona(persona);
        }

        public void DeletePersona(long id) {
            _personas.DeletePersona(id);
        }

        public Persona UpdatePersona(Persona persona) {
            return _personas.UpdatePersona(persona);
        }
    }
}
