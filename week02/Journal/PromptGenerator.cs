public class PromptGenerator
{
  public List<string> _prompts = new List<string>();

  public PromptGenerator()
  {
    _prompts.Add("How was your day today?");
    _prompts.Add("Did you meet anyone new or visit an interesting place today?");
    _prompts.Add("What is the most interesting or unexpected thing you learned about yourself this week?");
    _prompts.Add("Did you see or read something today that made you change your mind about a topic?");
    _prompts.Add("How did you see the hand of the Lord, Jesus Christ, or Heavenly Father in your life today?");
  }


  public string GetRandomPrompt()
  {
    Random randomGenerator = new Random();
    int randomIndex = randomGenerator.Next(_prompts.Count);
    return _prompts[randomIndex];
  }
}