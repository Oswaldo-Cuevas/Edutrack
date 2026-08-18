namespace EduTrack.Entidades
{
    /// <summary>
    /// Representa un curso académico.
    /// Cada curso tiene un Id único, un nombre y un código.
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;   // Inicializado
        public string Codigo { get; set; } = string.Empty;   // Inicializado
    }
}