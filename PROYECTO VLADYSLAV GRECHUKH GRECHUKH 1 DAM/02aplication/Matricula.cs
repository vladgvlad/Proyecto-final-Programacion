using System;

namespace PROYECTO._02aplication
{
    public class Matricula
    {
        public string Dni { get; set; }
        public string CodigoCurso { get; set; }
        public Matricula() { }
        public Matricula(string dni, string codigoCurso)
        {
            Dni = dni;
            CodigoCurso = codigoCurso;
        }
    }
}
