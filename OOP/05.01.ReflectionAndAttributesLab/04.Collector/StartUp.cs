namespace Stealer
{
    public class StartUp
    {
        public static void Main()
        {
            Spy spy = new Spy();

            //string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            //Console.WriteLine(result);

            //string result = spy.AnalyzeAccessModifiers("Stealer.Hacker");
            //Console.WriteLine(result);

            //string result = spy.RevealPrivateMethods("Stealer.Hacker");
            //Console.WriteLine(result);

            string result = spy.CollectGettersAndSettrs("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}
