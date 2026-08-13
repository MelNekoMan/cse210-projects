using System;

public abstract class Activity
{
  private string _date;
  private int _durationMinutes;

  public Activity(string date, int durationMinutes)
  {
    _date = date;
    _durationMinutes = durationMinutes;
  }

  public string GetDate()
  {
    return _date;
  }

  public int GetDurationMinutes()
  {
    return _durationMinutes;
  }

  public abstract double GetDistance();
  public abstract double GetSpeed();
  public abstract double GetPace();

  public virtual string GetSummary()
  {
    return $"{_date} {GetType().Name} ({_durationMinutes} min) - Distance: {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, Pace: {GetPace():F2} min per km";
  }
}