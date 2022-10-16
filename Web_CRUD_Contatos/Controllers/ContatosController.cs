using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using iTextSharp.text.xml;
using iTextSharp.tool.xml.html;
using MessagePack;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using Org.BouncyCastle.Asn1.Cmp;
using Web_CRUD_Contatos.Models;

namespace Web_CRUD_Contatos.Controllers
{
    public class ContatosController : Controller
    {
        private readonly Contexto _context;

        public ContatosController(Contexto context)
        {
            _context = context;
        }

        // GET: Contatos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Contato.ToListAsync());
        }

        // GET: Contatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contato == null)
            {
                return NotFound();
            }

            var contato = await _context.Contato
                .FirstOrDefaultAsync(m => m.id == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // GET: Contatos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Nome,CPF,DataNascimento")] Contato contato)
        {               

            ValidaCPF validaCPF = new ValidaCPF();

            try
            {
                if (ModelState.IsValid & validaCPF.IsCpf(contato.CPF))
                {
                    _context.Add(contato);
                    await _context.SaveChangesAsync();                   
                
                    TempData["MessagemSucessoAdd"] = "Aluno adicionado com sucesso!!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["MessagemErrorCPF"] = "CPF invalido!!";
                    return RedirectToAction(nameof(Create));
                }

            }
            catch(System.Exception ex)
            {
                TempData["MessagemErrorCPF"] = "CPF invalido!!";
                return RedirectToAction(nameof(Create));

            }
            return View(contato);
        }

 

        // GET: Contatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contato == null)
            {
                return NotFound();
            }

            var contato = await _context.Contato.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }
            return View(contato);
        }

        // POST: Contatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Nome,CPF,DataNascimento")] Contato contato)
        {
            if (id != contato.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoExists(contato.id))
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
            return View(contato);
        }

        // GET: Contatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contato == null)
            {
                return NotFound();
            }

            var contato = await _context.Contato
                .FirstOrDefaultAsync(m => m.id == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contato == null)
            {
                return Problem("Entity set 'Contexto.Contato'  is null.");
            }
            var contato = await _context.Contato.FindAsync(id);
            if (contato != null)
            {
                _context.Contato.Remove(contato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoExists(int id)
        {
          return _context.Contato.Any(e => e.id == id);
        }
    }
}
