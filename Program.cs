using System.Diagnostics;

namespace WebsiteApp
{

    internal sealed class Browser
    {
        private string Path { get; set; }
        public Browser(string Path)
        {
            this.Path = Path;
        }

        public bool OpenWebsite(string url)
        {
            if (File.Exists(this.Path))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo() { Arguments = $"--window-size=10,10 --incognito --app={url}", FileName = this.Path };
                Process.Start(startInfo);
                return true;
            }
            else
                return false;

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = string.Empty;
            if (args.Length > 0)
                url = args[0];
            else
                url = "https://kyedev.xyz";

            string ProgramFilesX86Folder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            string ProgramFilesFolder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            Browser Edge = new Browser(ProgramFilesX86Folder + @"\Microsoft\Edge\Application\msedge.exe");
            Browser Brave = new Browser(ProgramFilesFolder + @"\BraveSoftware\Brave-Browser\Application\brave.exe");

            if (Brave.OpenWebsite(url))
                return;
            else if (Edge.OpenWebsite(url))
                return;
            else
                Console.WriteLine("No browser found");

            Console.ReadKey();
        }
    }
}