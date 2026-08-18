namespace EduTrack.Entidades
{
    /// <summary>
    /// Representa a un estudiante dentro del sistema académico.
    /// Cada estudiante tiene un Id único, un nombre y una matrícula.
    /// </summary>
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;   // Inicializado
        public string Matricula { get; set; } = string.Empty; // Inicializado
    }
}