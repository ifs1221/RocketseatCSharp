namespace MyFirstApi.Entities
{
    public class Laptop : Device
    {

        public override string GetBrand()
        {
            return "Apple";
        }
        public string getModel()
        {
            if (isConnected())
            {
                return "MacBook";
            }
            return "Unknown";
        }
        public override string Hello()
        {
            return "Hello from Laptop";
        }
    }
}
