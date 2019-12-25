using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsineAPI.Data;
using UsineAPI.Models;

namespace UsineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChefEquipesController : ControllerBase
    {
        private readonly UsineAPIContext _context;

        public ChefEquipesController(UsineAPIContext context)
        {
            _context = context;
        }

        // GET: api/ChefEquipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChefEquipe>>> GetChefEquipe()
        {
            return await _context.ChefEquipe.ToListAsync();
        }

        // GET: api/ChefEquipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChefEquipe>> GetChefEquipe(int id)
        {
            var chefEquipe = await _context.ChefEquipe.FindAsync(id);

            if (chefEquipe == null)
            {
                return NotFound();
            }

            return chefEquipe;
        }

        // PUT: api/ChefEquipes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChefEquipe(int id, ChefEquipe chefEquipe)
        {
            if (id != chefEquipe.Id)
            {
                return BadRequest();
            }

            _context.Entry(chefEquipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChefEquipeExists(id))
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

        // POST: api/ChefEquipes
        [HttpPost]
        public async Task<ActionResult<ChefEquipe>> PostChefEquipe(ChefEquipe chefEquipe)
        {
            _context.ChefEquipe.Add(chefEquipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChefEquipe", new { id = chefEquipe.Id }, chefEquipe);
        }

        // DELETE: api/ChefEquipes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChefEquipe>> DeleteChefEquipe(int id)
        {
            var chefEquipe = await _context.ChefEquipe.FindAsync(id);
            if (chefEquipe == null)
            {
                return NotFound();
            }

            _context.ChefEquipe.Remove(chefEquipe);
            await _context.SaveChangesAsync();

            return chefEquipe;
        }

        private bool ChefEquipeExists(int id)
        {
            return _context.ChefEquipe.Any(e => e.Id == id);
        }
    }
}
