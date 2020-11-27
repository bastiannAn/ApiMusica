using System;

namespace ApiMusica
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 37 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
