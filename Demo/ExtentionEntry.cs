using Disco;
using Disco.Extensions.Abstractions.Hooks;
using Microsoft.Extensions.DependencyInjection;
using Disco.Extensions.Abstractions.Associates.Services;
using Disco.Extensions.Abstractions.Hooks.Associates.Enrollment;
using Disco.Extensions.Abstractions.Corporate.Services;

namespace Demo
{
    public class ExtensionEntry : IExtensionBase
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
        }

        public void Initialize(IApplicationExtendor extendor)
        {
            extendor.AddPage(Menu.Associates, "V1", "V1");
        }
    }
}
