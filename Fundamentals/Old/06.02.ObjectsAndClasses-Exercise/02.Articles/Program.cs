using System;
using System.ComponentModel.DataAnnotations;

string[] inputArticle = Console.ReadLine()
    .Split(", ");

string title = inputArticle[0];
string content = inputArticle[1];
string author = inputArticle[2];

Article article = new Article(title, content, author);

int N = int.Parse(Console.ReadLine());

for (int i = 0; i < N; i++)
{
    string[] fullCommand = Console.ReadLine()
        .Split(": ");

    string currentCommand = fullCommand[0];
    string value = fullCommand[1];

    if (currentCommand == "Edit")
    {
        article.Edit(value);
    }
    else if (currentCommand == "ChangeAuthor")
    {
        article.ChangeAuthor(value);
    }
    else if (currentCommand == "Rename")
    {
        article.Rename(value);
    }
}

Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");


public class Article
{
    public Article(string title, string content, string author)
    {
        this.Title = title;
        this.Content = content;
        this.Author = author;
    }

    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }

    public void Edit (string newContent)
    {
        Content = newContent;
    }

    public void ChangeAuthor (string newAuthor)
    {
        Author = newAuthor;
    }

    public void Rename (string newTitle)
    {
        Title = newTitle;
    }
}