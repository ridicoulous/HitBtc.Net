using System;

namespace HitBtc.Net.Attributes
{
    /// <summary>
    /// Extensions.AsDictionary() should ignore such class member
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    class IgnoreAsParameterAttribute : Attribute
    {
    }
}
