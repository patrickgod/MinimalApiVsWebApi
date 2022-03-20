namespace MinimalApiVsWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<VideoGame> VideoGames => Set<VideoGame>();
    }

  //    {
  //  "id": 1,
  //  "name": "Half Life 2",
  //  "developer": "Valve",
  //  "release": "2004-11-16T00:00:00"
  //},
  //{
  //  "id": 2,
  //  "name": "Day of the Tentacle",
  //  "developer": "Lucas Arts",
  //  "release": "1993-05-25T00:00:00"
  //}
}
