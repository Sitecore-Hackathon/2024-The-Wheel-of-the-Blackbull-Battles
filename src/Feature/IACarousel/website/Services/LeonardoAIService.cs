using Newtonsoft.Json;
using Sitecore.Diagnostics;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WbbHackathon.Feature.IACarousel.Models;
using WbbHackathon.Feature.IACarousel.Models.Parameters;

namespace WbbHackathon.Feature.IACarousel.Services
{
    public class LeonardoAIService : ILeonardoAIService
    {
        public async Task<GenerationModel> GetGenerationId(ImageGenerationParameters parameters)
        {
            var model = new GenerationModel();
            try
            {
                using (var client = new HttpClient())
                {
                    
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.ApiToken);
                    var jsonParameters = JsonConvert.SerializeObject(parameters);
                    var content = new StringContent(jsonParameters, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(Constants.GenerationEndPoint, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<GenerationModel>(data);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error getting generation id", ex, this);
            }
            return model;
        }

        public async Task<GenerationImageResult> GetImageResult(string generationId)
        {
            var model = new GenerationImageResult();
            try
            {
                using (var client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.ApiToken);
                    HttpResponseMessage response = client.GetAsync($"{Constants.GenerationEndPoint}/{generationId}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<GenerationImageResult>(data);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error getting generation id", ex, this);
            }
            return model;
        }
    }
}