using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace USmanterCursos.Models
{
    public class Curso
    {
        [Key]
        public int CursoId {get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataTermino { get; set; }
        public int? QtdAlunosTurma { get; set; }
        [ForeignKey ("Categoria")]
        public int CategoriaId { get; set; }
    }
}

        


