using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }
        public static CitiesDataStore Current { get; set; } = new CitiesDataStore();
        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id= 1,
                    Name = "NY",
                    Description= "nydesc",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id= 1,
                            Name = "NYPoI1",
                            Description= "NYPoI1nydesc",
                        },

                        new PointOfInterestDto()
                        {
                            Id= 2,
                            Name = "NYPoI2",
                            Description= "NYPoI2nydesc",
                        }
                    }
                },

                new CityDto()
                {
                    Id= 2,
                    Name = "Antwerp",
                    Description= "antdesc",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id= 1,
                            Name = "ATPoI1",
                            Description= "ATPoI1nydesc",
                        },

                        new PointOfInterestDto()
                        {
                            Id= 2,
                            Name = "ATPoI2",
                            Description= "ATPoI2nydesc",
                        }
                    }
                },

                new CityDto()
                {
                    Id= 3,
                    Name = "Paris",
                    Description= "parisdesc",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id= 1,
                            Name = "PAPoI1",
                            Description= "ATPoI1nydesc",
                        },

                        new PointOfInterestDto()
                        {
                            Id= 2,
                            Name = "PAPoI2",
                            Description= "ATPoI2nydesc",
                        }
                    }
                }
            };
        }
    }
}
