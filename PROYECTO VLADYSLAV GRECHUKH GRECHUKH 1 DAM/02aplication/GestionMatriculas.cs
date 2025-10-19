using System;
using System.Collections.Generic;
using System.Data;
using PROYECTO._02aplication;
using PROYECTO._03data;

namespace PROYECTO._02aplication
{
    public class GestionMatriculas
    {
        public Matricula Matricula { get; set; } = new Matricula();
        public string Error() => BaseDatos.Error;
        public List<Matricula> GetAll()
        {
            var lista = new List<Matricula>();

            var dt = BaseDatos.Consulta($@"SELECT dni, codigo FROM matriculas ORDER BY dni, codigo");
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Matricula(
                        row["dni"].ToString(),
                        row["codigo"].ToString()
                    ));
                }
            }
            return lista;
        }


        public List<Alumno> GetAlumnosPorCurso(string codigo)
        {
            var lst = new List<Alumno>();
            var sql = $@"SELECT a.dni, a.nombre, a.apellidos, a.telefono, a.poblacion FROM alumnos a JOIN matriculas m ON a.dni = m.dni WHERE m.codigo = '{codigo}'";
            var dt = BaseDatos.Consulta(sql);
            if (dt != null)
                foreach (DataRow row in dt.Rows)
                    lst.Add(new Alumno(
                        row["dni"].ToString(),
                        row["nombre"].ToString(),
                        row["apellidos"].ToString(),
                        row["telefono"].ToString(),
                        row["poblacion"].ToString()
                    ));
            return lst;
        }

        public List<Curso> GetCursosPorAlumno(string dni)
        {
            var lista = new List<Curso>();
            var sql = $@"SELECT c.codigo,c.titulo,c.lugar_realizacion AS LugarRealizacion,c.n_plazas AS NumPlazas, c.precio
            FROM cursos c JOIN matriculas m ON c.codigo = m.codigo WHERE m.dni = '{dni}'";
            var dt = BaseDatos.Consulta(sql);

            if (dt != null)
                foreach (DataRow row in dt.Rows)
                    lista.Add(new Curso(
                        row["codigo"].ToString(),
                        row["titulo"].ToString(),
                        row["LugarRealizacion"].ToString(),
                        int.Parse(row["NumPlazas"].ToString()),
                        decimal.Parse(row["precio"].ToString())
                    ));
            return lista;
        }

        public int Insert()
        {
            var sqlCheck = $@"SELECT COUNT(*) AS Total FROM matriculas WHERE dni   = '{Matricula.Dni.Replace("'", "''")}'
            AND codigo = '{Matricula.CodigoCurso.Replace("'", "''")}'";
            var dataChk = BaseDatos.Consulta(sqlCheck);

            if (dataChk != null && dataChk.Rows.Count > 0 && int.Parse(dataChk.Rows[0]["Total"].ToString()) > 0)
            {
                return -1;
            }

            var sqlInsert = $@" INSERT INTO matriculas (dni, codigo) VALUES ('{Matricula.Dni.Replace("'", "''")}','{Matricula.CodigoCurso.Replace("'", "''")}')";
            return BaseDatos.Modificacion(sqlInsert);
        }


        public int Remove() => BaseDatos.Modificacion(
            $"DELETE FROM matriculas WHERE dni = '{Matricula.Dni}' AND codigo = '{Matricula.CodigoCurso}'");

        public Matricula GetById(string dni, string codigo)
        {
            var dt = BaseDatos.Consulta($"SELECT * FROM matriculas WHERE dni = '{dni}' AND codigo = '{codigo}'");
            if (dt != null && dt.Rows.Count > 0)
                return new Matricula(
                    dt.Rows[0]["dni"].ToString(),
                    dt.Rows[0]["codigo"].ToString()
                );
            return null;
        }
    }
}
