using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Top 5 Gaming I/O Devices of 2026 (TechPro Review)", "Hardware Heaven", 600);
        video1.Comments.Add(new Comment("GamerGuy99", "That techpro mouse looks super clean, definitely buying one!"));
        video1.Comments.Add(new Comment("CodeWithAlex", "Great review! Does the keyboard have silent switches?"));
        video1.Comments.Add(new Comment("SarahKeys", "I've been using the headphones model for two months and it's awesome."));

        Video video2 = new Video("Building my Ultimate PC Desktop Setup 2026", "Tech Minimalist", 900);
        video2.Comments.Add(new Comment("GamerGuy99", "I saw the mouse of that TechPro keyboard in another video, and I loved it just as much as that one. I'm definitely going to buy one!"));
        video2.Comments.Add(new Comment("PlasticFoods","Is the Techpro mouse compatible with Mac?"));
        video2.Comments.Add(new Comment("YuitheKitty","Awesome camera quality! I loved the Japanese theme"));

        Video video3 = new Video("Is the TechPro Headset Actually Worth It?", "AudioGeek Reviews", 480);
        video3.Comments.Add(new Comment("MrPancake71", "You can really tell what high-quality materials they were made from. I'm gonna buy one"));
        video3.Comments.Add(new Comment("SamuraiWarrior", "I have those, but they broke, and the support team isn't responding to me; I miss them"));
        video3.Comments.Add(new Comment("MaxTheRacoon", "Are those compatible with Mac? Great video btw, God bless you."));

        List<Video> videos = new List<Video> {video1, video2, video3};
        int counter = 0;

        foreach (Video video in videos)
        {
            counter++;
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine($"Comments:");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"  - {comment.Username}: {comment.TextComment}");
            }

            if (counter < videos.Count)
            {
                Console.WriteLine("-----------------------------------");
            }
        }
    }
}