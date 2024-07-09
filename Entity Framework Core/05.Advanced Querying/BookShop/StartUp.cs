namespace BookShop;

using Data;
using Initializer;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();
        DbInitializer.ResetDatabase(db);
    }

    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {
        var books = context.Books
            .Where(b => b.AgeRestriction.ToString() == command)
            .OrderBy(b => b.Title)
            .ToArray();

        StringBuilder sb = new StringBuilder();

        sb.AppendLine();

        return sb.ToString().TrimEnd();
    }

}




