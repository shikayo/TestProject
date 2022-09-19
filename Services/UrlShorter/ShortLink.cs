using System.Net;
using Newtonsoft.Json;
using System.IO;
using Services.UrlShorter.Response;

namespace Services.UrlShorter;

public class ShortLink : IShortLink
{
    public string GetShortUrl(string fullUrl)
    {
        string apikey = "38f98030d4684bdce312ecadd43702c24f8b0467";
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        
        var url = "https://api-ssl.bitly.com/v4/shorten";
        
        var httpRequest = (HttpWebRequest)WebRequest.Create(url);
        
        httpRequest.Method = "POST";
        httpRequest.Headers["Authorization"] = "Bearer " + apikey;
        httpRequest.ContentType = "application/json";
        
        var data = new { long_url = fullUrl, domain = "bit.ly" };
        
        using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
        {
            streamWriter.Write(JsonConvert.SerializeObject(data));
        }
        var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
        
        var streamReader = new StreamReader(httpResponse.GetResponseStream());
        
        ShortLinkResponse result = JsonConvert.DeserializeObject<ShortLinkResponse>(streamReader.ReadToEnd());
        
        return result.Link;
    }
}