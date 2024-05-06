using candinoS5AC.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace candinoS5AC
{
    public class PersonaRepository
    {
        string _dbPath;
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }

        private void init()
        {
            if (conn is not null)
                return;

            conn = new(_dbPath);
            conn.CreateTable<Persona>();
        }

        public PersonaRepository(string dbPath) 
        {
            _dbPath = dbPath;
        }

        public void AddNewPerson(string name)
        {
            int result = 0;

            try
            {
                init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre es requerido");
                Persona persona = new() { Name = name };
                result = conn.Insert(persona);
                StatusMessage = string.Format("Se insertó una persona", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error, no se insertó", name, ex.Message);
            }
        }

        public List<Persona> GetAllPeople()
        {
            try
            {
                init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al listar", ex.Message);
            }
            return new List<Persona>();
        }

        public void DeletePerson(int id)
        {
            try
            {
                init();
                conn.Delete<Persona>(id);
                StatusMessage = "Persona eliminada con éxito";
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al eliminar persona: {0}", ex.Message);
            }
            
        }

        public void UpdatePerson(int id, string nombreNew)
        {
            try
            {
                init();
                var person = conn.Table<Persona>().FirstOrDefault(p => p.Id == id); 
                if (person != null)
                {
                    person.Name = nombreNew;
                    conn.Update(person);
                    StatusMessage = "Nombre de persona actualizado con éxito";
                }
                else
                {
                    StatusMessage = "No se ha encontrado a la persona";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al actualizar el nombre: {0}", ex.Message);
            }
        }

    }
}
