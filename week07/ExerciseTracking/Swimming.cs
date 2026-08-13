public class Swimming : Activity
{
  private int _laps;

  public Swimming(string date, int durationMinutes, int laps) : base(date, durationMinutes)
  {
    _laps = laps;
  }

  public override double GetDistance()
  {
    return (_laps * 50) / 1000.0;
  }

  public override double GetSpeed()
  {
    return (GetDistance() / GetDurationMinutes()) * 60;
  }

  public override double GetPace()
  {
    return GetDurationMinutes() / GetDistance();
  }
}