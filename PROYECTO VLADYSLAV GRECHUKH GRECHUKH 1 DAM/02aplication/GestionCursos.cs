using System;
using System.Collections.Generic;
using System.Data;
using PROYECTO._03data;
using PROYECTO._02aplication;

namespace PROYECTO._02aplication
{
    public class GestionCursos
    {
        public Curso Curso { get; set; }
        public GestionCursos() => Curso = new Curso();
        public string Error() => BaseDatos.Error;

        public List<Curso> GetAll()
        {
            var list = new List<Curso>();
            var dt = BaseDatos.Consulta($@"SELECT codigo, titulo, lugar_realizacion, n_plazas, precio FROM cursos ORDER BY codigo");
            if (dt != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    list.Add(new Curso(
                        r["codigo"].ToString(),
                        r["titulo"].ToString(),
                        r["lugar_realizacion"].ToString(),
                        int.Parse(r["n_plazas"].ToString()),
                        decimal.Parse(r["precio"].ToString())
                    ));
                }
            }
            return list;
        }

        public Curso Primero() => GetOne("SELECT codigo, titulo, lugar_realizacion, n_plazas, precio FROM cursos ORDER BY codigo ASC LIMIT 1");
        public Curso Ultimo() => GetOne("SELECT codigo, titulo, lugar_realizacion, n_plazas, precio FROM cursos ORDER BY codigo DESC LIMIT 1");
        public Curso Siguiente() => GetOne($"SELECT codigo, titulo, lugar_realizacion, n_plazas, precio FROM cursos WHERE codigo > '{Curso.Codigo}' ORDER BY codigo ASC LIMIT 1");
        public Curso Anterior() => GetOne($"SELECT codigo, titulo, lugar_realizacion, n_plazas, precio FROM cursos WHERE codigo < '{Curso.Codigo}' ORDER BY codigo DESC LIMIT 1");

        private Curso GetOne(string sql)
        {
            var dt = BaseDatos.Consulta(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];

                return new Curso(
                    row["codigo"].ToString(),
                    row["titulo"].ToString(),
                    row["lugar_realizacion"].ToString(),
                    int.Parse(row["n_plazas"].ToString()),
                    decimal.Parse(row["precio"].ToString())
                );
            }
            return null;
        }

        public int Insert()
        {
            var insert = BaseDatos.Consulta($@"SELECT 1 FROM cursos WHERE codigo = '{Curso.Codigo}'");

            if (insert != null && insert.Rows.Count > 0)
                return -1;

            var sql = $@"INSERT INTO cursos (codigo, titulo, lugar_realizacion, n_plazas, precio) VALUES (
            '{Curso.Codigo}', '{Curso.Titulo}', '{Curso.LugarRealizacion}', {Curso.NumPlazas}, {Curso.Precio})";
            return BaseDatos.Modificacion(sql);
        }

        public int Edit()
        {
            var edit = BaseDatos.Consulta($@"SELECT 1 FROM cursos WHERE codigo = '{Curso.Codigo}'");

            if (edit == null || edit.Rows.Count == 0)
                return -1;

            var sql = $@"UPDATE cursos SET 
            titulo = '{Curso.Titulo}', 
            lugar_realizacion = '{Curso.LugarRealizacion}',   
            n_plazas = {Curso.NumPlazas},                     
            precio = {Curso.Precio} 
            WHERE codigo = '{Curso.Codigo}'";

            return BaseDatos.Modificacion(sql);
        }

        public int Remove() => BaseDatos.Modificacion($"DELETE FROM cursos WHERE codigo = '{Curso.Codigo}'");
        public Curso GetById(string codigo) => GetOne($"SELECT codigo, titulo, lugar_realizacion, n_plazas, precio FROM cursos WHERE codigo = '{codigo}'");
    }
}

