using System;
using System.Collections.Generic;

public class Scripture
{
  private Reference _reference;
  private List<Word> _words;

  public Scripture(Reference reference, string text)
  {
    _reference = reference;
    _words = new List<Word>();

    string[] wordsArray = text.Split(' ');
    foreach (string wordText in wordsArray)
    {
      Word newWord = new Word(wordText);
      _words.Add(newWord);
    }
  }

  public void HideRandomWords(int numberToHide)
  {
    Random random = new Random();

    for (int i = 0; i < numberToHide; i++)
    {
      if (IsCompletelyHidden())
      {
        break;
      }
      int index = random.Next(_words.Count);
      while (_words[index].IsHidden())
      {
        index = random.Next(_words.Count);
      }

      _words[index].Hide();
    }
  }

  public string GetDisplayText()
  {
    string displayText = _reference.GetDisplayText() + " ";
    foreach (Word word in _words)
    {
      displayText += word.GetDisplayText() + " ";
    }
    return displayText.Trim();
  }

  public bool IsCompletelyHidden()
  {
    foreach (Word word in _words)
    {
      if (!word.IsHidden())
      {
        return false;
      }
    }
    return true;
    }
}