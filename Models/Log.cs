using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace USmanterCursos.Models
{
    public class Log
    {   
        [Key]
        public int LogId { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime DtUltAtual { get; set; }
        public string UsuarioRes { get; set; }
    }
}
