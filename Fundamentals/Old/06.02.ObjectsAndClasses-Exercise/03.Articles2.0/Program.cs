int numberOfArticle = int.Parse(Console.ReadLine());

List<Article> allArticle = new List<Article>();

for (int i = 0; i < numberOfArticle; i++)
{
    string[] inputArticle = Console.ReadLine()
    .Split(", ");

    string title = inputArticle[0];
    string content = inputArticle[1];
    string author = inputArticle[2];

    Article article = new Article(title, content, author);

    allArticle.Add(article);
}

foreach (Article article in allArticle)
{
    Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
}


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
}