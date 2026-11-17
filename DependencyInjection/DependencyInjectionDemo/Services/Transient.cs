namespace DependencyInjectionDemo.Services
{
    public class Transient
    {
        public Guid InstanceId { get; } = Guid.NewGuid();
    }
}
