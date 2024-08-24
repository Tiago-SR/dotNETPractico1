using DAL.IDALs;
using Microsoft.Data.SqlClient;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs {
    public class DAL_Personas_ADONET : IDAL_Personas {
        private readonly string connectionString = "Server=(localdb)\\mssqllocaldb;Database=practico1;Trusted_Connection=True;";

        public List<Persona> GetPersonas() {
            List<Persona> personas = new();

            using var connection = new SqlConnection(connectionString);
            string sql = "SELECT Id, Nombre, Documento FROM Personas WHERE Deleted_at is null";
            using var command = new SqlCommand(sql, connection);
            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read()) {
                var persona = new Persona() {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    Documento = reader.GetString(reader.GetOrdinal("Documento")),
                    Nombre = reader.GetString(reader.GetOrdinal("Nombre"))
                };
                personas.Add(persona);
            }


            return personas;
        }

        public Persona GetPersona(long id) {
            Persona p = new();
            using var connection = new SqlConnection(connectionString);
            string sql = "SELECT Id, Nombre, Documento FROM Personas WHERE Id = @id AND Deleted_at is null";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            using var reader = command.ExecuteReader();
            if (reader.Read()) {
                p.Id = reader.GetInt32(reader.GetOrdinal("id"));
                p.Documento = reader.GetString(reader.GetOrdinal("documento"));
                p.Nombre = reader.GetString(reader.GetOrdinal("nombre"));
            } else {
                throw new Exception("No existe un usuario con esa ID");
            }
            return p;
        }
        public void DeletePersona(long documento) {
            try {
                Persona p = new();
                using var connection = new SqlConnection(connectionString);
                string sql = "SELECT Id FROM Personas WHERE Documento = @documento AND Deleted_at is null";
                using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@documento", documento);
                connection.Open();
                using var reader = command.ExecuteReader();
                if (reader.Read()) {
                    sql = "UPDATE personas SET WHERE Documento = @documento";
                } else {
                    throw new Exception("No existe un usuario con esa ID");
                }
            } catch (Exception ex) {
                throw new Exception($"Ha ocurrido un error al eliminar un usuario. Msg: {ex.Message}");
            }
        }

        public Persona AddPersona(Persona persona) {
            try {
                using var connection = new SqlConnection(connectionString);
                string sql = "INSERT INTO Personas (Nombre, Documento) VALUES (@Nombre, @Doc)";
                using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Doc", persona.Documento);
                connection.Open();
                command.ExecuteNonQuery();
                return persona;
            } catch (Exception e) {
                throw new Exception($"Ha ocurrido un error. Msg: {e.Message}");
            }
        }

        public Persona UpdatePersona(Persona persona) {
            throw new NotImplementedException();
        }
    }
}
