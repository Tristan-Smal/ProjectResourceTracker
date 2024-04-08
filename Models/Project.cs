using Humanizer.Localisation;
using ResourceTracker.Models;

namespace ResourceTracker.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? ProjectTitle { get; set; }
        public string? ProjectDescription { get; set; }

        public virtual ICollection<Resource>? Resources { get; set; }
    }
}





