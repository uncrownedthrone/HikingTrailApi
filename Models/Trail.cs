namespace HikingTrailApi.Models
// this is similar to a **** in react
{
  public class Trail
  // classes are objects
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public double Length { get; set; }
    public string Grade { get; set; }
    public int ParkId { get; set; }
    // this is the FK
    public Park Park { get; set; }
    // ParkID and Park are our relationship properties. parkid by itself, but as soon as we
    // add a reference (Park Park), it's a foreign key. Park ID and Park Park (the table)
    // ParkId and Park need to match. if you change it, it would be UnicornId and Unicorn
  }
}