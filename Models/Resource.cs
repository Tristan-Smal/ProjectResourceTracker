namespace ResourceTracker.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string? ResourceTitle { get; set; }    
        public string? ResourceLink { get; set; }
        public int ProjectId { get; set; }

        public virtual Project? Project { get; set; }
    }
}
