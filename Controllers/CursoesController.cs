using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using USmanterCursos.Data;
using USmanterCursos.Models;

namespace USmanterCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoesController : ControllerBase
    {
        private readonly USmanterCursosContext _context;

        public CursoesController(USmanterCursosContext context)
        {
            _context = context;
        }

        // GET: api/Cursoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCurso()
        {
            return await _context.Curso.ToListAsync();
        }

        // GET: api/Cursoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            var curso = await _context.Curso.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        // PUT: api/Cursoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso curso)
        {
            try
            {
                if (ComparaCurso(curso))
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception)
            {
                return BadRequest("Curso já cadastrado.");
            }
            try
            {
                if (LocalizaCurso(curso))
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception)
            {
                return BadRequest("Existe(m) curso(s) planejados(s) dentro do período informado.");
            }

            if (id != curso.CursoId)
            {
                return BadRequest();
            }

            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cursoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
            
        {
            try
            {
                if (ComparaCurso(curso))
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception)
            {
                return BadRequest("Curso já cadastrado.");
            }
            try
            {
                if (LocalizaCurso(curso))
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception){
                return BadRequest("Existe(m) curso(s) planejados(s) dentro do período informado.");
            }
            if (curso.DataTermino < curso.DataInicio)
            {
                return BadRequest("Data início precisa ser menor que data término!");
            }
            _context.Curso.Add(curso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurso", new { id = curso.CursoId }, curso);
        }
        // DELETE: api/Cursoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _context.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            if (curso.DataTermino < DateTime.Now)
            {
                return BadRequest("Curso realizado não pode ser apagado!");
            }
         
            _context.Curso.Remove(curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool CursoExists(int id)
        {
            return _context.Curso.Any(e => e.CursoId == id);
        }
       
        private bool LocalizaCurso(Curso curso)
        {
            IQueryable<Curso> model = _context.Curso;

            if (!string.IsNullOrEmpty(curso.ToString()))
            {
                model = model.Where(row => row.CursoId != curso.CursoId);
            }
            foreach (var item in model)
            {
                if (item.DataTermino >= curso.DataInicio)
                {
                    return true;
                }
            }
            return false;

        }
        private bool ComparaCurso(Curso curso)
        {
            IQueryable<Curso> model = _context.Curso;

            if (!string.IsNullOrEmpty(curso.ToString()))
            {
                model = model.Where(row => row.CursoId != curso.CursoId);
            }
            foreach (var item in model)
            {
                if (item.Descricao == curso.Descricao)
                {
                    return true;
                }
            }
            return false;
        }
        
    }
}








