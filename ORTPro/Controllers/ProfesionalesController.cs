using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ORTPro.Context;
using ORTPro.Models;

namespace ORTPro.Controllers
{
    public class ProfesionalesController : Controller
    {
        private readonly ORTProDatabaseContext _context;

        public ProfesionalesController(ORTProDatabaseContext context)
        {
            _context = context;
        }

        // GET: Profesionales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profesionales.ToListAsync());
        }

        //GET: Profesionales/Buscador
        public async Task<IActionResult> Buscador(String nombre, int servicio, int barrio, int puntuacion) {
             
            IQueryable<Profesional> query = _context.Profesionales;

            if (nombre == null && servicio != 0 && barrio != 0 && puntuacion != 0)
            {
                query = _context.Profesionales;
            }


            if (nombre != null)
            {
                query = query.Where(p => p.Nombre.Contains(nombre));
            }

            if (servicio != 0)
            {
                switch (servicio)
                {
                    case 1:
                        query = query.Where(p => p.Servicio == Servicio.Gasista);
                        break;

                    case 2:
                        query = query.Where(p => p.Servicio == Servicio.Plomero);
                        break;

                    case 3:
                        query = query.Where(p => p.Servicio == Servicio.Cocinero);
                        break;

                    case 4:
                        query = query.Where(p => p.Servicio == Servicio.Carpintero);
                        break;

                    case 5:
                        query = query.Where(p => p.Servicio == Servicio.Masajista);
                        break;

                    case 6:
                        query = query.Where(p => p.Servicio == Servicio.Electricista);
                        break;

                    case 7:
                        query = query.Where(p => p.Servicio == Servicio.Mecánico);
                        break;

                    case 8:
                        query = query.Where(p => p.Servicio == Servicio.Pedicura);
                        break;
                }
            }

            if (barrio != 0)
            {
                switch (barrio)
                {
                    case 1:
                        query = query.Where(p => p.Barrio == Barrio.Recoleta);
                        break;

                    case 2:
                        query = query.Where(p => p.Barrio == Barrio.Chacarita);
                        break;

                    case 3:
                        query = query.Where(p => p.Barrio == Barrio.Palermo);
                        break;

                    case 4:
                        query = query.Where(p => p.Barrio == Barrio.Caballito);
                        break;

                    case 5:
                        query = query.Where(p => p.Barrio == Barrio.Retiro);
                        break;

                    case 6:
                        query = query.Where(p => p.Barrio == Barrio.Flores);
                        break;

                    case 7:
                        query = query.Where(p => p.Barrio == Barrio.Colegiales);
                        break;

                    case 8:
                        query = query.Where(p => p.Barrio == Barrio.Balvanera);
                        break;
                }
            }

            if (puntuacion != 0)
            {
                switch (puntuacion)
                {
                    case 1:
                        query = query.Where(p => p.Puntuacion == Puntuacion.uno);
                        break;

                    case 2:
                        query = query.Where(p => p.Puntuacion == Puntuacion.dos);
                        break;

                    case 3:
                        query = query.Where(p => p.Puntuacion == Puntuacion.tres);
                        break;

                    case 4:
                        query = query.Where(p => p.Puntuacion == Puntuacion.cuatro);
                        break;

                    case 5:
                        query = query.Where(p => p.Puntuacion == Puntuacion.cinco);
                        break;
                }
            }

            List<Profesional> profesionales = query.ToList();
           
            return View(profesionales);

        }

        // GET: Profesionales/Perfil/5
        public async Task<IActionResult> Perfil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesionales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesional == null)
            {
                return NotFound();
            }

            return View(profesional);
        }

        // GET: Profesionales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesionales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesional == null)
            {
                return NotFound();
            }

            return View(profesional);
        }

        // GET: Profesionales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profesionales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Servicio,Barrio,Puntuacion")] Profesional profesional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profesional);
        }

        // GET: Profesionales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesionales.FindAsync(id);
            if (profesional == null)
            {
                return NotFound();
            }
            return View(profesional);
        }

        // POST: Profesionales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Servicio,Barrio,Puntuacion")] Profesional profesional)
        {
            if (id != profesional.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesionalExists(profesional.Id))
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
            return View(profesional);
        }

        // GET: Profesionales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesionales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesional == null)
            {
                return NotFound();
            }

            return View(profesional);
        }

        // POST: Profesionales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesional = await _context.Profesionales.FindAsync(id);
            _context.Profesionales.Remove(profesional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesionalExists(int id)
        {
            return _context.Profesionales.Any(e => e.Id == id);
        }
    }
}
