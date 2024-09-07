using Shared;

namespace BL.IBLs {
    public interface IBL_Personas {
        List<Persona> GetPersonas();
        Persona GetPersona(long id);
        Persona AddPersona(Persona persona);
        void DeletePersona(long id);
        Persona UpdatePersona(Persona persona);

    }
}
