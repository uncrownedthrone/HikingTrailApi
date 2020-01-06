using System.Linq;
using HikingTrailApi.Models;
using HikingTrailApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HikingTrailApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TrailController : ControllerBase
  {
    [HttpGet]
    public ActionResult GetAllTrails()
    {
      var db = new DatabaseContext();
      return Ok(db.Trails.OrderBy(o => o.Name));
    }
    [HttpPost]
    public ActionResult CreateTrail(NewTrail trail)
    // the NewTrail uses the view model and convert it to a model
    // and then adds it to the database
    {
      var tr = new Trail
      {
        Name = trail.Name,
        ParkId = trail.ParkId,
        Grade = trail.Grade,
        Length = trail.Length
      };
      var db = new DatabaseContext();
      db.Trails.Add(tr);
      db.SaveChanges();
      return Ok(tr);
    }

    [HttpGet("{id}")]
    // on the server side, id talks to int id below
    // this is how we're getting the data
    public ActionResult GetTrail(int id)
    {
      var db = new DatabaseContext();
      var trail = db.Trails.FirstOrDefault(f => f.Id == id);
      // the first letter of FirstOrDefault is used in the function
      // the capital ID is the property on the trail object
      // the lowercase id is the trail parameter
      // all lowercase id's need to match but they can be anything
      if (trail == null)
      {
        return NotFound(new NotFoundResponse
        {
          Message = "A trail with that id could not be found",
          QueryId = id.ToString()
        });
        // this needs to be in squigglies so we get back an object
      }
      else
      {
        return Ok(trail);
      }
    }
  }
}
