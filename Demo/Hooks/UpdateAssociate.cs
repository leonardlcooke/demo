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
                    throw new NonSerializableGenericException("This was inside the UpdateAssociate hook.");
                }
                else if (request.UpdatedAssociateInfo.AssociateId == 1)
                {
                    UpdateAssociateHookResponse nullResponse = null;

                    //This line should throw a null reference exception.
                    nullResponse.ToString();
                }

                request.UpdatedAssociateInfo.Custom.Field1 = Environment.MachineName;
                request.UpdatedAssociateInfo.Custom.Field2 = Environment.CurrentDirectory;
                request.UpdatedAssociateInfo.Custom.Field3 = Environment.Version.ToString();
                request.UpdatedAssociateInfo.Custom.Field3 = Environment.UserInteractive.ToString();

                return func(request);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }


        //This exception is not marked as serializable.  This is to test what happens when an exception is not passed to the domain.
        public class NonSerializableGenericException : Exception
        {
            public NonSerializableGenericException(string message) : base(message)
            {

            }
        }
    }
}
