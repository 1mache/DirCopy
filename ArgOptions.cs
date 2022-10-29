using ConsoleOptions;
namespace DirCopy
{
    class ArgOptions
    {
        public bool IncludeNested {get; private set;} = false; 

        [Param(false, "From where")]
        public string FromPath { get; set; } = ""; 
        [Param(false, "To where")]
        public string ToPath { get; set; } = "";

        [Command("-a", "Copy nested folders")]
        public void SetIncludeNestedFlag()
        {
            IncludeNested = true;
        }
    }
}