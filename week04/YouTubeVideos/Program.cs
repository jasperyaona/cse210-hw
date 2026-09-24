using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
   
        // Create videos
        Video video1 = new Video("How to Learn C#", "Jasper", 600);
        Video video2 = new Video("Top 10 Programming Tips", "Code Master", 480);
        Video video3 = new Video("My First Software Project", "Jasper", 720);
        Video video4 = new Video("Introduction to Web Development", "Web Dev Channel", 900);

        // Add comments to video 1
        video1.AddComment(new Comment("John", "This was very helpful!"));
        video1.AddComment(new Comment("Maria", "I learned a lot from this video."));
        video1.AddComment(new Comment("David", "Great explanation."));
        video1.AddComment(new Comment("Sarah", "Thanks for sharing!"));

        // Add comments to video 2
        video2.AddComment(new Comment("Mike", "These tips are really useful."));
        video2.AddComment(new Comment("Anna", "I will try these tips."));
        video2.AddComment(new Comment("Chris", "Great video!"));

        // Add comments to video 3
        video3.AddComment(new Comment("Daniel", "Nice project!"));
        video3.AddComment(new Comment("Emily", "I like how you explained everything."));
        video3.AddComment(new Comment("James", "Keep up the good work."));
        video3.AddComment(new Comment("Lisa", "This gave me some ideas for my own project."));

        // Add comments to video 4
        video4.AddComment(new Comment("Robert", "Web development is interesting."));
        video4.AddComment(new Comment("Jessica", "Very informative."));
        video4.AddComment(new Comment("Mark", "I enjoyed watching this."));
        
        // Put all videos in a list
        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        // Display each video
        foreach (Video video in videos)
        {
            video.DisplayVideo();
            Console.WriteLine();
        }
    }
}