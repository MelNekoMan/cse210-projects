using System;

public abstract class Goal
{
  private string _shortname;
  private string _description;
  private int _points;

  public Goal(string name, string description, int points)
  {
    _shortname = name;
    _description = description;
    _points = points;
  }

  public string GetShortName()
  {
    return _shortname;
  }

  public string GetDescription()
  {
    return _description;
  }

  public int GetPoints()
  {
    return _points;
  }

  public abstract int RecordEvent();
  public abstract bool IsComplete();

  public virtual string GetDetailsString()
  {
    string statusSymbol = IsComplete() ? "[X]" : "[ ]";
    return $"{statusSymbol} {_shortname} ({_description})";
  }

  public abstract string GetStringRepresentation();
}