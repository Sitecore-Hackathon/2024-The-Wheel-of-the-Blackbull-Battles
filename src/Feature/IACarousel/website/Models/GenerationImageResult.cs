using Newtonsoft.Json;
using System;

namespace WbbHackathon.Feature.IACarousel.Models
{
    public partial class GenerationImageResult
    {
        [JsonProperty("generations_by_pk")]
        public GenerationsByPk GenerationsByPk { get; set; }
    }

    public partial class GenerationsByPk
    {
        [JsonProperty("generated_images")]
        public GeneratedImage[] GeneratedImages { get; set; }

        [JsonProperty("modelId")]
        public Guid ModelId { get; set; }

        [JsonProperty("motion")]
        public object Motion { get; set; }

        [JsonProperty("motionModel")]
        public object MotionModel { get; set; }

        [JsonProperty("motionStrength")]
        public object MotionStrength { get; set; }

        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        [JsonProperty("negativePrompt")]
        public string NegativePrompt { get; set; }

        [JsonProperty("imageHeight")]
        public long ImageHeight { get; set; }

        [JsonProperty("imageToVideo")]
        public object ImageToVideo { get; set; }

        [JsonProperty("imageWidth")]
        public long ImageWidth { get; set; }

        [JsonProperty("inferenceSteps")]
        public long InferenceSteps { get; set; }

        [JsonProperty("seed")]
        public long Seed { get; set; }

        [JsonProperty("public")]
        public bool Public { get; set; }

        [JsonProperty("scheduler")]
        public string Scheduler { get; set; }

        [JsonProperty("sdVersion")]
        public string SdVersion { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("presetStyle")]
        public object PresetStyle { get; set; }

        [JsonProperty("initStrength")]
        public object InitStrength { get; set; }

        [JsonProperty("guidanceScale")]
        public long GuidanceScale { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("promptMagic")]
        public bool PromptMagic { get; set; }

        [JsonProperty("promptMagicVersion")]
        public object PromptMagicVersion { get; set; }

        [JsonProperty("promptMagicStrength")]
        public object PromptMagicStrength { get; set; }

        [JsonProperty("photoReal")]
        public bool PhotoReal { get; set; }

        [JsonProperty("photoRealStrength")]
        public object PhotoRealStrength { get; set; }

        [JsonProperty("fantasyAvatar")]
        public object FantasyAvatar { get; set; }

        [JsonProperty("generation_elements")]
        public object[] GenerationElements { get; set; }
    }

    public partial class GeneratedImage
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("nsfw")]
        public bool Nsfw { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("likeCount")]
        public long LikeCount { get; set; }

        [JsonProperty("motionMP4URL")]
        public object MotionMp4Url { get; set; }

        [JsonProperty("generated_image_variation_generics")]
        public object[] GeneratedImageVariationGenerics { get; set; }
    }
}