using System.Net;
using System.Net.Http;
using System.IO;
using System;
using System.Threading.Tasks;
using SateliteImageAPIViewer.Interfaces;

namespace SateliteImageAPIViewer.Services
{
    public class SateliteAPIService
    {
        private HttpClient client = new HttpClient();
        private readonly ISettingService _apiSetting;
        string? url;
        public SateliteAPIService(ISettingService settingService)
        {
            _apiSetting = settingService;
            url = "http://apis.data.go.kr/1360000/SatlitImgInfoService/getInsightSatlit"; // URL
            url += "?ServiceKey=" + "miUyD1M5iEJ3dMifSVNYib0E9mHEKcRQIj6v2XngOxBM9z%2FVXirTPMmTVLPqZITUCn%2Fl5KGPfsTf29ArnsoSxA%3D%3D"; // Service Key
            url += "&pageNo=1";
            url += "&numOfRows=10";
            url += "&dataType=JSON";
            url += "&sat=G2";
            url += $"&data={_apiSetting.SeteliteAPISetting.CameraType.ToString()}";
            url += $"&area={_apiSetting.SeteliteAPISetting.CameraArea.ToString()}";
            url += $"&time={_apiSetting.SeteliteAPISetting.Datetime}";
        }
        public async Task<string> ResponseAPI()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                client.Dispose();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }
    }
}
