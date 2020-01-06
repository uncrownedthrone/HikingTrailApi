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
    [HttpPost]
  }
}
