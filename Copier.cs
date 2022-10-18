class Copier
{
    readonly string rootPath;

    public Copier()
    {
        rootPath = Directory.GetCurrentDirectory();
    }

    public void CopyFiles(string fromPath, string toPath)
    {
        if(toPath.Equals("/*root"))
            toPath = rootPath;

        
    }
}