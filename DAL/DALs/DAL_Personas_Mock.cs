﻿using DAL.IDALs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DALs
{
    public class DAL_Personas_Mock : IDAL_Personas
    {
        private long lastId = 7;

        private List<Persona> personas = new List<Persona>
        {
            new Persona { Id = 1, Nombre = "Juan", Documento = "1234567" },
            new Persona { Id = 2, Nombre = "Ana", Documento = "7654321" },
            new Persona { Id = 3, Nombre = "Pedro", Documento = "1234567" },
            new Persona { Id = 4, Nombre = "Maria", Documento = "7654321" },
            new Persona { Id = 5, Nombre = "Carlos", Documento = "1234567" },
            new Persona { Id = 6, Nombre = "Lucia", Documento = "7654321" },
            new Persona { Id = 7, Nombre = "Jose", Documento = "1234567" },
        };

        public Persona AddPersona(Persona persona)
        {
            lastId++;
            persona.Id = lastId;
            personas.Add(persona);
            return persona;
        }

        public void DeletePersona(long id)
        {
            personas.RemoveAll(p => p.Id == id);
        }

        public Persona GetPersona(long id)
        {
            Persona? p = personas.FirstOrDefault(p => p.Id == id);
            return p is null ? throw new Exception("No existe una persona con esa ID") : p;
        }

        public List<Persona> GetPersonas()
        {
            return personas;
        }

        public List<Vehiculo> GetVehiculos(long id) {
            throw new NotImplementedException();
        }

        public Persona UpdatePersona(Persona persona)
        {
            Persona? p = personas.FirstOrDefault(p => p.Id == persona.Id);
            if (p is null) throw new Exception("No existe una persona con esa ID");
            p.Nombre = persona.Nombre;
            p.Documento = persona.Documento;
            return p;
        }
    }
}
