using EduTrack.Entidades;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace EduTrack.Repositorio
{
    /// <summary>
    /// Maneja la persistencia de datos en archivos CSV.
    /// Permite guardar, leer, actualizar y eliminar estudiantes y cursos.
    /// </summary>
    public class CsvRepositorio
    {
        private readonly string rutaArchivo;

        public CsvRepositorio(string ruta)
        {
            rutaArchivo = ruta;
        }

        // ------------------- Guardar -------------------

        public void GuardarEstudiante(Estudiante estudiante)
        {
            using (StreamWriter sw = new StreamWriter(rutaArchivo, true))
            {
                sw.WriteLine($"ESTUDIANTE,{estudiante.Id},{estudiante.Nombre},{estudiante.Matricula}");
            }
        }

        public void GuardarCurso(Curso curso)
        {
            using (StreamWriter sw = new StreamWriter(rutaArchivo, true))
            {
                sw.WriteLine($"CURSO,{curso.Id},{curso.Nombre},{curso.Codigo}");
            }
        }

        // ------------------- Leer -------------------

        public List<string> LeerDatos()
        {
            List<string> lineas = new List<string>();
            if (File.Exists(rutaArchivo))
            {
                lineas.AddRange(File.ReadAllLines(rutaArchivo));
            }
            return lineas;
        }

        // ------------------- Actualizar -------------------

        public void ActualizarEstudiante(int id, string nuevoNombre, string nuevaMatricula)
        {
            if (!File.Exists(rutaArchivo)) return;

            var lineas = File.ReadAllLines(rutaArchivo).ToList();

            for (int i = 0; i < lineas.Count; i++)
            {
                var partes = lineas[i].Split(',');
                if (partes.Length > 0 && partes[0] == "ESTUDIANTE" && int.Parse(partes[1]) == id)
                {
                    lineas[i] = $"ESTUDIANTE,{id},{nuevoNombre},{nuevaMatricula}";
                }
            }

            File.WriteAllLines(rutaArchivo, lineas);
        }

        public void ActualizarCurso(int id, string nuevoNombre, string nuevoCodigo)
        {
            if (!File.Exists(rutaArchivo)) return;

            var lineas = File.ReadAllLines(rutaArchivo).ToList();

            for (int i = 0; i < lineas.Count; i++)
            {
                var partes = lineas[i].Split(',');
                if (partes.Length > 0 && partes[0] == "CURSO" && int.Parse(partes[1]) == id)
                {
                    lineas[i] = $"CURSO,{id},{nuevoNombre},{nuevoCodigo}";
                }
            }

            File.WriteAllLines(rutaArchivo, lineas);
        }

        // ------------------- Eliminar -------------------

        public void EliminarEstudiante(int id)
        {
            if (!File.Exists(rutaArchivo)) return;

            var lineas = File.ReadAllLines(rutaArchivo).ToList();
            lineas = lineas.Where(l =>
            {
                var partes = l.Split(',');
                return !(partes.Length > 0 && partes[0] == "ESTUDIANTE" && int.Parse(partes[1]) == id);
            }).ToList();

            File.WriteAllLines(rutaArchivo, lineas);
        }

        public void EliminarCurso(int id)
        {
            if (!File.Exists(rutaArchivo)) return;

            var lineas = File.ReadAllLines(rutaArchivo).ToList();
            lineas = lineas.Where(l =>
            {
                var partes = l.Split(',');
                return !(partes.Length > 0 && partes[0] == "CURSO" && int.Parse(partes[1]) == id);
            }).ToList();

            File.WriteAllLines(rutaArchivo, lineas);
        }
    }
}