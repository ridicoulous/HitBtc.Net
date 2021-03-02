using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtc.Net.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    class IgnoreAsParameterAttribute : Attribute
    {
    }
}
