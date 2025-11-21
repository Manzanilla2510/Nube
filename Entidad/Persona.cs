using System.ComponentModel.DataAnnotations;

namespace prueba2.Entidad
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

    }
}
