using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using prueba2.Entidad;

namespace prueba2.Data
{
    public class prueba2Context : DbContext
    {
        public prueba2Context (DbContextOptions<prueba2Context> options)
            : base(options)
        {
        }

        public DbSet<prueba2.Entidad.Persona> Persona { get; set; } = default!;
    }
}
