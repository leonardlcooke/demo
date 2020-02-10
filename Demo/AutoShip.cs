using Disco.Data.Adapter.Scripts.ScriptRoot;
using Disco.Extensions.Abstractions.Autoships;
using System;

namespace Demo
{
    class AutoShip
    {
        public static RetryRule ShouldChargeAutoShip(IRootObject core, DateTime now, DateTime nextChargeDate)
        {
            //NOTE. Need to make it retry each period after failed period. (Example. Month1 failes, it needs to try again in month2).
            
            return null;
        }
    }
}
