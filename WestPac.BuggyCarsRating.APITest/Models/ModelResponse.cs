using System.Collections.Generic;

namespace WestPac.BuggyCarsRating.APITest.Models
{
    public class ModelResponse
    {
        public List<Model> Models { get; set; }
        public int TotalPages { get; set; }
    }

    public class Model
    {
        public string[] Comments { get; set; }
        public string EngineVol { get; set; }
        public string Id { get; set; }
        public string Image { get; set; }
        public string Make { get; set; }
        public string MakeId { get; set; }
        public string MakeImage { get; set; }
        public string Name { get; set; }

        public int Rank { get; set; }
        public int TotalComments { get; set; }
    }
}
