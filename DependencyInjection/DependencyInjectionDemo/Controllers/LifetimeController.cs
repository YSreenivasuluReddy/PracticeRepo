using DependencyInjectionDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LifetimeController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public LifetimeController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet("instances")]
        public IActionResult GetInstances()
        {
            // Resolve Singleton twice
            var singleton1 =
                _serviceProvider.GetRequiredService<SingleTon>();

            var singleton2 =
                _serviceProvider.GetRequiredService<SingleTon>();

            // Resolve Transient twice
            var transient1 =
                _serviceProvider.GetRequiredService<Transient>();

            var transient2 =
                _serviceProvider.GetRequiredService<Transient>();

            // Resolve Scoped twice
            var scoped1 =
                _serviceProvider.GetRequiredService<Scoped>();

            var scoped2 =
                _serviceProvider.GetRequiredService<Scoped>();

            return Ok(new
            {
                Singleton = new
                {
                    FirstInstance = singleton1.InstanceId,
                    SecondInstance = singleton2.InstanceId
                },

                Transient = new
                {
                    FirstInstance = transient1.InstanceId,
                    SecondInstance = transient2.InstanceId
                },

                Scoped = new
                {
                    FirstInstance = scoped1.InstanceId,
                    SecondInstance = scoped2.InstanceId
                }
            });
        }
    }
}