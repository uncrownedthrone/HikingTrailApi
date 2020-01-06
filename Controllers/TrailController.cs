using System.Linq;
using HikingTrailApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HikingTrailApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TrailController : ControllerBase
  {
    [HttpGet("{id}")]
    // on the server side, id talks to int id below
    public ActionResult GetTrail(int id)
    {
      var db = new DatabaseContext();
      var trail = db.Trails.FirstOrDefault(f => f.Id == id);
      if (trail == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(trail);
      }
    }
  }
}
