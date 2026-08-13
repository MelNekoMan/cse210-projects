public class Running : Activity
{
  private double _distanceKm;

  public Running(string date, int durationMinutes, double distanceKm) : base(date, durationMinutes)
  {
    _distanceKm = distanceKm;
  }

  public override double GetDistance()
  {
    return _distanceKm;
  }

  public override double GetSpeed()
  {
    return (_distanceKm / GetDurationMinutes()) * 60;
  }

  public override double GetPace()
  {
    return GetDurationMinutes() / _distanceKm;
  }
}