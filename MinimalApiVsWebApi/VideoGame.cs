namespace MinimalApiVsWebApi
{
    public class VideoGame
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Developer { get; set; } = string.Empty;
        public DateTime Release { get; set; }
    }
}
