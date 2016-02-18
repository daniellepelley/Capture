namespace Capture.Core.Test
{
    public interface IDemoClass
    {
        string Process(string value);
        Dto Process(Dto dto);

    }

    public class Dto
    {
        public string Value1 { get;set; }
        public int Number { get; set; }
    }
}