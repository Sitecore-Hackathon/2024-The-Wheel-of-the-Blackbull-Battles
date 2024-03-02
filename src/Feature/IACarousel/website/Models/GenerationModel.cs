using Newtonsoft.Json;

namespace WbbHackathon.Feature.IACarousel.Models
{
    public class GenerationModel
    {
        [JsonProperty("sdGenerationJob")]
        public GenerationJobModel Job { get; set; }

        public GenerationModel()
        {
            Job = new GenerationJobModel();
        }
    }

    public class GenerationJobModel
    {
        [JsonProperty("generationId")]
        public string GenerationId { get; set; }

        [JsonProperty("apiCreditCost")]
        public int ApiCreditCost { get; set; }
    }
}