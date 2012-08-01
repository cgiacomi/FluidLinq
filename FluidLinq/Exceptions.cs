using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluidLinq
{
    public class InvokeMethodFromNullObjectException : Exception
    {
        public InvokeMethodFromNullObjectException(string message)
            : base(message)
        { }
    }
}
