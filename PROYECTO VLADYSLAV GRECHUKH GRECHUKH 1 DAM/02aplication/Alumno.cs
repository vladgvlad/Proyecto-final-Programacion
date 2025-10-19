using System;

namespace PROYECTO._02aplication
{
    public class Alumno
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Poblacion { get; set; }
        public string Telefono { get; set; }


        public Alumno()
        {
        }

        public Alumno(string dni, string nombre, string apellidos, string poblacion, string telefono)
        {
            Dni = dni;
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
            Poblacion = poblacion;
        }
    }
}

