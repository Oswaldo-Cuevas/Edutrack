using EduTrack.Entidades;
using EduTrack.Negocio;
using System;

namespace EduTrack.Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            GestorAcademico gestor = new GestorAcademico("datos.csv");
            int opcion;

            do
            {
                Console.WriteLine("\n=== MENU PRINCIPAL ===");
                Console.WriteLine("1. Crear Estudiante");
                Console.WriteLine("2. Leer Estudiante");
                Console.WriteLine("3. Actualizar Estudiante");
                Console.WriteLine("4. Eliminar Estudiante");
                Console.WriteLine("5. Crear Curso");
                Console.WriteLine("6. Leer Curso");
                Console.WriteLine("7. Actualizar Curso");
                Console.WriteLine("8. Eliminar Curso");
                Console.WriteLine("9. Asignar Estudiante a Curso");
                Console.WriteLine("10. Generar reporte de inscripciones");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = -1;

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese Id del estudiante: ");
                        int idEst = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Ingrese nombre: ");
                        string nombreEst = Console.ReadLine() ?? "";
                        Console.Write("Ingrese matrícula: ");
                        string matricula = Console.ReadLine() ?? "";

                        Estudiante nuevoEst = new Estudiante { Id = idEst, Nombre = nombreEst, Matricula = matricula };
                        gestor.CrearEstudiante(nuevoEst);
                        break;

                    case 2:
                        Console.Write("Ingrese Id del estudiante: ");
                        int idLeerEst = int.Parse(Console.ReadLine() ?? "0");
                        var est = gestor.LeerEstudiante(idLeerEst);
                        Console.WriteLine(est != null ? $"Estudiante: {est.Nombre}, Matrícula: {est.Matricula}" : "No encontrado.");
                        break;

                    case 3:
                        Console.Write("Ingrese Id del estudiante: ");
                        int idActEst = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Nuevo nombre: ");
                        string nuevoNombreEst = Console.ReadLine() ?? "";
                        Console.Write("Nueva matrícula: ");
                        string nuevaMatricula = Console.ReadLine() ?? "";
                        gestor.ActualizarEstudiante(idActEst, nuevoNombreEst, nuevaMatricula);
                        break;

                    case 4:
                        Console.Write("Ingrese Id del estudiante: ");
                        int idDelEst = int.Parse(Console.ReadLine() ?? "0");
                        gestor.EliminarEstudiante(idDelEst);
                        break;

                    case 5:
                        Console.Write("Ingrese Id del curso: ");
                        int idCurso = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Ingrese nombre del curso: ");
                        string nombreCurso = Console.ReadLine() ?? "";
                        Console.Write("Ingrese código del curso: ");
                        string codigoCurso = Console.ReadLine() ?? "";

                        Curso nuevoCurso = new Curso { Id = idCurso, Nombre = nombreCurso, Codigo = codigoCurso };
                        gestor.CrearCurso(nuevoCurso);
                        break;

                    case 6:
                        Console.Write("Ingrese Id del curso: ");
                        int idLeerCurso = int.Parse(Console.ReadLine() ?? "0");
                        var curso = gestor.LeerCurso(idLeerCurso);
                        Console.WriteLine(curso != null ? $"Curso: {curso.Nombre}, Código: {curso.Codigo}" : "No encontrado.");
                        break;

                    case 7:
                        Console.Write("Ingrese Id del curso: ");
                        int idActCurso = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Nuevo nombre: ");
                        string nuevoNombreCurso = Console.ReadLine() ?? "";
                        Console.Write("Nuevo código: ");
                        string nuevoCodigoCurso = Console.ReadLine() ?? "";
                        gestor.ActualizarCurso(idActCurso, nuevoNombreCurso, nuevoCodigoCurso);
                        break;

                    case 8:
                        Console.Write("Ingrese Id del curso: ");
                        int idDelCurso = int.Parse(Console.ReadLine() ?? "0");
                        gestor.EliminarCurso(idDelCurso);
                        break;

                    case 9:
                        Console.Write("Ingrese Id del estudiante: ");
                        int idEstAsignar = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Ingrese Id del curso: ");
                        int idCursoAsignar = int.Parse(Console.ReadLine() ?? "0");
                        gestor.AsignarEstudianteACurso(idEstAsignar, idCursoAsignar);
                        break;

                    case 10:
                        Console.Write("Ingrese nombre del archivo de reporte (ej: reporte.csv): ");
                        string rutaReporte = Console.ReadLine() ?? "reporte.csv";
                        gestor.GenerarReporteInscripciones(rutaReporte);
                        break;

                    case 0:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

            } while (opcion != 0);
        }
    }
}