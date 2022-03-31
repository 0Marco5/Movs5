using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class ConeccionAPIXTZ
{
    public string url = "https://api.kucoin.com/api/v1/market/stats?symbol=XTZ-USDT";
    public async Task<string> Symbol()
    {
        var httpClient = new HttpClient();

        var response = await httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine("Error conectando a la api");
            throw new Exception();
        }

        var json = await response.Content.ReadAsStringAsync();

        var info = JsonConvert.DeserializeObject<Root>(json);

        return info.Data.Symbol;

    }

    public async Task<string> Price()
    {
        var httpClient = new HttpClient();

        var response = await httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine("Error conectando a la api");
            throw new Exception();
        }

        var json = await response.Content.ReadAsStringAsync();

        var info = JsonConvert.DeserializeObject<Root>(json);

        return info.Data.Buy;

    }

    public async Task<string> ChangeRate()
    {
        var httpClient = new HttpClient();

        var response = await httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine("Error conectando a la api");
            throw new Exception();
        }

        var json = await response.Content.ReadAsStringAsync();

        var info = JsonConvert.DeserializeObject<Root>(json);

        string cambio = info.Data.ChangeRate;

        decimal cambioD = decimal.Parse(cambio);

        decimal resultado = cambioD * 100;

        cambio = resultado.ToString();

        int t = 0;
        string abc = string.Empty;
        bool q = false;
        for (int i = 0; i < cambio.Length; i++)
        {
            abc += cambio[i];
            if (q == true)
            {
                t++;
            }
            if (cambio[i] == '.')
            {
                q = true;
            }

            if (t == 2)
            {
                i = cambio.Length - 1;
            }
        }

        return abc;
    }

    public async Task<string> Low()
    {
        var httpClient = new HttpClient();

        var response = await httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine("Error conectando a la api");
            throw new Exception();
        }

        var json = await response.Content.ReadAsStringAsync();

        var info = JsonConvert.DeserializeObject<Root>(json);

        return info.Data.Low;

    }

    public async Task<string> High()
    {
        var httpClient = new HttpClient();

        var response = await httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine("Error conectando a la api");
            throw new Exception();
        }

        var json = await response.Content.ReadAsStringAsync();

        var info = JsonConvert.DeserializeObject<Root>(json);

        return info.Data.High;

    }

    //// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Ticker
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("buy")]
        public string Buy { get; set; }

        [JsonProperty("changeRate")]
        public string ChangeRate { get; set; }

        [JsonProperty("changePrice")]
        public string ChangePrice { get; set; }

        [JsonProperty("high")]
        public string High { get; set; }

        [JsonProperty("low")]
        public string Low { get; set; }
    }

    public class Root
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("data")]
        public Ticker Data { get; set; }
    }
}