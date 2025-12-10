using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CupSeriesController : ControllerBase
    {
        private readonly NascarDBContext _context;

        public CupSeriesController(NascarDBContext context)
        {
            _context = context;
        }

        // GET: api/CupSeries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CupSeries>>> GetCupSeries()
        {
            return await _context.CupSeries.ToListAsync();
        }

        // GET: api/CupSeries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CupSeries>> GetCupSeries(int id)
        {
            var cupSeries = await _context.CupSeries.FindAsync(id);

            if (cupSeries == null)
            {
                return NotFound();
            }

            return cupSeries;
        }

        // PUT: api/CupSeries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCupSeries(int id, CupSeries cupSeries)
        {
            if (id != cupSeries.Id)
            {
                return BadRequest();
            }

            _context.Entry(cupSeries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CupSeriesExists(id))
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

        // POST: api/CupSeries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CupSeries>> PostCupSeries(CupSeries cupSeries)
        {
            _context.CupSeries.Add(cupSeries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCupSeries", new { id = cupSeries.Id }, cupSeries);
        }

        // DELETE: api/CupSeries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCupSeries(int id)
        {
            var cupSeries = await _context.CupSeries.FindAsync(id);
            if (cupSeries == null)
            {
                return NotFound();
            }

            _context.CupSeries.Remove(cupSeries);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CupSeriesExists(int id)
        {
            return _context.CupSeries.Any(e => e.Id == id);
        }
    }
}
