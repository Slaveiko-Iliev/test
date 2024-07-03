using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new StudentSystemContext();
            context.SaveChanges();
        }


    }
}
