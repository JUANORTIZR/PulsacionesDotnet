using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class PersonaService
    {
        private readonly ConnectionManager _conexion;
        private readonly PersonaRepository _repositorio;

        public PersonaService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new PersonaRepository(_conexion);
        }


        public ConsultarTodosResponse ConsultarTodos()
        {
            try
            {
                 _conexion.Open();
            List<Persona> personas = _repositorio.ConsultarTodos();
            _conexion.Close();
            return new ConsultarTodosResponse(personas);
            }
            catch (Exception e)
            {
                return new ConsultarTodosResponse(e.Message);
            }
           
        }

        public GuardarPersonaResponse Guardar(Persona persona)
        {
            try
            {
                persona.CalcularPulsaciones();
                _conexion.Open();
                _repositorio.Guardar(persona);
                _conexion.Close();
                return new GuardarPersonaResponse(persona);
            }
            catch (Exception e)
            {
                return new GuardarPersonaResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        

    }

    public class GuardarPersonaResponse
    {
        public GuardarPersonaResponse(Persona persona)
        {
            Error = false;
            Persona = persona;
        }
        public GuardarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Persona Persona { get; set; }

    }


    public class ConsultarTodosResponse
    {
        public ConsultarTodosResponse(List<Persona> personas)
        {
            Error = false;
            Personas = personas;
        }
        public ConsultarTodosResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Persona> Personas { get; set; }
    }

}