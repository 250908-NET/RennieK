namespace models;

class Forcast : ForcastBase
{
    public Forcast() : base()
    {

    }

    public Forcast(DateTime date, string sky, string dayOfWeek) : base(date, sky, dayOfWeek)
    {
        this.date = date;
        this.sky = sky;
        this.dayOftheWeek = dayOftheWeek;
    }

}