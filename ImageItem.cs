using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace ImageGallery_Saumya
{
    public class ImageItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public byte[] Base64 { get; set; }
        public string Format { get; set; }
    }
    public class DataFetcher
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public byte[] Base64 { get; set; }
        public string Format { get; set; }
    }
    async Task<string> GetDatafromService(string searchstring)
    {
        string readText = null;
        try
        {
            String url = @" https://imagefetcherapi.azurewebsites.net/api/fetch_images?query=" + searchstring + "&max_count=5";
            using (HttpClient c = new HttpClient())
            {
                readText = await c.GetStringAsync(url);
            }
        }
        catch
        {
            readText = File.ReadAllText(@"Data/sampleData.json");
        }
        return readText;
    }
    public async Task<List<ImageItem>> GetImageData(string search)
    {
        string data = await GetDatafromService(search);
        return JsonConvert.DeserializeObject<List<ImageItem>>(data);
    }
}
