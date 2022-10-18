class Copier
{
    readonly string rootPath;

    public Copier()
    {
        rootPath = Directory.GetCurrentDirectory();
    }

    public void CopyFiles(string fromPath, string toPath)
    {
        if(Directory.Exists(fromPath))
        {
            if(!Directory.Exists(toPath))
            {
                System.Console.WriteLine("Destination path does not exist!");
                return;
            }

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
}