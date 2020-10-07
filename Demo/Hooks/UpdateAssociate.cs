using DirectScale.Disco.Extension.Hooks;
using DirectScale.Disco.Extension.Hooks.Associates;
using Microsoft.Extensions.Logging;
using System;

namespace Demo.Hooks
{
    public class UpdateAssociate : IHook<UpdateAssociateHookRequest, UpdateAssociateHookResponse>
    {
        private readonly ILogger _logger;

        public UpdateAssociate(ILogger logger)
        {
            _logger = logger;
        }

        public UpdateAssociateHookResponse Invoke(UpdateAssociateHookRequest request, Func<UpdateAssociateHookRequest, UpdateAssociateHookResponse> func)
        {
            try
            {
                if (request.UpdatedAssociateInfo.AssociateId == 2)
                {
                    throw new Exception("This was inside the UpdateAssociate hook.");
                }
                else if (request.UpdatedAssociateInfo.AssociateId == 1)
                {
                    UpdateAssociateHookResponse nullResponse = null;

                    //This line should throw a null reference exception.
                    nullResponse.ToString();
                }

                return func(request);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
