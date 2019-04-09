using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheThings.Data;
using TheThings.Models;

namespace TheThings_FirstAspApp.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingsController : ControllerBase
    {
        private readonly ThingsDbContext _context;

        public ThingsController(ThingsDbContext context)
        {
            _context = context;
        }

        // GET: api/Things
        [HttpGet]
        public IEnumerable<Thing> GetThings()
        {
            return _context.Things;
        }

        // GET: api/Things/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetThing([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var thing = await _context.Things.FindAsync(id);

            if (thing == null)
            {
                return NotFound();
            }

            return Ok(thing);
        }

        // PUT: api/Things/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThing([FromRoute] int id, [FromBody] Thing thing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != thing.Id)
            {
                return BadRequest();
            }

            _context.Entry(thing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThingExists(id))
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

        // POST: api/Things
        [HttpPost]
        public async Task<IActionResult> PostThing([FromBody] Thing thing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Things.Add(thing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThing", new { id = thing.Id }, thing);
        }

        // DELETE: api/Things/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThing([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var thing = await _context.Things.FindAsync(id);
            if (thing == null)
            {
                return NotFound();
            }

            _context.Things.Remove(thing);
            await _context.SaveChangesAsync();

            return Ok(thing);
        }

        private bool ThingExists(int id)
        {
            return _context.Things.Any(e => e.Id == id);
        }
    }
}