using System;
using UnityEngine;

namespace TF.FModExtendedInspector
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FModParamLabelAttribute : PropertyAttribute
    {
        public string EventName { get; private set; }
        public string ParamName { get; private set; }

        public FModParamLabelAttribute(string eventName, string paramName)
        {
            EventName = eventName;
            ParamName = paramName;
        }
    }
}