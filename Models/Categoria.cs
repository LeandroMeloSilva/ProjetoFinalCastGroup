using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace USmanterCursos.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
    }
}
