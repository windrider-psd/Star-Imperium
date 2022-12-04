using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class ExecuteOnDestroyAttribute : Attribute
    {
    }
}
