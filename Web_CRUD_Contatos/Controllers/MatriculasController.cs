using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_CRUD_Contatos.Models;
using System.Data;
using System.Data.SqlClient;
using Web_CRUD_Contatos.Migrations;

namespace Web_CRUD_Contatos.Controllers
{
    public class MatriculasController : Controller
    {
     
        private readonly Contexto _context;

        public MatriculasController(Contexto context)
        {
            _context = context;
        }

        // GET: Matriculas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Matriculas.ToListAsync());
        }

        // GET: Matriculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null || _context.Matriculas == null)
            {
                return NotFound();
            }

            var matriculas = await _context.Matriculas
                .FirstOrDefaultAsync(m => m.id == id);
            if (matriculas == null)
            {
                return NotFound();
            }
            return View(matriculas);
        }

        // GET: Matriculas/Create
        public IActionResult Create()
        {
            Matriculas matriculas = new Matriculas();

             matriculas.ContatosSelectListNome = new List<SelectListItem>();

             matriculas.ContatosSelectListCPF = new List<SelectListItem>();

             matriculas.ContatosSelectListCurso = new List<SelectListItem>();

             foreach (var contatos in _context.Contato)
             {
                matriculas.ContatosSelectListCPF.Add(new SelectListItem { Text = contatos.CPF });

                matriculas.ContatosSelectListNome.Add(new SelectListItem { Text =  contatos.Nome});
                
             }

             foreach (var cursos in _context.Curso)
             {
                 matriculas.ContatosSelectListCurso.Add(new SelectListItem { Text = cursos.Nome });

             }

             return View(matriculas);
            

        }        


        // POST: Matriculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Nome,CPF,NomeCurso")] Matriculas matriculas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matriculas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matriculas);

        }
       

        // GET: Matriculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Matriculas == null)
            {
                return NotFound();
            }

            var matriculas = await _context.Matriculas.FindAsync(id);
            if (matriculas == null)
            {
                return NotFound();
            }
            return View(matriculas);
        }

        // POST: Matriculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Nome,CPF,NomeCurso")] Matriculas matriculas)
        {
            if (id != matriculas.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matriculas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculasExists(matriculas.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(matriculas);
        }

        // GET: Matriculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Matriculas == null)
            {
                return NotFound();
            }

            var matriculas = await _context.Matriculas
                .FirstOrDefaultAsync(m => m.id == id);
            if (matriculas == null)
            {
                return NotFound();
            }

            return View(matriculas);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Matriculas == null)
            {
                return Problem("Entity set 'Contexto.Matriculas'  is null.");
            }
            var matriculas = await _context.Matriculas.FindAsync(id);
            if (matriculas != null)
            {
                _context.Matriculas.Remove(matriculas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculasExists(int id)
        {
            return _context.Matriculas.Any(e => e.id == id);
        }

       
    }
}