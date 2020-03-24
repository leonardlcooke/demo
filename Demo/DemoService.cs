using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo
{
    public class DemoService : IDemoService
    {
        public string GetValue()
        {
            return "Hello";
        }
    }
}
