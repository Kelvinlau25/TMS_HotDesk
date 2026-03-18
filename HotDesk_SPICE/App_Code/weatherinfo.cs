using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;

public class WeatherInfo
{
    private City _city;
    public City city { get { return _city; } set { _city = value; } }

    private List<WeatherList> _list;
    public List<WeatherList> list { get { return _list; } set { } }
}

public class City
{
    private string _name;
    public string name { get { return _name; } set { _name = value; } }

    private string _country;
    public string country { get { return _country; } set { _country = value; } }
}

public class Temp
{
    private double _day;
    public double day { get { return _day; } set { _day = value; } }

    private double _min;
    public double min { get { return _min; } set { _min = value; } }

    private double _max;
    public double max { get { return _max; } set { _max = value; } }

    private double _night;
    public double night { get { return _night; } set { _night = value; } }
}

public class Weather
{
    private string _description;
    public string description { get { return _description; } set { _description = value; } }

    private string _icon;
    public string icon { get { return _icon; } set { _icon = value; } }
}

public class WeatherList
{
    private Temp _temp;
    public Temp temp { get { return _temp; } set { _temp = value; } }

    private int _humidity;
    public int humidity { get { return _humidity; } set { _humidity = value; } }

    private List<Weather> _weather;
    public List<Weather> weather { get { return _weather; } set { _weather = value; } }
}
