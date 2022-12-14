using ConsoleOptions;
namespace DirCopy
{
    class Program
    { 
        static void CopyFiles(string fromPath, string toPath)
        {
            if(fromPath.Length == 0 || toPath.Length == 0)
                throw new ArgumentException("Empty path!");

            if(Directory.Exists(fromPath))
            {
                if(!Directory.Exists(toPath))
                {
                    System.Console.WriteLine("Destination path does not exist!");
                    return;
                }

                //full paths of files
                string[] files = Directory.GetFiles(fromPath);

                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file);
                    var dest = Path.Combine(toPath, fileName);
                    //overwriting the destination file if exists
                    File.Copy(file, dest, true); 
                }
            }   
            else
            {
                System.Console.WriteLine("Source path does not exist");
            }
        }

        static void CopyAll(string fromPath, string toPath)
        {
            if(fromPath.Length == 0 || toPath.Length == 0)
                throw new ArgumentException("Empty path!");
            
            if(Directory.Exists(fromPath))
            {
                if(!Directory.Exists(toPath))
                {
                    System.Console.WriteLine("Destination path does not exist!");
                    return;
                }

                //copy all the files inside this dir
                CopyFiles(fromPath, toPath);
                //full paths of nested folders 
                var nestedDirs = Directory.GetDirectories(fromPath);
                
                foreach (var dir in nestedDirs)
                {
                    //gets the folder name
                    var dirName = new DirectoryInfo(dir).Name;
                    var destDir = Path.Combine(toPath, dirName);
                    Directory.CreateDirectory(destDir);
                    CopyAll(dir, destDir);    
                }

            }
            else
            {
                System.Console.WriteLine("Source path does not exist");
            }
        }
        static void Main(string[] args)
        {
            var config = new ArgConfig();
            var parser = new Parser<ArgConfig>("dircopy", config);

            bool success = parser.Parse(args);
            if(!success) return;

            if(config.IncludeNested == true)
            {
                CopyAll(config.FromPath, config.ToPath);
            }
            else
            {
                CopyFiles(config.FromPath, config.ToPath);
            }

            System.Console.WriteLine("Successfully copied!");
        }
    }
}