using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HikingTrailApi.Models;

namespace HikingTrailApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParkController : ControllerBase
  {
    private readonly DatabaseContext db;

    public ParkController(DatabaseContext context)
    {
      db = context;
    }

    // GET: api/Park
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> GetParks()
    {
      return await db.Parks.ToListAsync();
    }

    // GET: api/Park/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      var park = await db.Parks.FirstOrDefaultAsync(f => f.Id == id);
      // var park = await db.Parks.FindAsync(id);
      // the commented out one is only asking for the PK
      // the FirstOrDefaultAsync is more precise

      if (park == null)
      {
        return NotFound();
      }

      return park;
    }

    // PUT: api/Park/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPark(int id, Park park)
    {
      if (id != park.Id)
      {
        return BadRequest();
      }

      db.Entry(park).State = EntityState.Modified;

      try
      {
        await db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
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

    // POST: api/Park
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    public async Task<ActionResult<Park>> PostPark(Park park)
    {
      db.Parks.Add(park);
      await db.SaveChangesAsync();

      return CreatedAtAction("GetPark", new { id = park.Id }, park);
    }

    // DELETE: api/Park/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Park>> DeletePark(int id)
    {
      var park = await db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }

      db.Parks.Remove(park);
      await db.SaveChangesAsync();

      return park;
    }

    private bool ParkExists(int id)
    {
      return db.Parks.Any(e => e.Id == id);
    }
  }
}
