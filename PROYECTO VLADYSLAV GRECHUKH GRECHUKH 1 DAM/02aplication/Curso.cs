using System;
namespace PROYECTO._02aplication
{
    public class Curso
    {
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public string LugarRealizacion { get; set; }
        public int NumPlazas { get; set; }
        public decimal Precio { get; set; }

        public Curso() { }

        public Curso(string codigo, string titulo, string lugarRealizacion, int numPlazas, decimal precio)
        {
            Codigo = codigo;
            Titulo = titulo;
            LugarRealizacion = lugarRealizacion;
            NumPlazas = numPlazas;
            Precio = precio;
        }
    }
}
