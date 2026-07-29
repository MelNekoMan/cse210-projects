using System;

public class Comment
{
  public string Username {get; set;}
  public string TextComment {get; set;}
  public Comment(string username, string comment)
  {
    Username = username;
    TextComment = comment;
  }
}