
class Program
{
    static void Main(string[] args)
    {
        var cp = new Copier();
        cp.CopyAll("/home/imache/CSProjects/DirCopy/testFrom", "/home/imache/CSProjects/DirCopy/testTo");
    }
}