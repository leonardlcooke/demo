using DirectScale.Disco.Extension;
using Microsoft.Extensions.DependencyInjection;

namespace Demo
{
    public class ExtensionEntry : IExtensionBase
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
        }

        public void Initialize(IExtendor extendor)
        {
            //extendor.AddPage(Menu.Associates, "V2", "V2")
            extendor.Hooks.Associates.Enrollment.GetNewBackOfficeId.Override = (r, f) =>
            {
                var res = f(r);

                return new DirectScale.Disco.Extension.Hooks.Associates.Enrollment.SetBackOfficeIdHookResponse
                {
                    BackOfficeId = res.BackOfficeId
                };
            };
        }
    }
}
