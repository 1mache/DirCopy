using ConsoleOptions;
namespace DirCopy
{
    class ArgConfig
    {
        public bool IncludeNested {get; private set;} = false; 

        [Param("SOURCE",false, "From where")]
        public string FromPath { get; set; } = ""; 
        [Param("DESTINATION",false, "To where")]
        public string ToPath { get; set; } = "";

        [Command("a", "Copy nested folders")]
        public void SetIncludeNestedFlag()
        {
            IncludeNested = true;
        }
    }
}