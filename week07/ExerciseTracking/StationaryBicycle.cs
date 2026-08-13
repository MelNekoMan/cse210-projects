public class StationaryBicycle : Activity
{
  private double _speedKph;

  public StationaryBicycle(string date, int durationMinutes, double speedKph) : base(date, durationMinutes)
  {
    _speedKph = speedKph;
  }

  public override double GetDistance()
  {
    return (_speedKph * GetDurationMinutes()) / 60;
  }

  public override double GetSpeed()
  {
    return _speedKph;
  }

  public override double GetPace()
  {
    return 60 / _speedKph;
  }
}