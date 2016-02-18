namespace Capture.Core.Test
{
    public class DemoClass : IDemoClass
    {
        public string Process(string value)
        {
            return value;
        }

        public Dto Process(Dto dto)
        {
            return dto;
        }
    }
}