using Disco;
using Disco.Extensions.Abstractions.Hooks;
using Disco.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Demo
{
    public class ExtensionEntry : IExtensionBase
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
        }

        public void Initialize(IApplicationExtendor extendor)
        {
            ServiceLocator.Instance.VerifyAllDependenciesResolve();

            extendor.AddPage(Menu.Associates, "V1.1", "MyView");
        }
    }
}
