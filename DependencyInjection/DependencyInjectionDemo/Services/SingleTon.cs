namespace DependencyInjectionDemo.Services
{
    public class SingleTon
    {
        public Guid InstanceId { get; } = Guid.NewGuid();
    }
}
