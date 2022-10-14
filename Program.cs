using System.Diagnostics;

namespace WebsiteApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = string.Empty;
            if (args.Length > 0)
                url = args[0];
            else
                url = "https://google.com";

            string BrowserPath = string.Empty;

            string EdgePath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\Microsoft\Edge\Application\msedge.exe";
            if (File.Exists(EdgePath))
                BrowserPath = EdgePath;

            string BravePath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\BraveSoftware\Brave-Browser\Application\brave.exe";
            if (File.Exists(BravePath))
                BrowserPath = BravePath;

            if (!string.IsNullOrEmpty(url))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo() { Arguments = $"--incognito --bwsi --app={url}", FileName = BrowserPath };
                Process.Start(startInfo);
            }
        }


        enum Browser
        {
            Edge,
            Brave
        }
        public static void OpenWebsite(Browser browser, string url)
        {

        }
    }
}