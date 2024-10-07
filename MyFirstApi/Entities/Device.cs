namespace MyFirstApi.Entities
{
    public abstract class Device
    {
        protected bool isConnected() => true;
        public abstract string GetBrand();
        public virtual string Hello() => "Hello from Device";
    }
}
