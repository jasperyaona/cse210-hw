using System;
using System.Collections.Generic;


public class Video
{
    public string _title;
    public string _author;
    public int _length;

     private List<Comment> _comments = new List<Comment>();

     public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void DisplayVideo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Comments: {GetCommentCount()}");

        foreach (Comment comment in _comments)
        {
            Console.WriteLine(comment.DisplayText());
        }
    }

}
