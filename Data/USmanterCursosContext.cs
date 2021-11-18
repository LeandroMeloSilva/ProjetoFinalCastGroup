using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using USmanterCursos.Models;

namespace USmanterCursos.Data
{
    public class USmanterCursosContext : DbContext
    {
        public USmanterCursosContext (DbContextOptions<USmanterCursosContext> options)
            : base(options)
        {
        }

        public DbSet<USmanterCursos.Models.Curso> Curso { get; set; }

        public DbSet<USmanterCursos.Models.Log> Log { get; set; }

        public DbSet<USmanterCursos.Models.Categoria> Categorias { get; set; }
    }
}
