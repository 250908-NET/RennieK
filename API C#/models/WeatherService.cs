using models;

class WeatherService
{
    public List<Forcast> weatherForWeek = new List<Forcast>();
    List<string> possibleWeather = ["sunny", "partly clouldy", "rain", "sleet", "hail", "snow"];
    DateTime TodaysDate;
    int count;
    public List<Forcast> savedForcast = new List<Forcast>();

    public WeatherService()
    {
        this.TodaysDate = DateTime.Today;
        this.count = 0;

        for (int i = 0; i < 7; i++)
        {
            addForcast();
        }
    }

    public void addForcast()
    {
        Forcast newForcast = new Forcast();
        newForcast.date = new DateTime(TodaysDate.Year, TodaysDate.Month, TodaysDate.Day + count);
        Random rando = new Random();
        newForcast.sky = possibleWeather[rando.Next(possibleWeather.Count)];
        string[] days = ["mon", "tus", "wed", "thus", "fri", "sat", "sun"];
        newForcast.dayOftheWeek = newForcast.date.ToString("ddd");
        // newForcast.dayOftheWeek = days[(int)newForcast.date.DayOfWeek];
        weatherForWeek.Add(newForcast);
        count++;
    }
    public void saveForcast(Forcast fav)
    {
        savedForcast.Add(fav);
    }

    public List<Forcast> showForcast()
    {
        return weatherForWeek;
    }

}