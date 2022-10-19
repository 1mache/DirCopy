
class Program
{
    static string Squiggle(string path)
    {
        var curr = Directory.GetCurrentDirectory();
        //replaces the "~/" with path of current directory 
        return Path.Combine(curr, path.Substring(2));
    }
    
    static void CopyFiles(string fromPath, string toPath)
    {
        if(fromPath.Substring(0,2).Equals("~/"))
        {
            fromPath = Squiggle(fromPath);
        }        
        if(fromPath.Substring(0,2).Equals("~/"))
        {
            toPath = Squiggle(toPath);
        }
        
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
        if(fromPath[0].Equals('~'))
        {
            fromPath = Squiggle(fromPath);
        }        
        if(toPath[0].Equals('~'))
        {
            toPath = Squiggle(toPath);
        }

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
        CopyAll("~/testFrom", "~/testTo");
    }
}