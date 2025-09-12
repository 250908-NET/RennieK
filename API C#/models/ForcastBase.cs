using System;
using Microsoft.Net.Http.Headers;
public abstract class ForcastBase
{
    public DateTime date { get; set; }
    public string sky { get; set; }
    public string dayOftheWeek { get; set; }

    public ForcastBase()
    {
        this.date = new DateTime();
        this.sky = "";
        dayOftheWeek = "";
    }
    public ForcastBase(DateTime date, string sky, string dayOfWeek)
    {
        this.date = date;
        this.sky = sky;
        dayOftheWeek = dayOfWeek;
    }
}