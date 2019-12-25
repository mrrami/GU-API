﻿using System;
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

    public class EmployesController : ControllerBase
    {
        private readonly UsineAPIContext _context;

        public EmployesController(UsineAPIContext context)
        {
            _context = context;
        }

        // GET: api/Employes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employe>>> GetEmploye()
        {
            return await _context.Employe.ToListAsync();
        }

        // GET: api/Employes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employe>> GetEmploye(int id)
        {
            var employe = await _context.Employe.FindAsync(id);

            if (employe == null)
            {
                return NotFound();
            }

            return employe;
        }

        // PUT: api/Employes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploye(int id, Employe employe)
        {
            if (id != employe.Id)
            {
                return BadRequest();
            }

            _context.Entry(employe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeExists(id))
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

        // POST: api/Employes
        [HttpPost]
        public async Task<ActionResult<Employe>> PostEmploye(Employe employe)
        {
            _context.Employe.Add(employe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmploye", new { id = employe.Id }, employe);
        }

        // DELETE: api/Employes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employe>> DeleteEmploye(int id)
        {
            var employe = await _context.Employe.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }

            _context.Employe.Remove(employe);
            await _context.SaveChangesAsync();

            return employe;
        }

        private bool EmployeExists(int id)
        {
            return _context.Employe.Any(e => e.Id == id);
        }
    }
}
