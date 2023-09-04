using System.Collections.ObjectModel;

namespace CityInfo.API.Models
{
    public class PointOfInterestUpdateDto{
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
