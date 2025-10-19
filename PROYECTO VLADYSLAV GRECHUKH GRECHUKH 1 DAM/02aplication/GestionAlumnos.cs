using System;
using System.Collections.Generic;
using System.Data;
using PROYECTO._03data;

namespace PROYECTO._02aplication
{
    public class GestionAlumnos
    {
        public Alumno Alumno { get; set; }
        public GestionAlumnos() => Alumno = new Alumno();
        public string Error() => BaseDatos.Error;
        public Alumno Primero() => GetOneBySql("SELECT * FROM alumnos ORDER BY dni ASC LIMIT 1");
        public Alumno Ultimo() => GetOneBySql("SELECT * FROM alumnos ORDER BY dni DESC LIMIT 1");
        public Alumno Siguiente()
        {
            if (Alumno.Dni == "")
                return null;

            return Navegar("SELECT * FROM alumnos WHERE dni > '{0}' ORDER BY dni ASC LIMIT 1");
        }
        public Alumno Anterior()
        {
            if (Alumno.Dni == null || Alumno.Dni == "")
                return null;

            return Navegar($@"SELECT * FROM alumnos WHERE dni < '{Alumno.Dni}' ORDER BY dni DESC LIMIT 1");
        }

        private Alumno Navegar(string sqlTemplate)
        {
            var alumno = GetOneBySql(string.Format(sqlTemplate, Alumno.Dni));
            return Alumno = alumno ?? Alumno;
        }

        public int Edit()
        {
            if (BaseDatos.Consulta($"SELECT 1 FROM alumnos WHERE dni='{Alumno.Dni}'")?.Rows.Count > 0)
            {
                return BaseDatos.Modificacion($@"
            UPDATE alumnos SET 
            nombre = '{Alumno.Nombre}', 
            apellidos = '{Alumno.Apellidos}', 
            telefono = '{Alumno.Telefono}', 
            poblacion = '{Alumno.Poblacion}'
            WHERE dni = '{Alumno.Dni}'");
            }
            return -1;
        }

        public int Insert()
        {
            var insert = BaseDatos.Consulta($"SELECT 1 FROM alumnos WHERE dni='{Alumno.Dni}'");
            if (insert?.Rows.Count > 0)
                return -1;

            return BaseDatos.Modificacion($@"INSERT INTO alumnos(dni, nombre, apellidos, telefono, poblacion) 
        VALUES('{Alumno.Dni}', '{Alumno.Nombre}', '{Alumno.Apellidos}', '{Alumno.Telefono}', '{Alumno.Poblacion}')");
        }


        public int Remove()
        {
            if (Alumno.Dni == null)
                return -1;

            var resultado = BaseDatos.Modificacion($@"DELETE FROM alumnos WHERE dni='{Alumno.Dni}'");

            if (resultado > 0)
                Alumno = new Alumno();

            return resultado;
        }

        public Alumno GetById(string dni) => GetOneBySql($"SELECT * FROM alumnos WHERE dni='{dni}'");
        public List<Alumno> GetAll()
        {
            var lista = new List<Alumno>();
            var ensenyar = BaseDatos.Consulta("SELECT * FROM alumnos ORDER BY dni");
            if (ensenyar != null)
            {
                foreach (DataRow dt in ensenyar.Rows)
                {
                    lista.Add(new Alumno(
                        dt["dni"].ToString(),
                        dt["nombre"].ToString(),
                        dt["apellidos"].ToString(),
                        dt["poblacion"].ToString(),
                        dt["telefono"].ToString()));
                }
            }
            return lista;
        }

        private Alumno GetOneBySql(string sql)
        {
            var dt = BaseDatos.Consulta(sql);
            if (dt?.Rows.Count > 0)
            {
                return new Alumno(
                    dt.Rows[0]["dni"].ToString(),
                    dt.Rows[0]["nombre"].ToString(),
                    dt.Rows[0]["apellidos"].ToString(),
                    dt.Rows[0]["poblacion"].ToString(),
                    dt.Rows[0]["telefono"].ToString());
            }
            return null;
        }
    }
}

