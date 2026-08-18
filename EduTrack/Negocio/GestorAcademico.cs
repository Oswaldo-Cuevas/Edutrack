using EduTrack.Entidades;
using EduTrack.Repositorio;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace EduTrack.Negocio
{
    /// <summary>
    /// Contiene la lógica de negocio del sistema académico.
    /// Implementa operaciones CRUD para estudiantes y cursos,
    /// además de asignaciones y generación de reportes.
    /// </summary>
    public class GestorAcademico
    {
        private readonly List<Estudiante> estudiantes;
        private readonly List<Curso> cursos;
        private readonly CsvRepositorio repositorio;

        public GestorAcademico(string rutaCsv)
        {
            estudiantes = new List<Estudiante>();
            cursos = new List<Curso>();
            repositorio = new CsvRepositorio(rutaCsv);
        }

        // ------------------- CRUD Estudiantes -------------------

        public void CrearEstudiante(Estudiante estudiante)
        {
            if (estudiante != null)
            {
                estudiantes.Add(estudiante);
                repositorio.GuardarEstudiante(estudiante);
            }
        }

        public Estudiante? LeerEstudiante(int id)
        {
            return estudiantes.FirstOrDefault(e => e.Id == id);
        }

        public void ActualizarEstudiante(int id, string nuevoNombre, string nuevaMatricula)
        {
            Estudiante? estudiante = estudiantes.FirstOrDefault(e => e.Id == id);
            if (estudiante != null)
            {
                estudiante.Nombre = nuevoNombre;
                estudiante.Matricula = nuevaMatricula;
                repositorio.ActualizarEstudiante(id, nuevoNombre, nuevaMatricula);
                System.Console.WriteLine($"Estudiante {id} actualizado.");
            }
        }

        public void EliminarEstudiante(int id)
        {
            Estudiante? estudiante = estudiantes.FirstOrDefault(e => e.Id == id);
            if (estudiante != null)
            {
                estudiantes.Remove(estudiante);
                repositorio.EliminarEstudiante(id);
                System.Console.WriteLine($"Estudiante {id} eliminado.");
            }
        }

        // ------------------- CRUD Cursos -------------------

        public void CrearCurso(Curso curso)
        {
            if (curso != null)
            {
                cursos.Add(curso);
                repositorio.GuardarCurso(curso);
            }
        }

        public Curso? LeerCurso(int id)
        {
            return cursos.FirstOrDefault(c => c.Id == id);
        }

        public void ActualizarCurso(int id, string nuevoNombre, string nuevoCodigo)
        {
            Curso? curso = cursos.FirstOrDefault(c => c.Id == id);
            if (curso != null)
            {
                curso.Nombre = nuevoNombre;
                curso.Codigo = nuevoCodigo;
                repositorio.ActualizarCurso(id, nuevoNombre, nuevoCodigo);
                System.Console.WriteLine($"Curso {id} actualizado.");
            }
        }

        public void EliminarCurso(int id)
        {
            Curso? curso = cursos.FirstOrDefault(c => c.Id == id);
            if (curso != null)
            {
                cursos.Remove(curso);
                repositorio.EliminarCurso(id);
                System.Console.WriteLine($"Curso {id} eliminado.");
            }
        }

        // ------------------- Asignaciones -------------------

        public void AsignarEstudianteACurso(int estudianteId, int cursoId)
        {
            Estudiante? estudiante = estudiantes.FirstOrDefault(e => e.Id == estudianteId);
            Curso? curso = cursos.FirstOrDefault(c => c.Id == cursoId);

            if (estudiante != null && curso != null)
            {
                System.Console.WriteLine($"Estudiante {estudiante.Nombre} asignado al curso {curso.Nombre}");
                // Aquí podrías guardar la relación en CSV si lo deseas
            }
            else
            {
                System.Console.WriteLine("No se pudo realizar la asignación: estudiante o curso no encontrado.");
            }
        }

        // ------------------- Listados -------------------

        public List<Estudiante> ObtenerEstudiantes() => estudiantes;
        public List<Curso> ObtenerCursos() => cursos;

        // ------------------- Reportes -------------------

        public void GenerarReporteInscripciones(string rutaReporte)
        {
            using (StreamWriter sw = new StreamWriter(rutaReporte, false))
            {
                sw.WriteLine("ID Estudiante,Nombre,Matricula");

                foreach (var estudiante in estudiantes)
                {
                    sw.WriteLine($"{estudiante.Id},{estudiante.Nombre},{estudiante.Matricula}");
                    System.Console.WriteLine($"ID: {estudiante.Id}, Nombre: {estudiante.Nombre}, Matrícula: {estudiante.Matricula}");
                }
            }

            System.Console.WriteLine($"Reporte generado en: {rutaReporte}");
        }
    }

}