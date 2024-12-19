using System;
using UnityEngine;

namespace TF.FModExtendedInspector
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FModParamAttribute : PropertyAttribute
    {
        public string EventName { get; private set; }

        public FModParamAttribute(string eventName)
        {
            EventName = eventName;
        }
    }
}