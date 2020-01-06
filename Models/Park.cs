using System.Collections.Generic;

namespace HikingTrailApi.Models
{
  public class Park
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Description { get; set; }
    public string Designation { get; set; }
    public List<Trail> Trails { get; set; } = new List<Trail>();
  }
}